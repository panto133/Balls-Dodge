using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameLogic : MonoBehaviour
{
    //GameObjects

    public GameObject[] informationsTexts;
    public GameObject[] spikes;

    public GameObject ball;
    public GameObject level;
    public GameObject shop;
    public GameObject menu;
    public GameObject options;
    public GameObject customize;
    public GameObject upgrades;
    public GameObject buttons;
    public GameObject spawner;
    public GameObject missileShooting;
    public GameObject missileShootingCanvas;
    public GameObject normalUpgrades;
    public GameObject informations;
    public GameObject customize0;
    public GameObject customize1;
    public GameObject deathScreen;
    public GameObject deathScreenGraphics;
    public GameObject backgroundImage;
    public GameObject levels;
    public GameObject level1;
    public GameObject hardcore;
    public GameObject enemies;
    public GameObject levelsCanvas;
    public GameObject boosters;
    public GameObject shieldInformation;
    public GameObject slowTimeInformation;
    public GameObject convertMissileInformation;
    public GameObject exScript;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI tetrahedronsText;
    public TextMeshProUGUI pentagonsText;
    public TextMeshProUGUI highscoreText;

    public Animation spike1;
    public Animation spike2;
    public Animation spike3;
    public Animation spike4;
    public Animation image;
    public Animation text;

    public Animation backSpike1;
    public Animation backSpike2;
    public Animation backSpike3;
    public Animation backSpike4;
    public Animation backImage;
    public Animation backText;

    //Script References
    private Ball ballReference;
    private Customize customizeReference;
    private Spawning spawning;
    private DeletingEnemies deletingEnemies;
    private Upgrades upgradesReference;  
    private MissileShooting missileShootingScript;
    
    //Score & Currency
    public int score = 0;
    public int highscore = 0;

    public float counter = 0f;
    private int checker = 1;


    public int tetrahedrons = 1000000;
    public int pentagons = 1000000;

    private bool gameActive = false;
    private bool change = false;

    private void Awake()
    {
        spawning = spawner.GetComponent<Spawning>();
        deletingEnemies = enemies.GetComponent<DeletingEnemies>();
        ballReference = ball.GetComponent<Ball>();
        customizeReference = GetComponent<Customize>();
        upgradesReference = gameObject.GetComponent<Upgrades>();
        missileShootingScript = missileShooting.GetComponent<MissileShooting>();
        LoadProgress();
        Input.multiTouchEnabled = false;
    }
    private void LateUpdate()
    {
        pentagonsText.text = "" + pentagons;
        tetrahedronsText.text = "" + tetrahedrons;
    }
    private void Update()
    {
        if (gameActive)
        {
            counter += Time.deltaTime;
            score = (int)counter;
            scoreText.text = "Score: " + score;
            if(score / 50 == checker)
            {
                PlayAnimations();
                checker++;
            }
        }       
    }

    //Start Menu Logic
    public void FromMenuToLevels()
    {
        levelsCanvas.SetActive(true);
        levels.SetActive(true);
        menu.SetActive(false);
    }
    public void FromLevelsToLevel1()
    {
        levelsCanvas.SetActive(false);
        spawner.SetActive(true);       
        ball.transform.position = new Vector3(0, -1, 0);
        ball.SetActive(true);
        scoreText.enabled = true;
        if (upgradesReference.missileEnabled)
        {
            missileShooting.SetActive(true);
            missileShootingCanvas.SetActive(true);
        }
        counter = 0;
        foreach(GameObject spike in spikes)
        {
            spike.GetComponent<ParallaxEffect>().start = true;
        }
        level.SetActive(true);
        menu.SetActive(false);
        deathScreen.GetComponent<DeathScreen>().ResetCounter();
        spawning.timer2 = 10f;
        ballReference.start = true;
        gameActive = true;
        spawning.CheckChance();
    }
    public void FromLevelsToHardcore()
    {

    }
    public void FromNormalUpgradesToBoosters()
    {
        normalUpgrades.SetActive(false);
        boosters.SetActive(true);
    }
    public void FromBoostersToNormalUpgrades()
    {
        normalUpgrades.SetActive(true);
        boosters.SetActive(false);
    }
    public void FromLevelsToMenu()
    {
        levels.SetActive(false);
        menu.SetActive(true);
    }
    public void FromMenuToShop()
    {
        level.SetActive(false);
        shop.SetActive(true);
        menu.SetActive(false);
        ball.SetActive(false);
        GetComponent<Customize>().CheckIfBought();
    }
    public void FromMenuToOptions()
    {
        options.SetActive(true);
        menu.SetActive(false);
    }
    public void FromOptionsToMenu()
    {
        options.SetActive(false);
        menu.SetActive(true);
    }
    public void FromShopToMenu()
    {
        level.SetActive(true);
        level1.SetActive(false);
        menu.SetActive(true);
        shop.SetActive(false);
    }
    public void FromLevelToMenu()
    {
        level.SetActive(false);
        menu.SetActive(true);
    }
    public void FromShopToCustomise()
    {
        customize.SetActive(true);
        buttons.SetActive(false);
    }
    public void FromShopToUpgrades()
    {
        upgrades.SetActive(true);
        buttons.SetActive(false);
    }
    public void FromCustomizeToShop()
    {
        customize.SetActive(false);
        buttons.SetActive(true);
    }
    public void FromUpgradesToShop()
    {
        upgrades.SetActive(false);
        buttons.SetActive(true);
    }

    public void FromUpgradesToFortuneInformations()
    {
        normalUpgrades.SetActive(false);
        informations.SetActive(true);
        informationsTexts[1].SetActive(true);
    }
    public void FromFortuneInformationsToUpgrades()
    {
        normalUpgrades.SetActive(true);
        informationsTexts[1].SetActive(false);
        informations.SetActive(false);
    }
    public void FromUpgradesToMissileInformations()
    {
        normalUpgrades.SetActive(false);
        informations.SetActive(true);
        informationsTexts[0].SetActive(true);
    }

    public void FromMissileInformationsToUpgrades()
    {
        normalUpgrades.SetActive(true);
        informationsTexts[0].SetActive(false);
        informations.SetActive(false);
    }
    public void FromBoosterToUpgrades()
    {
        normalUpgrades.SetActive(true);
        informationsTexts[3].SetActive(false);
        informations.SetActive(false);
    }
    public void FromUpgradesToMissileBounceInformations()
    {
        normalUpgrades.SetActive(false);
        informations.SetActive(true);
        informationsTexts[2].SetActive(true);
    }
    public void FromMissileBounceInformationsToUpgrades()
    {
        normalUpgrades.SetActive(true);
        informationsTexts[2].SetActive(false);
        informations.SetActive(false);
    }
    public void FromUpgradesToBoosterInformations()
    {
        normalUpgrades.SetActive(false);
        informations.SetActive(true);
        informationsTexts[3].SetActive(true);
    }
    public void FromBoosterToShieldInformation()
    {
        boosters.SetActive(false);
        shieldInformation.SetActive(true);
    }
    public void FromShieldInformationToBooster()
    {
        shieldInformation.SetActive(false);
        boosters.SetActive(true);
    }
    public void FromBoosterToSlowTimeInformation()
    {
        slowTimeInformation.SetActive(true);
        boosters.SetActive(false);
    }
    public void FromSlowTimeinformationToBooster()
    {
        boosters.SetActive(true);
        slowTimeInformation.SetActive(false);
    }
    public void FromBoosterToConvertMissileInformation()
    {
        boosters.SetActive(false);
        convertMissileInformation.SetActive(true);
    }
    public void FromConvertMissileInformationToBooster()
    {
        boosters.SetActive(true);
        convertMissileInformation.SetActive(false);
    }


    public void FromCustomize1ToCustomize0()
    {
        customize1.SetActive(false);
        customize0.SetActive(true);
    }
    public void FromCustomize0ToCustomize1()
    {
        customize0.SetActive(false);
        customize1.SetActive(true);
    }
    public void FromDeathScreenToMenu()
    {
        deathScreenGraphics.SetActive(false);
        level.SetActive(true);
        level1.SetActive(false);
        menu.SetActive(true);
    }
    public void Quit()
    {
        Application.Quit();
    }

    public void ResetGame()
    {
        upgradesReference.StopAllCoroutines();
        Time.timeScale = 1f;
        exScript.GetComponent<ExpirationScript>().bar.fillAmount = 1f;
        if(!upgradesReference.shieldBought)
        {
            exScript.SetActive(false);
        }
        checker = 1;
        if (score > highscore)
        {
            highscore = score;
        }
        change = false;
        highscoreText.text = "" + highscore;
        deathScreenGraphics.SetActive(true);
        deathScreen.GetComponent<DeathScreen>().GetData();
        ballReference.start = false;
        ball.SetActive(false);
        deletingEnemies.DeletingObstacles();
        foreach(GameObject spike in spikes)
        {
            spike.GetComponent<ParallaxEffect>().speed = spike.GetComponent<ParallaxEffect>().defaultSpeed;
            spike.GetComponent<ParallaxEffect>().start = false;
        }
        GameObject.Find("Left Spikes").GetComponent<ParallaxEffect>().ResetPosition();
        GameObject.Find("Left Spikes (1)").GetComponent<ParallaxEffect>().ResetPosition();
        GameObject.Find("Right Spikes").GetComponent<ParallaxEffect>().ResetPosition();
        GameObject.Find("Right Spikes (1)").GetComponent<ParallaxEffect>().ResetPosition();

        GameObject.Find("Left Spikes (2)").GetComponent<ParallaxEffect>().ResetPosition();
        GameObject.Find("Left Spikes (3)").GetComponent<ParallaxEffect>().ResetPosition();
        GameObject.Find("Right Spikes (2)").GetComponent<ParallaxEffect>().ResetPosition();
        GameObject.Find("Right Spikes (3)").GetComponent<ParallaxEffect>().ResetPosition();

        GameObject.Find("Left Spikes (2)").GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0);
        GameObject.Find("Left Spikes (3)").GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0);
        GameObject.Find("Right Spikes (2)").GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0);
        GameObject.Find("Right Spikes (3)").GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0);

        backgroundImage.GetComponent<Image>().color = new Color(0, 0, 0, 0);
        scoreText.color = new Color(0, 0, 0, 255);

        spawning.timer = 0f;
        spawning.timer2 = 0f;
        ball.transform.position = ballReference.startingPosition;
        scoreText.enabled = false;
        gameActive = false;
        counter = 0;
        spawning.spawnedMissile = false;
        spawner.SetActive(false);
        level.SetActive(false);
        menu.SetActive(false);
        spawning.spawned = true;
        missileShootingScript.Reset();
        deathScreen.GetComponent<DeathScreen>().pickedUpTetrahedrons = 0;
        SavingSystem.SavePlayer(this, ballReference, customizeReference, spawning);
    }

    public void LoadProgress()
    {
        PlayerSaveData data = SavingSystem.LoadPlayer();
        if (data != null)
        {
            highscore = data.highscore;
            pentagons = data.pentagons;
            tetrahedrons = data.tetrahedrons;
        }
    }
    private void PlayAnimations()
    {
        if(!change)
        {
            spike1.Play();
            spike2.Play();
            spike3.Play();
            spike4.Play();
            image.Play();
            text.Play();
            change = true;
        }
        else
        {
            backSpike1.Play("Back_Transition_Spikes");
            backSpike2.Play("Back_Transition_Spikes2");
            backSpike3.Play("Back_Transition_Spikes3");
            backSpike4.Play("Back_Transition_Spikes4");
            backImage.Play("Back_Transition_Image");
            backText.Play("Back_Transition_Score");
            change = false;
        }
    }
}
