using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDefeatedTextDisappear : MonoBehaviour
{
    private void Awake()
    {
        Invoke("DestroySelf", 5f);
    }
    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
