using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeletingEnemies : MonoBehaviour
{
    private GameObject[] obstacles;

    public void DeletingObstacles()
    {
        obstacles = GameObject.FindGameObjectsWithTag("Enemy");
        for(int i = 0; i < obstacles.Length; i ++)
        {
            Destroy(obstacles[i]);
        }
        obstacles = GameObject.FindGameObjectsWithTag("EnemyMissile");
        for (int i = 0; i < obstacles.Length; i++)
        {
            Destroy(obstacles[i]);
        }
        obstacles = GameObject.FindGameObjectsWithTag("Missile");
        for (int i = 0; i < obstacles.Length; i++)
        {
            Destroy(obstacles[i]);
        }
    }
}
