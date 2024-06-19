using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpTetrahedrons : MonoBehaviour
{
    GameLogic gameLogic;
    DeathScreen deathScreen;
    GameObject[] enemies;
    public GameObject particle;
    private float speed;
    Rigidbody2D rb;
    private void Awake()
    {
        Invoke("DestroySelf", 6);
        gameLogic = GameObject.Find("GameLogic").GetComponent<GameLogic>();
        deathScreen = GameObject.Find("DeathScreen").GetComponent<DeathScreen>();
        rb = GetComponent<Rigidbody2D>();
        speed = SpeedGuidance.GetSpeed();
    }
    private void Start()
    {
        GameObject closestObject = null;
        enemies = GameObject.FindGameObjectsWithTag("Enemy");           
        float distance;
        float closest = Mathf.Infinity;
        foreach (GameObject enemy in enemies)
        {
            distance = (enemy.transform.position - transform.position).sqrMagnitude;

            if (distance < closest)
            {
                closest = distance;
                closestObject = enemy;
            }
        }
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector3(0f, - speed * Time.fixedDeltaTime, 0f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            gameLogic.tetrahedrons += 1;
            deathScreen.PickedTetrahedron();
            Instantiate(particle, transform.position, Quaternion.identity);
            Destroy(gameObject);           
        }
    }
    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
