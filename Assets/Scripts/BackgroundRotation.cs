using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundRotation : MonoBehaviour
{
    public RectTransform rt;
    public float rotationY = 0;
    public float rotationZ = 0;

    private bool change = true;

    public float speedY = 10f;
    public float speedZ = 5f;

    private void FixedUpdate()
    {
        if(rotationY >= -40f && change)
        {
            rotationY -= Time.deltaTime * speedY;
        }
        else
        {
            rotationY += Time.deltaTime * speedY;
        }
        if(rotationY >= 40f)
        {
            change = true;
        }
        else if(rotationY <= -40f)
        {
            change = false;
        }

        rotationZ += Time.deltaTime * speedZ;
        rt.rotation = Quaternion.Euler(0, rotationY, rotationZ);
    }
}
