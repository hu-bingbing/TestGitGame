//  Dispatch.cs
//  Nilsen
//  2015-04-09
using System.Collections.Generic;

namespace NetWrapper.Network
{
    /// <summary>
    /// 调度类
    /// </summary>
    public abstract class DispatchBase
    {
        protected ISessionListener m_sessionListener;
        private Queue<StreamBuffer> m_cReceiveQueue = new Queue<StreamBuffer>();
        private Queue<StreamBuffer> m_cDispatchQueue = new Queue<StreamBuffer>();

        public DispatchBase(ISessionListener sessionListener)
        {
            this.m_sessionListener = sessionListener;
            this.m_cReceiveQueue = new Queue<StreamBuffer>();
            this.m_cDispatchQueue = new Queue<StreamBuffer>();
        }

        /// <summary>
        /// 连接事件
        /// </summary>
        public virtual void OnConnect()
        {
            m_sessionListener.OnConnect();
        }
        public void SetSessionListener(ISessionListener sessionListener)
        {
            m_sessionListener = sessionListener;
        }
        /// <summary>
        /// 断开连接事件
        /// </summary>
        public virtual void OnDisconnect()
        {
            m_sessionListener.OnDisconnect();
        }

        /// <summary>
        /// 接受消息
        /// </summary>
        /// <param name="pb"></param>
        public virtual void AckPacket(StreamBuffer sb)
        {
            lock (this.m_cReceiveQueue)
            {
                this.m_cReceiveQueue.Enqueue(sb);
            }
        }

        /// <summary>
        /// 逻辑更新
        /// </summary>
        /// <returns></returns>
        public virtual void Update()
        {
            if(this.m_cReceiveQueue.Count > 0)
            {
                lock (this.m_cReceiveQueue)
                {
                    Queue<StreamBuffer> tempQueue = m_cDispatchQueue;
                    m_cDispatchQueue = m_cReceiveQueue;
                    m_cReceiveQueue = tempQueue;
                }
            }

            while(this.m_cDispatchQueue.Count > 0)
            {
                StreamBuffer sb = this.m_cDispatchQueue.Dequeue();
                m_sessionListener.OnPktReceive(sb);
            }

            m_sessionListener.OnDispatch();
        }
    }
}