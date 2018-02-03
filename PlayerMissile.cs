using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMissile : BaseMissile {

    public GameObject explosion_obj;
    //选定音频文件，相当于选定唱片
    public AudioClip audio_die;
    //爆炸效果的倍率
    const float explosion_rate = 1.5f;
    public override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        switch (collision.gameObject.tag)
        {
            case "Enemy":
                GameObject go = Instantiate(explosion_obj, collision.transform.position, Quaternion.identity);
                go.SetActive(true);
                go.transform.localScale = explosion_rate * Vector3.one;
                //添加音频组件
                AudioSource audio = go.AddComponent<AudioSource>();

                if (audio != null)
                {
                    audio.clip = audio_die;
                    audio.Play();
                }

                Destroy(collision.gameObject);
                Destroy(gameObject);

                break;
                
            default:
                break;
        }
    }
}
