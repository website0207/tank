using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMissile : BaseMissile {
    public override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        switch (collision.gameObject.tag)
        {
            case "Player":
                Destroy(collision.gameObject);
                Destroy(gameObject);
                break;
            default:
                break;
        }
    }

}
