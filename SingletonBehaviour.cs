using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
                //此处不使用GetComponent<T>()的原因在于这个类并不是挂在某个游戏对象上的?
                //如果这个组件存在，找到它
                _instance = FindObjectOfType<T>();
                if (_instance = null)
                {
                    //否则，创建它
                    //但是这个新创建的游戏对象是什么？

                    GameObject obj = new GameObject();
                    _instance = obj.AddComponent<T>();
                }
            }

            return _instance;
        }
    }
}
