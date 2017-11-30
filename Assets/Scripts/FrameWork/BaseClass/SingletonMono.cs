﻿using UnityEngine;
using System.Collections;

public class SingletonMono<T> : MonoBehaviour where T : MonoBehaviour
{
    protected static T _instance;

    public static T Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = FindObjectOfType<T>();
                if(_instance != null)
                {
                    return _instance;
                }
                GameObject go = new GameObject(typeof(T).ToString());
                _instance = go.AddComponent<T>();
            }
            return _instance;
        }
    }

    //public virtual void Awake()
    //{
    //    if (_instance == null)
    //    {
    //        //If I am the first instance, make me the Singleton
    //        _instance = this.GetComponent<T>();
    //        DontDestroyOnLoad(this);
    //    }
    //    else
    //    {
    //        //If a Singleton already exists and you find
    //        //another reference in scene, destroy it!
    //        if (this != _instance)
    //            Destroy(this.gameObject);
    //    }
    //}
}
