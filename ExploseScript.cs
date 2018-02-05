using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExploseScript : MonoBehaviour {

    //public float 
    public GameObject explosion;
    //对对象池的大小进行限定
    public int pooledAmount = 5;
    List<GameObject> explosions;
	// Use this for initialization
	void Start () {
        explosions = new List<GameObject>();
        for (int i = 0; i < pooledAmount; i++)
        {
            GameObject obj = (GameObject)Instantiate(explosion);
            obj.SetActive(false);
            explosions.Add(obj);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
