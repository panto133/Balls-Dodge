using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperSpike : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed = 500f;
    GameLogic gameLogic;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        gameLogic = GameObject.Find("GameLogic").GetComponent<GameLogic>();
        Invoke("Destroy", 5);
    }
    private void FixedUpdate()
    {
        speed = 700;
        rb.velocity = new Vector3(0, -speed * Time.fixedDeltaTime, 0);


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gameLogic.ResetGame();
        }
    }
    public void Destroy()
    {
        Destroy(gameObject);
    }
}
