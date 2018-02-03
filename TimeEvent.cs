using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class TimeEvent : MonoBehaviour {
    //判断该事件是否被删除
    //public bool isDeleted = false;
    public GameObject obj;
    public Action OnTimeupEvent;
    public float durationTime = 0;
    //private float currentTime = 0.0f;
    //public float CurrentTime
    //{
    //    get
    //    {
    //        return currentTime;
    //    }
    //    set
    //    {
    //        currentTime = value;
    //        if (currentTime >= durationTime && OnTimeupEvent != null)
    //        {
    //            OnTimeupEvent();
    //            OnTimeupEvent = null;
    //            //isDeleted = true;
    //        }
    //    }
    //}

    //原本的方式是用轮询的方式对列表中的timer进行管理，但是这种方式并不好
    //Invoke函数就可以自己对自己的时间进行管理
    public void HandleData(GameObject obj, float duration)
    {
        this.obj = obj;
        durationTime = duration;
        Invoke("InvokeCallBack", duration);
    }
    public void InvokeCallBack()
    {
        if (OnTimeupEvent != null)
        {
            OnTimeupEvent();
            OnTimeupEvent = null;
        }
    }
    
    //public void UpdateCurrentTime()
    //{
    //    currentTime += Time.deltaTime;
    //}
}
