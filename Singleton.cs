using System;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 非继承自MonoBehaviour的单例对象继承此类，比如资源管理器等等
/// </summary>
public class Singleton<T> where T : class
{
    private static T _instance;
    private static readonly object syslock = new object();
    //tips：这个是为了作为参数传入函数中，当并不想利用其储存什么数据时，使其长度为0就行。
    public static readonly Type[] emptyTypes = new Type[0];

    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                //保证创建的过程是单位操作
                lock (syslock)
                {
                    if (_instance == null)
                    {
                        //ci的作用是为了确定构造函数是否为private
                        ConstructorInfo ci = typeof(T).GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null, emptyTypes, null);
                        if (ci == null)
                        {
                            throw new InvalidOperationException("class must contain a private constructor");
                        }
                        //ci为构造函数信息，用ci可以调用构造函数信息
                        _instance = (T)ci.Invoke(null);
                    }
                }
            }
            return _instance;
        }
    }
}
