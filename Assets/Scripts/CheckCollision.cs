using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollision : MonoBehaviour
{
    GameLogic gameLogic;
    Upgrades upgrades;

    private void Awake()
    {
        gameLogic = GameObject.Find("GameLogic").GetComponent<GameLogic>();
        upgrades = GameObject.Find("GameLogic").GetComponent<Upgrades>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision != null)
        {
            if (collision.CompareTag("Player"))
            {
                upgrades.ShieldPower();              
                if (!upgrades.invincible)
                {
                    gameLogic.ResetGame();
                }
            }
        }
    }
}
