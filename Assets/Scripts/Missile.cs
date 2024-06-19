using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public GameObject[] enemies;
    public GameObject missile;
    public GameObject plus3;
    public GameObject ball;
    public GameObject enemyGuidance = null;
    public Transform enemyTransform;
    public GameObject killParticle;
    public GameObject destroyParticle;
    private Upgrades upgrades;
    private float closest = Mathf.Infinity;
    public bool destroy = false;

    private void Awake()
    {
        upgrades = GameObject.Find("GameLogic").GetComponent<Upgrades>();
        Invoke("DestroySelf", 6);
        ball = GameObject.Find("Ball");
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            float distance = (enemy.transform.position - transform.position).sqrMagnitude;
            if (distance < closest && enemy.name != "Boss(Clone)" && enemy.transform.position.y > transform.position.y)
            {
                closest = distance;
                enemyGuidance = enemy;
                enemyTransform = enemyGuidance.transform;
            }
        }
        
    }
    private void Update()
    {
        if(enemyGuidance == null || enemyTransform.position == null)
        {
            closest = Mathf.Infinity;
            enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject enemy in enemies)
            {
                float distance = (enemy.transform.position - transform.position).sqrMagnitude;
                if (distance < closest && enemy.name != "Missile(CLone)")
                {
                    closest = distance;
                    enemyGuidance = enemy;
                    enemyTransform = enemyGuidance.transform;
                }
            }
        }
    }
    private void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, enemyTransform.position, 5* Time.deltaTime);
        transform.rotation = Quaternion.Euler(0f, 0f, Mathf.Rad2Deg * Mathf.Atan2(enemyTransform.position.y - transform.position.y, enemyTransform.position.x - transform.position.x));
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            if(collision.name == "Enemy Missile(Clone)")
            {
                int i = Random.Range(0, 100);
                if(i <= GameObject.Find("GameLogic").GetComponent<Upgrades>().missileBounceChance)
                {
                    Instantiate(missile, transform.position, Quaternion.identity);
                }
                else if(upgrades.missileConvertEnabled)
                {
                    Instantiate(missile, transform.position, Quaternion.identity);
                }
            }
            Destroy(collision.gameObject);
            Instantiate(killParticle, collision.transform.position, Quaternion.identity);
            Instantiate(destroyParticle, transform.position, Quaternion.identity);
            GameObject.Find("GameLogic").GetComponent<GameLogic>().counter += 3;
            GameObject.Find("Spawner").GetComponent<Spawning>().timer += 3;
            Instantiate(plus3, new Vector2(0, 0.7f), Quaternion.identity,ball.transform);
            Destroy(gameObject);
        }
    }
    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
