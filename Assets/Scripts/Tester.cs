using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tester : MonoBehaviour
{
    public GameObject mis;
    public GameObject par;
    float timer;
    private void Update()
    {
        timer += Time.deltaTime;
        if(timer >= .5f)
        {
            Instantiate(mis, new Vector3(0f,6f, 10f), Quaternion.identity);
            timer = 0;
        }
    }
}
