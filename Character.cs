using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {
    //角色移动速度
    public float moveSpeed;
    //角色旋转角度，默认设定为上
    public Vector3 rotationAngle;
    //子弹本体
    public GameObject bullet;
    //行动路径，如果在player中则是记录路径，如果在enemy中则是行动路径
    public List<Vector3> list_path;

    public virtual void Start() {
        list_path = new List<Vector3>();
    }

    public virtual void Update() { }

    public virtual void Fire()
    {
        GameObject missile_clone = Instantiate(bullet, transform.position, Quaternion.Euler(transform.eulerAngles));
        missile_clone.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall_Water")
        {
            moveSpeed /= 2;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall_Water")
        {
            moveSpeed *= 2;
        }
    }
}
