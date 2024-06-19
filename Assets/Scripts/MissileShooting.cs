using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MissileShooting : MonoBehaviour
{
    Ball ballUpgrades;
    public GameObject ball;
    public GameObject missile;
    public Transform parent;

    public Image progressBar;

    bool on = true;

    Image missileShootingButtonImage;
    public Sprite missileShootingRed;
    public Sprite missileShootingGreen;

    public Sprite missileShootingRedOff;
    public Sprite missileShootingGreenOff;

    float timer = 0f;
#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
    public int enabled = 0;
#pragma warning restore CS0108 // Member hides inherited member; missing new keyword

    public TextMeshProUGUI missileAmount;
    public TextMeshProUGUI onOff;
    public int missileAmmo;

    public GameObject missileShootingButtonGameObject;
    public Button missileShootingButton;
    public GameObject missileShootingCanvas;

    private void Awake()
    {
        missileShootingButtonImage = missileShootingButtonGameObject.GetComponent<Image>();
        ballUpgrades = ball.GetComponent<Ball>();
        missileShootingButton.interactable = true;
        enabled = ballUpgrades.missileUpgraded;
    }
    private void Update()
    {  
        timer += Time.deltaTime;
        missileAmount.text = "" + missileAmmo;
        if (progressBar.fillAmount == 1 && missileAmmo > 0 && on && ballUpgrades.missileUpgraded > 0)
        {
            missileShootingButtonImage.sprite = missileShootingGreen;
            Instantiate(missile, ball.transform.position, Quaternion.identity, parent);
            progressBar.fillAmount = 0f;
            missileShootingButtonImage.sprite = missileShootingRed;
            missileAmmo--;
            timer = 0;
        }
        if(progressBar.fillAmount == 1 && missileAmmo > 0)
        {
            missileShootingButtonImage.sprite = missileShootingGreen;
        }
        if (progressBar.fillAmount < 1)
        {
            progressBar.fillAmount += (1f / ballUpgrades.missileCooldown) * Time.deltaTime;
        }
        if(progressBar.fillAmount == 1 && on == false && missileAmmo > 0)
        {
            missileShootingButtonImage.sprite = missileShootingGreenOff;
        }
        else if(on == true && missileAmmo > 0 && progressBar.fillAmount == 1)
        {
            missileShootingButtonImage.sprite = missileShootingGreen;
        }
    }

    public void MissileShoot()
    {
        if(on)
        {
            missileShootingButtonImage.sprite = missileShootingRedOff;
            on = false;
            onOff.text = "OFF";
        }
        else
        {
            missileShootingButtonImage.sprite = missileShootingRed;
            on = true;
            onOff.text = "ON";
        }
    }

    public void Reset()
    {
        progressBar.fillAmount = 0;
        missileAmmo = 0;
        if(enabled == 1)
            missileShootingButtonImage.sprite = missileShootingRedOff;
        missileShootingCanvas.SetActive(false);
        timer = 0;
    }

}
