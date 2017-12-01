//  ClientSession.cs
//  Nilsen
//  2015-04-09

using System;
using System.Net.Sockets;
using NetWrapper.Network.Tool;
using NetWrapper.Network;
using System.Threading;

namespace NetWrapper
{
    /// <summary>
    /// 网络会话类
    /// </summary>
    public class ClientSession : IGameSession
    {
        public ClientSession(int sessionID, ISessionListener sessionListener)
            : base(sessionID, sessionListener)
        {
        }
    }

    public class ServerSession : IGameSession
    {
        private bool m_bShutDown;

        public ServerSession(int sessionID, ISessionListener sessionListener, Socket remoteSocket)
            : base(sessionID, sessionListener)
        {
            this.m_cSocket = remoteSocket;
            this.m_cSocket.NoDelay = true;
            this.m_bShutDown = false;
        }

        public void SessionReceive(ISessionListener sessionListener)
        {
            m_bShutDown = false;
            m_cDispatch.SetSessionListener(sessionListener);

            ChangeStatus(SocketState.Connected);

            m_receiveThread = new Thread(new ThreadStart(ReceiveLoop)) { Name = "receive thread", IsBackground = true };
            m_receiveThread.Start();
            //m_sendThread = new Thread(new ThreadStart(SendLoopSyn)) { Name = "send loop", IsBackground = true };
            //m_sendThread.Start();
        }

        public override void ShutDown()
        {
            m_bShutDown = true;

            base.ShutDown();
        }

        protected override void ChangeStatus(SocketState status)
        {
            this.m_SocketState = status;
            if(!m_bShutDown)
            {
                base.ChangeStatus(status);
            }
        }
    }
}