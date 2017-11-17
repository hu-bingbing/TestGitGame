using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCls : IUpdate
{
    private bool m_enabled = true;

    public bool enabled
    {
        get { return m_enabled; }
        set
        {
            if(m_enabled != value)
            {
                m_enabled = value;
                if (m_enabled)
                {

                }
            }
        }
    }

    private bool m_updateEnabled = false;

    public virtual bool updateEnabled
    {
        get { return m_updateEnabled; }
        set
        {
            if(m_updateEnabled != value)
            {
                m_updateEnabled = value;
                if (m_updateEnabled)
                {
                    
                }
            }
        }
    }

    protected int m_interval = 1;
    public int interval
    {
        get{ return m_interval; }
        set
        {
            m_interval = value;
        }
    }
    private float m_intervalTime = -1;

    protected float intervalTime
    {
        get { return m_intervalTime; }
        set
        {
            if(value > 0)
            {
                m_intervalTime = value;
                m_interval = 1;
            }
        }
    }
    private float m_lastUpdateTime = 0;
    private List<int> eventList = new List<int>();
    private List<uint> callLaterList = new List<uint>();

    private List<string> timerList = new List<string>();

    private List<TimeData> clockList = new List<TimeData>();

    private void EventHandler(int type,object data = null)
    {

    }

    public void update()
    {
        throw new NotImplementedException();
    }
    
}
