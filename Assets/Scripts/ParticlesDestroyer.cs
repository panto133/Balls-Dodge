using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesDestroyer : MonoBehaviour
{
    float time;

    private void Start()
    {
#pragma warning disable CS0618 // Type or member is obsolete
        time = GetComponent<ParticleSystem>().startLifetime;
#pragma warning restore CS0618 // Type or member is obsolete
        Invoke("DestroyParticle", time);
        
    }
    public void DestroyParticle()
    {
        Destroy(gameObject);
    }
}
