using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{

    public float defaultSpeed;
    public float speed;
    public bool start = false;
    public bool isFirst = false;
    Rigidbody2D rb;
    private void Awake()
    {
        speed = defaultSpeed;
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        float relation = (float)Screen.height / Screen.width;
        float percentage = (float)relation / 2f;
        float modifierX = transform.localScale.x / percentage;
        transform.localScale = new Vector3(modifierX, transform.localScale.y, transform.localScale.z);
    }
    private void Update()
    {
        if (start && speed <= 255f)
        {
            speed += Time.deltaTime;
            SpeedGuidance.TakeSpeed(speed);
            
        }
    }
    void FixedUpdate()
    {
        rb.velocity = new Vector2(0f, -speed * Time.fixedDeltaTime);
        if (transform.position.y <= -8.64f)
        {
            transform.position = new Vector2(transform.position.x, 11.36f);
        }
    }
    public void ResetPosition()
    {
        switch(gameObject.name)
        {
            case "Left Spikes":
            case "Right Spikes":
                transform.localPosition = new Vector3(0.5f, 10f, 0f);
                break;
            case "Left Spikes (1)":
            case "Right Spikes (1)":
                transform.localPosition = new Vector3(0.5f, 0f, 0f);
                break;
            case "Left Spikes (2)":
            case "Right Spikes (2)":
                transform.localPosition = new Vector3(0.5f, 10f, 0f);
                break;
            case "Left Spikes (3)":
            case "Right Spikes (3)":
                transform.localPosition = new Vector3(0.5f, 0f, 0f);
                break;
        }
    }
}
