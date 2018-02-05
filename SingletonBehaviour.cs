using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
//单例模式的实现
public class SingletonBehaviour<T> : MonoBehaviour where T : Component
{
    protected static T _instance;

    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                //如果这个组件存在，找到它
                _instance = FindObjectOfType<T>();
                if (_instance == null)
                {
                    GameObject obj = new GameObject();
                    _instance = obj.AddComponent<T>();
                }
            }

            return _instance;
        }
    }

    /// <summary>
    /// Awake只调用一次，在脚本实例加载时执行
    /// </summary>
    public virtual void Awake()
    {
        DontDestroyOnLoad(gameObject);
        name = "_" + typeof(T).Name;
        //可能会有问题，会和跨场景有关？
        //if (_instance == null)
        //{
        //    _instance = this as T;
        //}
        //else
        //{
        //    Destroy(gameObject);
        //}
    }
}
