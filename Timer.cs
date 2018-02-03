using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Timer : SingletonBehaviour<Timer>
{
    //不知道用来做什么的词典
    //public Dictionary<GameObject, float> dictGameObject;

    public List<TimeEvent> listTimeEvent;
    //为什么要用迭代器
    public List<TimeEvent>.Enumerator enumTimeEvent;

    //不知道用来做什么的列表
    //public List<TimeEvent> listTimeup;

    private Timer()
    {
        //this.dictGameObject = new Dictionary<GameObject, float>();
        listTimeEvent = new List<TimeEvent>();
        //listTimeup = new List<TimeEvent>();
    }
    // Use this for initialization
	void Start () {
		
	}
    //固定时间刷新，在Update函数之前执行
    private void FixedUpdate()
    {
    //    enumTimeEvent = listTimeEvent.GetEnumerator();
    //    while (enumTimeEvent.MoveNext())
    //    {
    //        if (enumTimeEvent.Current != null)
    //        {
    //            enumTimeEvent.Current.UpdateCurrentTime();
    //        }
    //    }
    }
    // Update is called once per frame
    void Update () {
		
	}
    //将计时器加入资源管理器中
    public void AddTimer(TimeEvent timeEvent, float duration, Action callBack)
    {
        //如果不包含这个timeEvent
        if (!listTimeEvent.Contains(timeEvent))
        {
            timeEvent.OnTimeupEvent = callBack;
            timeEvent.HandleData(timeEvent.gameObject, duration);
            listTimeEvent.Add(timeEvent);
        }
        //已经存在就将其销毁？
        else
        {
            Destroy(timeEvent);
        }
    }
    //将计时器从资源管理器中移除
    public void RemoveTimer(TimeEvent timeEvent)
    {
        listTimeEvent.Remove(timeEvent);
    }
}
