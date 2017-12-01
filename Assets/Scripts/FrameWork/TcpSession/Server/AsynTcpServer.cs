using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using NetWrapper.Network;
using System.Net.Sockets;
using NetWrapper.Network.Tool;

namespace NetWrapper
{
    public interface ITServerListener
    {
        void OnConnect(int peerID);
        void OnDisconnect(int peerID);
        void OnPktReceive(int peerID, StreamBuffer sb); //处理收包
    }

    public sealed class AsynTcpServer : ISessionManager, System.IDisposable
    {
        private object m_connectlock = new object();
        private Dictionary<int, ReliableOrderServerPeer> m_peerMap;
        private static AsynTcpServer m_sInstance = null;
        private ITServerListener m_serverListener;
        private Socket m_listener;
        private int m_maxConnectNum;
        private int m_currConnectNum;
        private bool m_isStartServr;
        private IPEndPoint m_localEndPoint;
        private Thread m_listenThread;
        public static AsynTcpServer Instance
        {
            get
            {
                if (m_sInstance == null)
                {
                    m_sInstance = new AsynTcpServer();
                }

                return m_sInstance;
            }
        }

        private AsynTcpServer()
            : base()
        {
            this.m_maxConnectNum = 1;
            this.m_currConnectNum = 0;
            this.m_peerMap = new Dictionary<int, ReliableOrderServerPeer>();
            this.m_isStartServr = false;
            this.m_listener = null;
            this.m_serverListener = null;
            this.m_localEndPoint = null;
        }

        public void SetMaxConnectNum(int maxNum)
        {
            if (maxNum > 0)
            {
                this.m_maxConnectNum = maxNum;
            }
        }
        // 先安一个连接设计
        public void StartListening(string ip, int port, ITServerListener serverListener, int connectNum = 1)
        {
            if (m_isStartServr) return;
            m_isStartServr = true;

            m_maxConnectNum = connectNum;
            m_currConnectNum = 0;
            m_serverListener = serverListener;
            IPAddress ipAddress = IPAddress.Parse(ip);
            m_localEndPoint = new IPEndPoint(ipAddress, port);

            m_listenThread = new Thread(new ThreadStart(DoAccepting))
            {
                Name = "accepting thread",
                IsBackground = true
            };
            m_listenThread.Start();
        }

        private void DoAccepting()
        {
            m_listener = new Socket(m_localEndPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                m_listener.Bind(m_localEndPoint);                           // Bind the socket to the local endpoint
                m_listener.Listen(1);                                       // Listen for incomming connections
                while(m_currConnectNum < m_maxConnectNum)
                {
                    Socket severSocket = m_listener.Accept();
                    lock (m_connectlock)
                    {
                        int sessionID = GetCurrSessionID();
                        ServerSession serverSession = new ServerSession(sessionID, null, severSocket);
                        this.m_addVecSession[sessionID] = serverSession;

                        m_currConnectNum = this.m_addVecSession.Count + this.m_vecSession.Count;
                    }
                }
            }
            catch (SocketException se)
            {
                WriteFiles.WritFile.Log(se);
            }
            catch (Exception ex)
            {
                WriteFiles.WritFile.Log(ex);
            }
        }

        internal void RemoveSession(int sessionID)
        {
            DoRemoveSession(sessionID);
        }

        public void Send(int peerID, DELIVERY_TYPE d_type, StreamBuffer sb)
        {
            if (this.m_peerMap.ContainsKey(peerID))
            {
                m_peerMap[peerID].Send(d_type, sb);
            }
        }

        public void Send(int peerID, StreamBuffer sb)
        {
            Send(peerID, DELIVERY_TYPE.DELIVERY_NORMAL, sb);
        }

        public void DisConnect(int peerID)
        {
            if (this.m_peerMap.ContainsKey(peerID))
            {
                this.m_peerMap[peerID].Disconnect();
                lock (m_removeIDList)
                {
                    this.m_removeIDList.Add(peerID);
                }
            }
        }

        public void ShutDown()
        {
            if (!m_isStartServr) return;
            m_isStartServr = false;

            Dictionary<int, IGameSession>.Enumerator iter = m_vecSession.GetEnumerator();
            while (iter.MoveNext())
            {
                iter.Current.Value.ShutDown();

                lock (m_removeIDList)
                {
                    this.m_removeIDList.Add(iter.Current.Value.GetSessionID());
                }
            }

            if (m_listener != null)
            {
                m_listener.Close();
                m_listener = null;
            }

            m_listenThread.Join();

            m_addVecSession.Clear();
        }

        public void Dispose()
        {
            ShutDown();
        }

        ~AsynTcpServer()
        {
            Dispose();
        }

        public void Update()
        {
            DoUpdate();
        }

        protected override void DoUpdate()
        {
            if (m_addVecSession.Count > 0)
            {
                lock (m_connectlock)
                {
                    if (m_addVecSession.Count > 0)
                    {
                        Dictionary<int, IGameSession>.Enumerator iterAdd = m_addVecSession.GetEnumerator();
                        while (iterAdd.MoveNext())
                        {
                            IGameSession gSession = iterAdd.Current.Value;
                            ServerPeerCallback spc = new ServerPeerCallback(gSession.GetSessionID(), m_serverListener);
                            ReliableOrderServerPeer rsp = new ReliableOrderServerPeer(gSession, spc);
                            rsp.StartServerPeer(spc);
                            m_peerMap.Add(rsp.GetPeerID(), rsp);
                            m_vecSession.Add(iterAdd.Current.Key, gSession);
                        }

                        m_addVecSession.Clear();
                    }
                }
            }

            Dictionary<int, IGameSession>.Enumerator iter = m_vecSession.GetEnumerator();
            while (iter.MoveNext())
            {
                iter.Current.Value.Update();
            }

            if (this.m_removeIDList.Count > 0)
            {
                lock (m_removeIDList)
                {
                    int listLength = this.m_removeIDList.Count;
                    for (int index = 0; index < listLength; index++)
                    {
                        int peerID = this.m_removeIDList[index];
                        if (this.m_vecSession.ContainsKey(peerID))
                        {
                            this.m_vecSession.Remove(peerID);
                        }
                        if (this.m_peerMap.ContainsKey(peerID))
                        {
                            this.m_peerMap.Remove(peerID);
                        }
                    }

                    this.m_removeIDList.Clear();
                }
            }
        }
    }

    public sealed class ServerPeerCallback : IPeerListener
    {
        private readonly int m_peerID;
        private readonly ITServerListener m_netDataHandler;

        public ServerPeerCallback(int peerID, ITServerListener netDataHandler)
        {
            m_peerID = peerID;
            m_netDataHandler = netDataHandler;
        }

        void IPeerListener.OnConnected()
        {
            m_netDataHandler.OnConnect(m_peerID);
        }
        void IPeerListener.OnDisconnected()
        {
            m_netDataHandler.OnDisconnect(m_peerID);
        }
        void IPeerListener.OnPktReceive(StreamBuffer sb)
        {
            m_netDataHandler.OnPktReceive(m_peerID, sb);
        }
    }
}

//private void OnConnectAccepted(IAsyncResult result)
//{
//    lock (m_connectlock)
//    {
//        set signal so main thread starts listening again.
//        try
//        {
//            Socket listener = (Socket)result.AsyncState;
//            if (m_isStartServr)
//            {
//                if (m_vecSession.Count < m_maxConnectNum)
//                {
//                    int sessionID = GetCurrSessionID();
//                    ServerSession serverSession = new ServerSession(sessionID, null, listener.EndAccept(result));
//                    lock (m_connectlock)
//                    {
//                        this.m_addVecSession[sessionID] = serverSession;
//                    }
//                }
//                else
//                {
//                    Socket cpClientSocket = listener.EndAccept(result);
//                    cpClientSocket.Shutdown(SocketShutdown.Both);
//                    cpClientSocket.Close();
//                }

//                listener.BeginAccept(new AsyncCallback(this.OnConnectAccepted), listener);
//            }
//        }
//        catch (SocketException se)
//        {
//            WriteFiles.WritFile.Log(se);
//        }
//        catch (Exception ex)
//        {
//            WriteFiles.WritFile.Log(ex);
//        }
//    }
//}
