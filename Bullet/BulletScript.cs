using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {
    public float speed = 10;
	
	// Update is called once per frame
	void Update () {
        transform.Translate(speed * Time.deltaTime * transform.up);
	}
}
