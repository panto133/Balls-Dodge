using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMissile : MonoBehaviour
{
    GameLogic gameLogic;
    public Transform player;
    public int count = 0;

    private void Awake()
    {
        gameLogic = GameObject.Find("GameLogic").GetComponent<GameLogic>();
        player = GameObject.Find("Ball").GetComponent<Transform>();       
    }
    private void Start()
    {
        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, -10f);
    }
    private void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, 2 * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, transform.position.y, -3f);
        transform.rotation = Quaternion.Euler(0f, 0f, Mathf.Rad2Deg * Mathf.Atan2(player.position.y - transform.position.y, player.position.x - transform.position.x) + 90);
    }
}
