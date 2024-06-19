using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    MissileShooting missileShooting;
    GameLogic gameLogic;
    GameObject[] enemies;
    [HideInInspector]
    private float speed;
    Rigidbody2D rb;
    private void Awake()
    {
        Invoke("Destroy", 10);
        gameLogic = GameObject.Find("GameLogic").GetComponent<GameLogic>();
        rb = GetComponent<Rigidbody2D>();
        missileShooting = GameObject.Find("Missile Shooting").GetComponent<MissileShooting>();
        speed = SpeedGuidance.GetSpeed();
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector3(0f, -speed * Time.deltaTime, 0f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            missileShooting.missileAmmo++;
            Destroy(gameObject);           
        }
    }
    private void Destroy()
    {
        Destroy(gameObject);
    }
}
