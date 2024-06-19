using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeletePlus3 : MonoBehaviour
{
    private void Awake()
    {
        Invoke("DestroySelf", 0.5f);
    }
    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
