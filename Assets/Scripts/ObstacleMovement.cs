using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    public float speed;

    public GameObject spike;
    public GameLogic gameLogic;
    private Rigidbody2D rb;

    private void Awake()
    {
        speed = SpeedGuidance.GetSpeed();
        rb = GetComponent<Rigidbody2D>();
        gameLogic = GameObject.Find("GameLogic").GetComponent<GameLogic>();
    }
    private void Start()
    {
        Invoke("Destroy", 6);
        float relation = (float)Screen.height / Screen.width;
        float percentage = (float)relation / 2f;
        float modifierX = transform.localScale.x / percentage;
        float modifierY = transform.localScale.y / percentage;
        transform.localScale = new Vector3(modifierX, modifierY, transform.localScale.z);
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector3(0f, -speed * Time.fixedDeltaTime, 0f);
    }
    public void Destroy()
    {
        Destroy(gameObject);
    }
}
