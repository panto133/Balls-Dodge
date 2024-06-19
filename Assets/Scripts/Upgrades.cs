using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Upgrades : MonoBehaviour
{
    
    public GameObject ball;
    public GameObject spawningGO;
    public GameObject slowTime;
    public GameObject convertMissile;
    public GameObject shieldEx;
    public GameObject exScript;

    private GameObject previouslySelected = null;
    private GameObject previousleSelectedBooster = null;

    public GameObject[] selected;
    public GameObject[] selectedBooster;
    public GameObject[] holder;

    public Image[] upgradedFortune;
    public Image[] notUpgradedFortune;

    public Image[] upgradedMissile;
    public Image[] notUpgradedMissile;

    public Image[] upgradedMissileBounce;
    public Image[] notUpgradedMissileBounce;

    public Image[] upgradedBooster;
    public Image[] notUpgradedBooster;

    public Image[] boosterCheckmarks;

    public Sprite graySprite;

    public TextMeshProUGUI missileCost;
    public TextMeshProUGUI fortuneCost;
    public TextMeshProUGUI missileBounceCost;
    public TextMeshProUGUI boosterCost;

    private TextMeshProUGUI pentagonsText;
    private TextMeshProUGUI tetrahedronsText;

    private Ball ballUpgrades;
    private GameLogic gameLogic;
    private Customize customize;

    public int defaultTetrahedronChance = 1;
    public int defaultBulletChance = 90;
    public int defaultMissileBounceChance = 0;
    public int tetrahedronChance;
    public int bulletChance;
    public int missileBounceChance;

    public bool missileEnabled = false;
    public bool missileConvertEnabled = false;
    public bool invincible = false;
    public bool shieldBought = false;

    private int pentagons;
    private int tetrahedrons;
    private int selectedIndex = -1;
    private int selectedBoosterIndex = -1;

    [HideInInspector]
    public float slowTimeDuration = 4f;
    [HideInInspector]
    public float convertMissileDuration = 3f;
    [HideInInspector]
    public int shieldDuration = 2;

    private void Awake()
    {
        InvokeRepeating("CheckForCurrency", 5, 5);

        ballUpgrades = ball.GetComponent<Ball>();
        gameLogic = GetComponent<GameLogic>();
        customize = GetComponent<Customize>();

        tetrahedronChance = defaultTetrahedronChance;
        bulletChance = defaultBulletChance;
        
        pentagonsText = gameLogic.pentagonsText;
        tetrahedronsText = gameLogic.tetrahedronsText;

        pentagons = gameLogic.pentagons;
        tetrahedrons = gameLogic.tetrahedrons;
    }

    private void Start()
    {
        CheckLoaded();
    }

    public void Missile()
    {
        if(previouslySelected != null)
            previouslySelected.SetActive(false);
        selected[0].SetActive(true);
        selectedIndex = 0;
        previouslySelected = selected[0];
    }

    public void Fortune()
    {
        if (previouslySelected != null)
            previouslySelected.SetActive(false);
        selected[1].SetActive(true);
        selectedIndex = 1;
        previouslySelected = selected[1];
    }

    public void MissileBounce()
    {
        if (previouslySelected != null)
            previouslySelected.SetActive(false);
        selected[2].SetActive(true);
        selectedIndex = 2;
        previouslySelected = selected[2];
    }

    public void Booster()
    {
        if (previouslySelected != null)
            previouslySelected.SetActive(false);
        selected[3].SetActive(true);
        selectedIndex = 3;
        previouslySelected = selected[3];
    }

    public void Shield()
    {
        if(previousleSelectedBooster != null)
            previousleSelectedBooster.SetActive(false);
        selectedBooster[0].SetActive(true);
        selectedBoosterIndex = 0;
        previousleSelectedBooster = selectedBooster[0];       
    }

    public void SlowTime()
    {
        if (previousleSelectedBooster != null)
            previousleSelectedBooster.SetActive(false);
        selectedBooster[1].SetActive(true);
        selectedBoosterIndex = 1;
        previousleSelectedBooster = selectedBooster[1];
        slowTime.SetActive(true);
    }

    public void ConvertMissile()
    {
        if (previousleSelectedBooster != null)
            previousleSelectedBooster.SetActive(false);
        selectedBooster[2].SetActive(true);
        selectedBoosterIndex = 2;
        previousleSelectedBooster = selectedBooster[2];
        convertMissile.SetActive(true);
    }

    public void NoAds()
    {
        if (previousleSelectedBooster != null)
            previousleSelectedBooster.SetActive(false);
        selectedBooster[3].SetActive(true);
        selectedBoosterIndex = 3;
        previousleSelectedBooster = selectedBooster[3];
    }

    public void BuyButton()
    {
        switch(selectedIndex)
        {
            case 0:
                if (notUpgradedMissile[0].enabled && pentagons >= 500)
                {
                    notUpgradedMissile[0].enabled = false;
                    upgradedMissile[0].enabled = true;
                    missileCost.text = "1000";
                    pentagons -= 500;
                    ballUpgrades.MissileUpgraded();
                }
                else if (notUpgradedMissile[1].enabled && pentagons >= 1000)
                {
                    notUpgradedMissile[1].enabled = false;
                    upgradedMissile[1].enabled = true;
                    missileCost.text = "1500";
                    pentagons -= 1000;
                    ballUpgrades.MissileUpgraded();
                }
                else if (notUpgradedMissile[2].enabled && pentagons >= 1500)
                {
                    notUpgradedMissile[2].enabled = false;
                    upgradedMissile[2].enabled = true;
                    missileCost.text = "2500";
                    pentagons -= 1500;
                    ballUpgrades.MissileUpgraded();                   
                }
                else if (notUpgradedMissile[3].enabled && pentagons >= 2500)
                {
                    notUpgradedMissile[3].enabled = false;
                    upgradedMissile[3].enabled = true;
                    missileCost.text = "5000";
                    pentagons -= 2500;
                    ballUpgrades.MissileUpgraded();
                }
                else if (notUpgradedMissile[4].enabled && pentagons >= 5000)
                {
                    notUpgradedMissile[4].enabled = false;
                    upgradedMissile[4].enabled = true;
                    missileCost.text = "7500";
                    pentagons -= 5000;
                    ballUpgrades.MissileUpgraded();
                }
                else if (notUpgradedMissile[5].enabled && pentagons >= 7500)
                {
                    notUpgradedMissile[5].enabled = false;
                    upgradedMissile[5].enabled = true;
                    missileCost.text = "MAX";
                    pentagons -= 7500;
                    ballUpgrades.MissileUpgraded();
                }
                break;
            case 1:
                if (notUpgradedFortune[0].enabled && pentagons >= 250)
                {
                    notUpgradedFortune[0].enabled = false;
                    upgradedFortune[0].enabled = true;
                    fortuneCost.text = "1000";
                    pentagons -= 250;
                    ballUpgrades.FortuneUpgraded();
                }
                else if (notUpgradedFortune[1].enabled && pentagons >= 1000)
                {
                    notUpgradedFortune[1].enabled = false;
                    upgradedFortune[1].enabled = true;
                    fortuneCost.text = "2500";
                    pentagons -= 1000;
                    ballUpgrades.FortuneUpgraded();
                }
                else if (notUpgradedFortune[2].enabled && pentagons >= 2500)
                {
                    notUpgradedFortune[2].enabled = false;
                    upgradedMissile[2].enabled = true;
                    fortuneCost.text = "5000";
                    pentagons -= 2500;
                    ballUpgrades.FortuneUpgraded();
                }
                else if (notUpgradedFortune[3].enabled && pentagons >= 5000)
                {
                    notUpgradedFortune[3].enabled = false;
                    upgradedMissile[3].enabled = true;
                    fortuneCost.text = "8000";
                    pentagons -= 5000;
                    ballUpgrades.FortuneUpgraded();
                }
                else if (notUpgradedFortune[4].enabled && pentagons >= 8000)
                {
                    notUpgradedFortune[4].enabled = false;
                    upgradedMissile[4].enabled = true;
                    fortuneCost.text = "15000";
                    pentagons -= 8000;
                    ballUpgrades.FortuneUpgraded();
                }
                else if (notUpgradedFortune[5].enabled && pentagons >= 15000)
                {
                    notUpgradedFortune[5].enabled = false;
                    upgradedMissile[5].enabled = true;
                    fortuneCost.text = "MAX";
                    pentagons -= 15000;
                    ballUpgrades.FortuneUpgraded();
                }
                break;
            case 2:
                if (notUpgradedMissileBounce[0].enabled && pentagons >= 1000)
                {
                    notUpgradedMissileBounce[0].enabled = false;
                    upgradedMissileBounce[0].enabled = true;
                    missileBounceCost.text = "2000";
                    pentagons -= 1000;
                    ballUpgrades.MissileBounceUpgraded();
                }
                else if (notUpgradedMissileBounce[1].enabled && pentagons >= 2000)
                {
                    notUpgradedMissileBounce[1].enabled = false;
                    upgradedMissileBounce[1].enabled = true;
                    missileBounceCost.text = "3000";
                    pentagons -= 2000;
                    ballUpgrades.MissileBounceUpgraded();
                }
                else if (notUpgradedMissileBounce[2].enabled && pentagons >= 3000)
                {
                    notUpgradedMissileBounce[2].enabled = false;
                    upgradedMissileBounce[2].enabled = true;
                    missileBounceCost.text = "4000";
                    pentagons -= 3000;
                    ballUpgrades.MissileBounceUpgraded();
                }
                else if (notUpgradedMissileBounce[3].enabled && pentagons >= 4000)
                {
                    notUpgradedMissileBounce[3].enabled = false;
                    upgradedMissileBounce[3].enabled = true;
                    missileBounceCost.text = "5000";
                    pentagons -= 4000;
                    ballUpgrades.MissileBounceUpgraded();
                }
                else if (notUpgradedMissileBounce[4].enabled && pentagons >= 5000)
                {
                    notUpgradedMissileBounce[4].enabled = false;
                    upgradedMissileBounce[4].enabled = true;
                    missileBounceCost.text = "6000";
                    pentagons -= 5000;
                    ballUpgrades.MissileBounceUpgraded();
                }
                else if (notUpgradedMissileBounce[5].enabled && pentagons >= 6000)
                {
                    notUpgradedMissileBounce[5].enabled = false;
                    upgradedMissileBounce[5].enabled = true;
                    missileBounceCost.text = "MAX";
                    pentagons -= 6000;
                    ballUpgrades.MissileBounceUpgraded();
                }
                break;
            case 3:
                if (notUpgradedBooster[0].enabled && pentagons >= 2000)
                {
                    notUpgradedBooster[0].enabled = false;
                    upgradedBooster[0].enabled = true;
                    boosterCost.text = "4000";
                    pentagons -= 2000;
                    ballUpgrades.BoosterUpgraded();
                }
                else if (notUpgradedBooster[1].enabled && pentagons >= 4000)
                {
                    notUpgradedBooster[1].enabled = false;
                    upgradedBooster[1].enabled = true;
                    boosterCost.text = "6000";
                    pentagons -= 4000;
                    ballUpgrades.BoosterUpgraded();
                }
                else if (notUpgradedBooster[2].enabled && pentagons >= 6000)
                {
                    notUpgradedBooster[2].enabled = false;
                    upgradedBooster[2].enabled = true;
                    boosterCost.text = "8000";
                    pentagons -= 6000;
                    ballUpgrades.BoosterUpgraded();
                }
                else if (notUpgradedBooster[3].enabled && pentagons >= 8000)
                {
                    notUpgradedBooster[3].enabled = false;
                    upgradedBooster[3].enabled = true;
                    boosterCost.text = "10000";
                    pentagons -= 8000;
                    ballUpgrades.BoosterUpgraded();
                }
                else if (notUpgradedBooster[4].enabled && pentagons >= 1000)
                {
                    notUpgradedBooster[4].enabled = false;
                    upgradedBooster[4].enabled = true;
                    boosterCost.text = "12000";
                    pentagons -= 10000;
                    ballUpgrades.BoosterUpgraded();
                }
                else if (notUpgradedBooster[5].enabled && pentagons >= 12000)
                {
                    notUpgradedBooster[5].enabled = false;
                    upgradedBooster[5].enabled = true;
                    boosterCost.text = "MAX";
                    pentagons -= 12000;
                    ballUpgrades.BoosterUpgraded();
                }
                break;

        }
        SavingSystem.SavePlayer(gameLogic, ballUpgrades, customize, spawningGO.GetComponent<Spawning>());
        gameLogic.pentagons = pentagons;
    }

    public void BuyBoostersButton()
    {
        switch(selectedBoosterIndex)
        {
            case 0:
                if (!boosterCheckmarks[0].enabled && tetrahedrons >= 10)
                {                   
                    boosterCheckmarks[0].enabled = true;
                    holder[0].SetActive(false);
                    tetrahedrons -= 10;
                    ballUpgrades.ShieldBooster();
                }
                break;
            case 1:
                if (!boosterCheckmarks[1].enabled && tetrahedrons >= 15)
                {
                    boosterCheckmarks[1].enabled = true;
                    holder[1].SetActive(false);
                    tetrahedrons -= 15;
                    ballUpgrades.SlowTimeBooster();
                }
                break;
            case 2:
                if (!boosterCheckmarks[2].enabled && tetrahedrons >= 20)
                {
                    boosterCheckmarks[2].enabled = true;
                    holder[2].SetActive(false);
                    tetrahedrons -= 20;
                    ballUpgrades.ConvertMissileBooster();
                }
                break;
            case 3:
                if (!boosterCheckmarks[3].enabled)
                {
                    boosterCheckmarks[3].enabled = true;
                    holder[3].SetActive(false);
                    ballUpgrades.NoAds();
                }
                break;
        }
        previousleSelectedBooster.SetActive(false);
        SavingSystem.SavePlayer(gameLogic, ballUpgrades, customize, spawningGO.GetComponent<Spawning>());
        gameLogic.tetrahedrons = tetrahedrons;
    }

    public void CheckLoaded()
    {
        switch (ballUpgrades.missileUpgraded)
        {
            case 1:
                for (int i = 0; i < ballUpgrades.missileUpgraded; i++)
                {
                    notUpgradedMissile[i].enabled = false;
                    upgradedMissile[i].enabled = true;
                    ballUpgrades.missileCooldown -= 0.8f;
                }
                missileCost.text = "1000";
                
                missileEnabled = true;
                break;
            case 2:
                for (int i = 0; i < ballUpgrades.missileUpgraded; i++)
                {
                    notUpgradedMissile[i].enabled = false;
                    upgradedMissile[i].enabled = true;
                    ballUpgrades.missileCooldown -= 0.8f;
                }
                missileCost.text = "1500";
                missileEnabled = true;
                break;
            case 3:
                for (int i = 0; i < ballUpgrades.missileUpgraded; i++)
                {
                    notUpgradedMissile[i].enabled = false;
                    upgradedMissile[i].enabled = true;
                    ballUpgrades.missileCooldown -= 0.8f;
                }
                missileCost.text = "2500";
                missileEnabled = true;
                break;
            case 4:
                for (int i = 0; i < ballUpgrades.missileUpgraded; i++)
                {
                    notUpgradedMissile[i].enabled = false;
                    upgradedMissile[i].enabled = true;
                    ballUpgrades.missileCooldown -= 0.8f;
                }
                missileCost.text = "5000";
                missileEnabled = true;
                break;
            case 5:
                for (int i = 0; i < ballUpgrades.missileUpgraded; i++)
                {
                    notUpgradedMissile[i].enabled = false;
                    upgradedMissile[i].enabled = true;
                    ballUpgrades.missileCooldown -= 0.8f;
                }
                missileCost.text = "7500";
                missileEnabled = true;
                break;
            case 6:
                for (int i = 0; i < ballUpgrades.missileUpgraded; i++)
                {
                    notUpgradedMissile[i].enabled = false;
                    upgradedMissile[i].enabled = true;
                    ballUpgrades.missileCooldown -= 0.8f;
                }
                missileCost.text = "MAX";
                missileEnabled = true;
                break;
        }

        switch (ballUpgrades.fortuneUpgraded)
        {
            case 1:
                for(int i = 0; i < ballUpgrades.fortuneUpgraded; i++)
                {
                    notUpgradedFortune[i].enabled = false;
                    upgradedFortune[i].enabled = true;
                    tetrahedronChance += 1;
                    bulletChance -= 15;
                }
                fortuneCost.text = "1000";
                break;
            case 2:
                for (int i = 0; i < ballUpgrades.fortuneUpgraded; i++)
                {
                    notUpgradedFortune[i].enabled = false;
                    upgradedFortune[i].enabled = true;
                    tetrahedronChance += 1;
                    bulletChance -= 15;
                }
                fortuneCost.text = "2500";
                break;
            case 3:
                for (int i = 0; i < ballUpgrades.fortuneUpgraded; i++)
                {
                    notUpgradedFortune[i].enabled = false;
                    upgradedFortune[i].enabled = true;
                    tetrahedronChance += 1;
                    bulletChance -= 15;
                }
                fortuneCost.text = "5000";
                break;
            case 4:
                for (int i = 0; i < ballUpgrades.fortuneUpgraded; i++)
                {
                    notUpgradedFortune[i].enabled = false;
                    upgradedFortune[i].enabled = true;
                    tetrahedronChance += 1;
                    bulletChance -= 15;
                }
                fortuneCost.text = "8000";
                break;
            case 5:
                for (int i = 0; i < ballUpgrades.fortuneUpgraded; i++)
                {
                    notUpgradedFortune[i].enabled = false;
                    upgradedFortune[i].enabled = true;
                    tetrahedronChance += 1;
                    bulletChance -= 15;
                }
                fortuneCost.text = "15000";
                break;
            case 6:
                for (int i = 0; i < ballUpgrades.fortuneUpgraded; i++)
                {
                    notUpgradedFortune[i].enabled = false;
                    upgradedFortune[i].enabled = true;
                    tetrahedronChance += 1;
                    bulletChance -= 15;
                }
                fortuneCost.text = "MAX";
                break;
        }

        switch (ballUpgrades.missileBounceUpgraded)
        {
            case 1:
                for (int i = 0; i < ballUpgrades.missileBounceUpgraded; i++)
                {
                    notUpgradedMissileBounce[i].enabled = false;
                    upgradedMissileBounce[i].enabled = true;
                    missileBounceChance += 16;
                }
                missileBounceCost.text = "2000";
                break;
            case 2:
                for (int i = 0; i < ballUpgrades.missileBounceUpgraded; i++)
                {
                    notUpgradedMissileBounce[i].enabled = false;
                    upgradedMissileBounce[i].enabled = true;
                    missileBounceChance += 16;
                }
                missileBounceCost.text = "3000";
                break;
            case 3:
                for (int i = 0; i < ballUpgrades.missileBounceUpgraded; i++)
                {
                    notUpgradedMissileBounce[i].enabled = false;
                    upgradedMissileBounce[i].enabled = true;
                    missileBounceChance += 16;
                }
                missileBounceCost.text = "4000";
                break;
            case 4:
                for (int i = 0; i < ballUpgrades.missileBounceUpgraded; i++)
                {
                    notUpgradedMissileBounce[i].enabled = false;
                    upgradedMissileBounce[i].enabled = true;
                    missileBounceChance += 16;
                }
                missileBounceCost.text = "5000";
                break;
            case 5:
                for (int i = 0; i < ballUpgrades.missileBounceUpgraded; i++)
                {
                    notUpgradedMissileBounce[i].enabled = false;
                    upgradedMissileBounce[i].enabled = true;
                    missileBounceChance += 16;
                }
                missileBounceCost.text = "6000";
                break;
            case 6:
                for (int i = 0; i < ballUpgrades.missileBounceUpgraded; i++)
                {
                    notUpgradedMissileBounce[i].enabled = false;
                    upgradedMissileBounce[i].enabled = true;
                    missileBounceChance += 16;
                }
                missileBounceCost.text = "MAX";
                break;
        }

        switch (ballUpgrades.boosterUpgraded)
        {
            case 1:
                for (int i = 0; i < ballUpgrades.boosterUpgraded; i++)
                {
                    notUpgradedBooster[i].enabled = false;
                    upgradedBooster[i].enabled = true;
                    convertMissileDuration += 0.56f;
                    slowTimeDuration += 0.38f;
                }
                boosterCost.text = "4000";
                break;
            case 2:
                for (int i = 0; i < ballUpgrades.boosterUpgraded; i++)
                {
                    notUpgradedBooster[i].enabled = false;
                    upgradedBooster[i].enabled = true;
                    convertMissileDuration += 0.56f;
                    slowTimeDuration += 0.38f;
                }
                boosterCost.text = "6000";
                break;
            case 3:
                for (int i = 0; i < ballUpgrades.boosterUpgraded; i++)
                {
                    notUpgradedBooster[i].enabled = false;
                    upgradedBooster[i].enabled = true;
                    convertMissileDuration += 0.56f;
                    slowTimeDuration += 0.38f;
                }
                boosterCost.text = "8000";
                break;
            case 4:
                for (int i = 0; i < ballUpgrades.boosterUpgraded; i++)
                {
                    notUpgradedBooster[i].enabled = false;
                    upgradedBooster[i].enabled = true;
                    convertMissileDuration += 0.56f;
                    slowTimeDuration += 0.38f;
                }
                boosterCost.text = "10000";
                break;
            case 5:
                for (int i = 0; i < ballUpgrades.boosterUpgraded; i++)
                {
                    notUpgradedBooster[i].enabled = false;
                    upgradedBooster[i].enabled = true;
                    convertMissileDuration += 0.56f;
                    slowTimeDuration += 0.38f;
                }
                boosterCost.text = "12000";
                break;
            case 6:
                for (int i = 0; i < ballUpgrades.boosterUpgraded; i++)
                {
                    notUpgradedBooster[i].enabled = false;
                    upgradedBooster[i].enabled = true;
                    convertMissileDuration += 0.56f;
                    slowTimeDuration += 0.38f;
                }
                boosterCost.text = "MAX";
                break;
        }

        if(ballUpgrades.shieldBoosterBought)
        {
            holder[0].SetActive(false);
            boosterCheckmarks[0].enabled = true;
            ballUpgrades.ShieldBooster();
            shieldEx.SetActive(true);
        }

        if (ballUpgrades.slowTimeBoosterBought)
        {
            holder[1].SetActive(false);
            boosterCheckmarks[1].enabled = true;
            ballUpgrades.SlowTimeBooster();
            slowTime.SetActive(true);
        }

        if (ballUpgrades.convertMissileBoosterBought)
        {
            holder[2].SetActive(false);
            boosterCheckmarks[2].enabled = true;
            ballUpgrades.ConvertMissileBooster();
            convertMissile.SetActive(true);
        }

        if (ballUpgrades.noAds)
        {
            holder[3].SetActive(false);
            boosterCheckmarks[3].enabled = true;
            ballUpgrades.NoAds();
        }
    }
    public void CheckForCurrency()
    {
        pentagons = gameLogic.pentagons;
        tetrahedrons = gameLogic.tetrahedrons;
    }

    public void SlowTimePower()
    {
        slowTime.SetActive(false);
        ballUpgrades.slowTimeBoosterBought = false;
        holder[1].SetActive(true);
        boosterCheckmarks[1].enabled = false;
        StartCoroutine(slowtimepower());
    }

    public void ConvertMissilePower()
    {
        missileConvertEnabled = true;
        ballUpgrades.convertMissileBoosterBought = false;
        convertMissile.SetActive(false);
        holder[2].SetActive(true);
        boosterCheckmarks[2].enabled = false;
        StartCoroutine(convertmissilepower());       
    }

    public void ShieldPower()
    {
        if (shieldBought)
        {
            shieldBought = false;
            ballUpgrades.shieldBoosterBought = false;
            holder[0].SetActive(true);
            boosterCheckmarks[0].enabled = false;
            exScript.GetComponent<ExpirationScript>().StartCountdown();
        }
    }

    IEnumerator slowtimepower()
    {
        Time.timeScale = 0.5f;
        yield return new WaitForSeconds(slowTimeDuration);
        Time.timeScale = 1f;
    }

    IEnumerator convertmissilepower()
    {
        missileConvertEnabled = true;
        yield return new WaitForSeconds(convertMissileDuration);
        missileConvertEnabled = false;
    }
}
