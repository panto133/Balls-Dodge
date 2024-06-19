using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpirationScript : MonoBehaviour
{
    public GameObject shield;
    public GameObject upgrades;
    private bool start;
    private float timer;
    public Image bar;

    private void Awake()
    {
        bar = shield.GetComponent<Image>();       
    }
    private void FixedUpdate()
    {
        if(start)
        {
            bar.fillAmount -= 1f / timer * Time.deltaTime;
        }
        if(bar.fillAmount == 0)
        {
            upgrades.GetComponent<Upgrades>().invincible = false;
            start = false;
        }
    }
    public void StartCountdown()
    {
        start = true;
        timer = upgrades.GetComponent<Upgrades>().shieldDuration;
    }
}
