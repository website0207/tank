using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Explosion : MonoBehaviour {
    public float live_time = 0.7f;
	// Use this for initialization
	void Start () {
        //这种写法相当于建立了一个可以自销毁的游戏对象，但是这并不是一个好方法
        //Destroy(gameObject, live_time);
        //Debug.Log("111");


	}

    //利用时间对延时进行重构，unity中Action对应c#的Event
    //public GameObject go;
    //public Action OnTimeupEvent;


}
