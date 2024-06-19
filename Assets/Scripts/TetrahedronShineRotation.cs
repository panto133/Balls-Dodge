using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrahedronShineRotation : MonoBehaviour
{
    float rot;
    private void FixedUpdate()
    {
        rot += Time.deltaTime * 60f;
        transform.rotation = Quaternion.Euler(0f, 0f, rot);
    }
}
