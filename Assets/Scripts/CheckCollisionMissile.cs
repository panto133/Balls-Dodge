using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollisionMissile : MonoBehaviour
{
    Upgrades upgrades;
    GameLogic gameLogic;
    GameObject GLGO;
    int collidingNum = 0;

    private void Awake()
    {
        GLGO = GameObject.Find("GameLogic");
        gameLogic = GLGO.GetComponent<GameLogic>();
        upgrades = GLGO.GetComponent<Upgrades>();
    }
    private void Update()
    {
        if(collidingNum == 2)
        {
            upgrades.ShieldPower();

            if(!upgrades.invincible)
                gameLogic.ResetGame();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            if (collision.CompareTag("Player"))
            {
                collidingNum++;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other != null)
        {
            if (other.CompareTag("Player"))
            {
                collidingNum--;
            }
        }
    }
}