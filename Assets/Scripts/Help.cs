using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Help : MonoBehaviour
{
    public GameObject tap;
    public GameObject circle;

    private float counter;

    private bool change = true;

    private float scaler;

    private void Start()
    {
        StartCoroutine(Blink());
        scaler = Time.deltaTime;
        circle.transform.localScale = new Vector2(2,2);
        Invoke("DestroySelf", 4f);
        transform.localPosition = new Vector3(0f, 0f, 0f);
    }

    private void FixedUpdate()
    {
        if (change)
        {
            circle.transform.localScale += new Vector3(scaler, scaler, 0);
        }
        
        else
        {
            circle.transform.localScale -= new Vector3(scaler, scaler, 0);
        }
        if (circle.transform.localScale.x >= 2.5f)
        {
            change = false;
        }
        else if (circle.transform.localScale.x <= 2f)
        {
            change = true;
        }

    }
    IEnumerator Blink()
    {
        while(true)
        {
            tap.SetActive(true);
            yield return new WaitForSeconds(.5f);
            tap.SetActive(false);
            yield return new WaitForSeconds(.5f);
        }
    }
    private void DestroySelf()
    {
        Destroy(gameObject);
    }
}
