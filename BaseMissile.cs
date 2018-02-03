using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMissile : MonoBehaviour {
    //子弹移动速度
    public float moveSpeed = 10;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(moveSpeed * Time.deltaTime * Vector3.up);
	}

    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Wall":
            case "Bullet":
                Destroy(collision.gameObject);
                Destroy(gameObject);
                break;
            case "Wall_Iron":
                Destroy(gameObject);
                break;
            default:
                break;
        }
    }
}
