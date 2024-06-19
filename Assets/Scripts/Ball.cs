using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public GameObject background;

    public Vector3 startingPosition;

    private Vector3 offset;

    private Touch touch;

    private Upgrades upgrades;

    public bool start;
    public bool shieldBoosterBought = false;
    public bool slowTimeBoosterBought = false;
    public bool convertMissileBoosterBought = false;
    public bool noAds = false;

    public int missileUpgraded = 0;
    public int fortuneUpgraded = 0;
    public int missileBounceUpgraded = 0;
    public int boosterUpgraded = 0;

    public float missileCooldown;
    public float speed = 5f;
    private float rotating = 0f;
    private float defaultMissileCooldown = 6f;

    private void Awake()
    {
        upgrades = GameObject.Find("GameLogic").GetComponent<Upgrades>();
        missileCooldown = defaultMissileCooldown;
        LoadProgress();
    }

    private void Start()
    {
        startingPosition = transform.position;
        startingPosition = transform.position;
       
    }
    private void Update()
    {
        rotating += Time.deltaTime * speed;
        transform.rotation = Quaternion.Euler(0, 0, rotating);
    }
    void OnMouseDown()
    {
            offset = gameObject.transform.position -
            Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -100f));
    }

   void OnMouseDrag()
    {
            Vector3 newPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, -100f);
            transform.position = Camera.main.ScreenToWorldPoint(newPosition) + offset;
            transform.position = new Vector2(transform.position.x, Mathf.Clamp(transform.position.y, -3.35f, 6f));
    }
    public void Reset()
    {
        transform.position = startingPosition;
    }
    public void MissileUpgraded()
    {
        missileUpgraded++;
        missileCooldown -= 0.8f;
        upgrades.missileEnabled = true;
    }
    public void FortuneUpgraded()
    {
        fortuneUpgraded++;
        upgrades.tetrahedronChance += 1;
        upgrades.bulletChance -= 15;
    }
    public void MissileBounceUpgraded()
    {
        missileBounceUpgraded++;
        upgrades.missileBounceChance += 16;
    }
    public void BoosterUpgraded()
    {
        boosterUpgraded++;
        upgrades.convertMissileDuration += 0.56f;
        upgrades.slowTimeDuration += 0.38f;
    }
    public void ShieldBooster()
    {
        shieldBoosterBought = true;
        upgrades.invincible = true;
        upgrades.shieldBought = true;
        upgrades.shieldEx.SetActive(true);
    }
    public void SlowTimeBooster()
    {
        slowTimeBoosterBought = true;
    }
    public void ConvertMissileBooster()
    {
        convertMissileBoosterBought = true;
    }
    public void NoAds()
    {
        noAds = true;
    }
    public void LoadProgress()
    {
        PlayerSaveData data = SavingSystem.LoadPlayer();
        if (data != null)
        {
            missileUpgraded = data.missileUpgraded;
            fortuneUpgraded = data.fortuneUpgraded;
            missileBounceUpgraded = data.missileBounceUpgraded;
            boosterUpgraded = data.boosterUpgraded;

            shieldBoosterBought = data.shieldBoosterBought;
            slowTimeBoosterBought = data.slowTimeBoosterBought;
            convertMissileBoosterBought = data.convertMissileBoosterBought;
            noAds = data.noAds;
        }
    }
}
