using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : Character {

    Vector3 last_position;
    Vector3 last_rotation;
    const float min_trigger_dist = 0.5f;
	// Use this for initialization
	public override void Start () {
        moveSpeed = 1;
        last_position = Vector3.zero;
        last_rotation = Vector3.zero;
	}
	
	// Update is called once per frame
	public override void Update () {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        //防止坦克斜着走
        if (h != 0)
        {
            v = 0;
        }
      
        if (v > 0)
        {
            transform.eulerAngles = Vector3.zero;
        }
        if (h > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, -90);
        }
        if (v < 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 180);
        }
        if (h < 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 90);
        }
        //记录转角时位置
        if (last_position != transform.eulerAngles && Vector3.Distance(transform.position, last_position) > min_trigger_dist)
        {
            if (list_path.Count > 1000)//将列表限定在1000以下
            {
                list_path.RemoveAt(0);
            }
            list_path.Add(transform.position);
            last_position = transform.position;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Fire();
        }
        transform.Translate(moveSpeed * new Vector3(h, v, 0) * Time.deltaTime, Space.World);
	}
    
}
