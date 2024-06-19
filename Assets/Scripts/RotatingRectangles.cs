using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingRectangles : MonoBehaviour
{
    [HideInInspector]
    private float rotationSpeed = 90f;
    private float currentRotation = 0f;
    private void Awake()
    {
        rotationSpeed = SpeedGuidance.GetSpeed() - 30;
    }
    void FixedUpdate()
    {
        currentRotation += Time.fixedDeltaTime * rotationSpeed;
        transform.rotation = Quaternion.Euler(0f, 0f, currentRotation);
    }
}
