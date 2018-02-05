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
	}
    private void OnEnable()
    {
        Invoke("Destroy", 1.5f);
    }

    private void Destroy()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        //使用这个函数的原因在于可以上面的Invoke函数是有延时的
        //这种做法可以保证直接结束调用
        //而不会使其在被停止使用时被停止使用两次
        CancelInvoke();
    }
}
