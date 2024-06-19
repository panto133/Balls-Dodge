using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyingMissileByTouch : MonoBehaviour
{
    Touch touch;
    public GameObject particle;
    public GameObject upgradesGO;
    public GameObject missile;
    public Transform parent;
    private Upgrades upgrades;
    RaycastHit2D hit;
    private void Awake()
    {
        upgrades = upgradesGO.GetComponent<Upgrades>();
    }
    void FixedUpdate()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(touch.position), Vector2.zero);
            if (hit.collider != null)
            {
                if (hit.collider.name == "Enemy Missile(Clone)")
                {
                    Destroy(hit.collider.gameObject);
                    Instantiate(particle, hit.collider.transform.position, Quaternion.identity);
                    if(upgrades.missileConvertEnabled)
                    {
                        Instantiate(missile, hit.collider.transform.position, Quaternion.identity, parent);
                    }
                }
            }
        }
        
    }
}
