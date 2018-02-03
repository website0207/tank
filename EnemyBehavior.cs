using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : Character {
    public int enemy_number;
    GameObject player;
    public float limited_time_direction;
    public float limited_time_fire;
    const float firetime_maxvalue = 1.5f;
    const float directiontime_maxvalue = 2.0f;
    public bool is_chasing = false;
    public GameObject map;
    // Use this for initialization
    public override void Start () {
        enemy_number = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Map>().EnemyCount;
        moveSpeed = 1;
        limited_time_direction = directiontime_maxvalue;
        limited_time_fire = firetime_maxvalue;
	}
	
	// Update is called once per frame
	public override void Update () {
        //行动逻辑为，如果没发现玩家，随机乱逛；如果发现玩家，追到地老天荒
        if (is_chasing)
        {

        }
        else
        {
            transform.Translate(transform.up * moveSpeed * Time.deltaTime, Space.World);
            limited_time_direction -= Time.deltaTime;
            limited_time_fire -= Time.deltaTime;

            //用于追踪状态切换检测
            //探测长度需要手动调整
            RaycastHit2D[] results_player = new RaycastHit2D[1];
            int num_player = gameObject.GetComponent<Collider2D>().Raycast(transform.up, results_player, 2.0f, 1 << LayerMask.GetMask("Default"));
            if (num_player > 0)
            {
                is_chasing = true;
                player = results_player[0].collider.gameObject;
                //这个位置有问题，我在考虑如何解决，把敌方坦克的碰撞体变小？
                //list_path.Add(player.transform.position);
                //Debug.Log("find player");
            }

            if (limited_time_direction < 0 || gameObject.GetComponent<Collider2D>().IsTouchingLayers(1 << LayerMask.GetMask("Unpassable")))
            {
                limited_time_direction = directiontime_maxvalue;
                transform.Rotate(new Vector3(0, 0, 90 * Random.Range(0, 4)));
            }
            if (limited_time_fire < 0)
            {
                limited_time_fire = firetime_maxvalue;
                Fire();
            }
        }
    }
    /// <summary>
    /// 将对象向指定目标移动
    /// </summary>
    /// <param name="destination">目标点坐标</param>
    private void MoveToPosition(Vector3 destination)
    {
        float angle = Vector3.Angle(transform.rotation.eulerAngles, destination - transform.position);
        Vector3 rotateVector;
        if (Mathf.Abs(angle - 0) < 45)
        {
            rotateVector = Vector3.zero;
        }
        else if (Mathf.Abs(angle - 90) < 45)
        {
            rotateVector = new Vector3(0, 0, 90);
        }
        else if (Mathf.Abs(angle - 180) < 45)
        {
            rotateVector = new Vector3(0, 0, 180);
        }
        else
        {
            rotateVector = new Vector3(0, 0, 270);
        }
        transform.Rotate(rotateVector);
        transform.Translate(transform.up * moveSpeed * Time.deltaTime, Space.World);
    }
    /// <summary>
    /// 判断当前对象是否走到了指定位置
    /// </summary>
    /// <param name="position">目标位置</param>
    /// <returns>布尔值</returns>
    private bool IsAtSamePosition(Vector3 position)
    {
        float distance = Vector3.Distance(transform.position, position);
        //此处阈值设为0.1，但是实际情况未知
        return distance < 0.1f;
    }
}
