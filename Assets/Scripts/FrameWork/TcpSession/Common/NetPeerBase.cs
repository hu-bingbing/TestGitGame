using System.Collections.Generic;

namespace NetWrapper.Network
{
    public interface IPeerListener
    {
        void OnConnected();
        void OnDisconnected();
        void OnPktReceive(StreamBuffer sb); //�����հ�
    }
    public interface IPeer
    {
        void Connect(string address, int port);
        void Disconnect();
        void Send(StreamBuffer sb);
    }
    public abstract class PeerBase : IPeer, ISessionListener, System.IDisposable
    {
        protected IPeerListener m_peerListener;
        protected IGameSession m_peerSession;
        private Queue<StreamBuffer> m_sendBufferQueue;
        private int m_sendBufferLenght;
        protected bool m_batch;

        public PeerBase(IPeerListener peerListener, bool batch)
        {
            m_batch = batch;
            m_peerListener = peerListener;
            m_peerSession = null;
            m_sendBufferQueue = new Queue<StreamBuffer>();
            m_sendBufferLenght = 0;
        }
        protected void SetPeerListener(IPeerListener peerListener)
        {
            m_peerListener = peerListener;
        }
        public void SetBufferBatch(bool batch)
        {
            m_batch = batch;
        }
        protected bool SendBatchBuffer(RawStreamBuffer toSendBuffer)
        {
            byte[] tmpBytes = toSendBuffer.GetCopyOfContent();
            if (tmpBytes != null)
            {
                RawStreamBuffer tempBuffer = new RawStreamBuffer(tmpBytes);
                m_peerSession.Send(tempBuffer);

                return true;
            }
            return false;
        }

        #region PeerBase
        protected virtual void OnConnected()
        {
            m_peerListener.OnConnected();
        }
        protected virtual void OnDisconnected()
        {
            m_peerListener.OnDisconnected();
        }
        protected virtual void OnReceivePacket(StreamBuffer sb)
        {
            m_peerListener.OnPktReceive(sb);
        }
        protected virtual void OnDispatch()
        {
            if (m_batch)
            {
                if (m_sendBufferQueue.Count > 0)
                {
                    RawStreamBuffer rsb = new RawStreamBuffer(m_sendBufferLenght);
                    while (m_sendBufferQueue.Count > 0)
                    {
                        StreamBuffer buffer = m_sendBufferQueue.Dequeue();
                        rsb.WriteBuffer(buffer);
                    }

                    // assert m_sendBufferLenght == rsb.ContentSize;
                    m_peerSession.Send(rsb);

                    m_sendBufferLenght = 0;
                }
            }
        }
        #endregion

        #region IPeer
        public virtual void Connect(string address, int port)
        {
            if (m_peerSession != null)
            {
                m_peerSession.Connect(address, port);
            }
        }
        // ����ֵ����ʶ����������������Ƿ�ɹ�
        public virtual bool Reconnect()
        {
            if (m_peerSession != null)
            {
                return m_peerSession.Reconnect();
            }

            return false;
        }
        public virtual void Disconnect()
        {
            if (m_peerSession != null)
            {
                m_peerSession.DisConnect();
            }
        }

        public virtual void ShutDown()
        {
            if (m_peerSession != null)
            {
                m_peerSession.ShutDown();

                AsynTcpClient.Instance.RemoveSession(m_peerSession.GetSessionID());
                m_peerSession = null;
            }
        }
        public virtual void Send(StreamBuffer sb)
        {
            if (m_batch)
            {
                m_sendBufferLenght += sb.GetSendBuffeLength();
                m_sendBufferQueue.Enqueue(sb);
            }
            else
            {
                m_peerSession.Send(sb);
            }
        }
        #endregion

        #region ISessionListener
        void ISessionListener.OnConnect()
        {
            OnConnected();
        }
        void ISessionListener.OnDisconnect()
        {
            OnDisconnected();
        }
        void ISessionListener.OnPktReceive(StreamBuffer sb)
        {
            OnReceivePacket(sb);
        }
        void ISessionListener.OnDispatch()
        {
            OnDispatch();
        }
		#endregion
		public void Dispose()
		{
			ShutDown();
		}
		~PeerBase()
		{
			Dispose();
		}
	}
}