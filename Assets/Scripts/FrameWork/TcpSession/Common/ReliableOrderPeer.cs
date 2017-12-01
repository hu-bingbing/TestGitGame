using System;
using System.Collections.Generic;
using NetWrapper.Network.Tool;


namespace NetWrapper.Network
{
    public class ToSendBuffer
    {
        public readonly int m_sendIndex;
        public readonly RawStreamBuffer m_sendBuffer;

        public ToSendBuffer(int sendIndex, RawStreamBuffer sendBuffer)
        {
            m_sendIndex = sendIndex;
            m_sendBuffer = sendBuffer;
        }
    }

    public class ToResendBuffer
    {
        public DateTime m_sendTime;
        public int m_sendTimes;
        public readonly RawStreamBuffer m_sendBuffer;

        public ToResendBuffer(DateTime sendTime, RawStreamBuffer sendBuffer)
        {
            m_sendTimes = 0;
            m_sendTime = sendTime;
            m_sendBuffer = sendBuffer;
        }
    }

    public class ReliableOrderPeer : PeerBase
    {
        private Dictionary<int, ToResendBuffer> m_sendBufferDic;
        private Queue<ToSendBuffer> m_toSendBufferQueue;
        private Queue<StreamBuffer> m_batchBufferQueue;
        private List<int> m_forceRemoveList;
        private int m_sendBufferLenght;
        protected int m_sendIndex;
        protected int m_recIndex;
        private double m_sendTimeDis;
        private int m_reSendMaxTimes;
        private int m_sendBufferMacCount;

        public ReliableOrderPeer(IPeerListener peerListener, bool batch = false)
            : base(peerListener, batch)
        {
            InitPeer(null);
        }

        protected ReliableOrderPeer(IGameSession iSession, IPeerListener peerListener, bool batch = false)
            : base(peerListener, batch)
        {
            InitPeer(iSession);
        }

        protected void InitPeer(IGameSession iSession)
        {
            m_peerSession = iSession;
            m_toSendBufferQueue = new Queue<ToSendBuffer>();
            m_batchBufferQueue = new Queue<StreamBuffer>();
            m_forceRemoveList = new List<int>();
            m_sendBufferLenght = 0;
            m_sendBufferDic = new Dictionary<int, ToResendBuffer>();
            m_sendIndex = 0;
            m_recIndex = 0;
            m_sendTimeDis = 300.0f;
            m_reSendMaxTimes = 2;
            m_sendBufferMacCount = 20;
        }

        protected override void OnReceivePacket(StreamBuffer sb)
        {
            if (sb.m_protocolHeader.ProtocolID == -2)
            {
                if (m_sendBufferDic.ContainsKey(sb.m_protocolHeader.ErrorCode))
                {
                    m_sendBufferDic.Remove(sb.m_protocolHeader.ErrorCode);
                }
            }
            else if (sb.m_protocolHeader.ProtocolID == -1)
            {
                StreamBuffer sendbuffer = new StreamBuffer(-2, 0);
                sendbuffer.m_protocolHeader.ErrorCode = sb.m_protocolHeader.ErrorCode;
                m_peerSession.Send(sendbuffer);

                if (m_recIndex == sb.m_protocolHeader.ErrorCode)
                {
                    RawStreamBuffer cReceiveBuffer = new RawStreamBuffer(sb.ByteBuffer);
                    ProcessPacket(ref cReceiveBuffer);

                    m_recIndex++;
                }
            }
            else
            {
                m_peerListener.OnPktReceive(sb);
            }
        }

        public override void Connect(string address, int port)
        {
            if (m_peerSession == null)
            {
                m_peerSession = AsynTcpClient.Instance.InstanceSession(this);
            }

            base.Connect(address, port);
        }

        protected override void OnDisconnected()
        {
            m_sendIndex = 0;
            m_recIndex = 0;

            base.OnDisconnected();
        }

        public void Send(DELIVERY_TYPE dType, StreamBuffer sb)
        {
            if (dType == DELIVERY_TYPE.RELIABLE_ORDERED)
            {
                m_sendBufferLenght += sb.GetSendBuffeLength();
                m_batchBufferQueue.Enqueue(sb);
            }
            else
            {
                Send(sb);
            }
        }

        private void ProcessPacket(ref RawStreamBuffer cReceiveBuffer)
        {
            while (cReceiveBuffer.WriteIndex - cReceiveBuffer.ReadIndex >= ProtocolHeader.HeadLength)
            {
                StreamBuffer sb = Packing.GetPacketBufferWithHeader(ref cReceiveBuffer);
                if (sb != null)
                {
                    m_peerListener.OnPktReceive(sb);
                }
                else
                {
                    break;
                }
            }
            //cReceiveBuffer.ClearBuffer();
        }

        public override void ShutDown()
        {
            m_sendIndex = 0;
            m_recIndex = 0;

            base.ShutDown();
        }

        protected override void OnDispatch()
        {
            base.OnDispatch();

            Dictionary<int, ToResendBuffer>.Enumerator iter = m_sendBufferDic.GetEnumerator();
            while (iter.MoveNext())
            {
                DateTime currentTime = DateTime.Now;
                if ((currentTime - iter.Current.Value.m_sendTime).TotalMilliseconds > m_sendTimeDis)
                {
                    m_peerSession.Send(iter.Current.Value.m_sendBuffer);
                    iter.Current.Value.m_sendTime = currentTime;
                    iter.Current.Value.m_sendTimes++;
                    if(iter.Current.Value.m_sendTimes >= m_reSendMaxTimes)
                    {
                        m_forceRemoveList.Add(iter.Current.Key);
                    }
                }
            }

            if(m_forceRemoveList.Count > 0)
            {
                for(int index = 0; index < m_forceRemoveList.Count; index++)
                {
                    m_sendBufferDic.Remove(m_forceRemoveList[index]);
                }
                m_forceRemoveList.Clear();
            }

            if (m_batchBufferQueue.Count > 0)
            {
                ProtocolHeader ph = new ProtocolHeader(-1, m_sendIndex++, m_sendBufferLenght);
                RawStreamBuffer rsb = new RawStreamBuffer(ProtocolHeader.HeadLength + m_sendBufferLenght);
                rsb.WriteBuffer(ph.GetHeaderStream(), ProtocolHeader.HeadLength);
                while (m_batchBufferQueue.Count > 0)
                {
                    StreamBuffer buffer = m_batchBufferQueue.Dequeue();
                    rsb.WriteBuffer(buffer);
                }
                m_toSendBufferQueue.Enqueue(new ToSendBuffer(ph.ErrorCode, rsb));

                m_sendBufferLenght = 0;
            }

            while (m_toSendBufferQueue.Count > 0)
            {
                if (m_sendBufferDic.Count < m_sendBufferMacCount)
                {
                    ToSendBuffer buffer = m_toSendBufferQueue.Dequeue();
                    m_peerSession.Send(buffer.m_sendBuffer);
                    m_sendBufferDic.Add(buffer.m_sendIndex, new ToResendBuffer(DateTime.Now, buffer.m_sendBuffer));
                }
				else
				{
					break;
				}
            }
        }
    }
}