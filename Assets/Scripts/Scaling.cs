using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scaling : MonoBehaviour
{
    public float modifierX;
    public float modifierY;
    void Awake()
    {
        float relation = (float)Screen.height / Screen.width;
        float percentage = relation / 2f;
        modifierX = transform.localScale.x / percentage;
        modifierY = transform.localScale.y / percentage;
        modifierX = Mathf.Clamp(modifierX, transform.localScale.x - 0.2f, transform.localScale.x + 0.2f);
        modifierY = Mathf.Clamp(modifierY, transform.localScale.y - 0.2f, transform.localScale.y + 0.2f);
        transform.localScale = new Vector3(modifierX, modifierY, transform.localScale.z);
    }
}
