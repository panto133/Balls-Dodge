using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearAttack : MonoBehaviour
{
    GameLogic gameLogic;
    public Rigidbody2D rb;
    public float speed;
    float rotZ = 315f;
    [SerializeField]
    bool change = false;

    private void Awake()
    {
        gameLogic = GameObject.Find("GameLogic").GetComponent<GameLogic>();
    }
    private void Update()
    {
        if (rotZ >= 225f && !change)
        {
            rotZ -= Time.deltaTime * speed;
        }
        else if(rotZ <= 315f && change)
        {
            rotZ += Time.deltaTime * speed;
        }
        if (rotZ <= 225f && transform.position.x <= -1.4f)
        {
            change = true;
        }        
        else if(rotZ >= 315f && transform.position.x >= 1.4f)
        {
            change = false;
        }
        rb.velocity = transform.right * speed * Time.deltaTime;
        transform.rotation = Quaternion.Euler(0, 0, rotZ);
    }
}
