using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleObstacleMovement : MonoBehaviour
{
    public GameLogic gameLogic;
    Rigidbody2D rb;
    public bool goRight = true;
    public bool change = false;
    private float speed;

    private void Awake()
    {
        speed = SpeedGuidance.GetSpeed();
        rb = GetComponent<Rigidbody2D>();
        gameLogic = GameObject.Find("GameLogic").GetComponent<GameLogic>();
    }
    private void Start()
    {
        Invoke("Destroy", 10);
        float relation = (float)Screen.height / Screen.width;
        float percentage = (float)relation / 2f;
        float modifierX = transform.localScale.x / percentage;
        float modifierY = transform.localScale.y / percentage;
        transform.localScale = new Vector3(modifierX, modifierY, transform.localScale.z);
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector3(rb.velocity.x, -speed * Time.fixedDeltaTime, 0f);
        if (transform.position.x < 1.8f && !change)
        {
            goRight = true;
        }
        else if (transform.position.x > 1.8f)
        {
            goRight = false;
        }
        if (transform.position.x > 1.8f)
        {
            change = true;
        }
        else if (transform.position.x < -1.8f)
        {
            change = false;
        }
        if(goRight)
        {
            rb.velocity = new Vector3(speed * Time.fixedDeltaTime, rb.velocity.y, 0f);
        }
        else
        {
            rb.velocity = new Vector3(-speed * Time.fixedDeltaTime, rb.velocity.y, 0f);

        }
    }
    public void Destroy()
    {
        Destroy(gameObject);
    }
}
