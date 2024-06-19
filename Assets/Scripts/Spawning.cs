using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Spawning : MonoBehaviour
{
    [SerializeField]
    public GameObject[] spawnPoints;

    public Upgrades upgrades;
    public TextMeshProUGUI score;
    public GameObject gameLogicObject;
    public Transform parentGameObject;
    public GameObject obstacle;
    private ParallaxEffect parallaxEffectReference;
    private readonly float speed;
    private int i;
    public float timer = 0f;
    public float timer2 = 0f;
    public float defaultCooldown = 4f;
    public float cooldown;
    public GameObject spikeObstacle;
    public GameObject smallRectangle;
    public GameObject rotatingRectangle;
    public GameObject rotatingDoubleRectangle;
    public GameObject tetrahedron;
    public GameObject enemyMissile;
    public GameObject circle;
    public GameObject Warning;
    public GameObject ammo;
    public GameObject spear;
    public GameObject help;
    public GameObject boss;
    public GameObject ball;
    public GameObject customize;
    private Scaling scaling;
    public bool spawned = true;
    public bool spawnedMissile = false;
    public bool bossKilled = false;
    private int prev = -1;
    private int previ = -1;
    private int prevj = -1;
    private int chance = 0;
    private int tetrahedronChance;
    private int bulletChance;
    private void Awake()
    {
        upgrades = gameLogicObject.GetComponent<Upgrades>();       
    }
    private void Start()
    {
        cooldown = defaultCooldown;
        parallaxEffectReference = obstacle.GetComponent<ParallaxEffect>();
        PlayerSaveData data = SavingSystem.LoadPlayer();
        if (data != null) 
            bossKilled = data.bossKilled;
        scaling = ball.GetComponent<Scaling>();
        spawnPoints[1].transform.position -= new Vector3(Mathf.Abs(scaling.modifierX), 0, 0);
        spawnPoints[2].transform.position += new Vector3(Mathf.Abs(scaling.modifierX), 0, 0);
        spawnPoints[7].transform.position -= new Vector3(Mathf.Abs(scaling.modifierX), 0, 0);
        spawnPoints[5].transform.position += new Vector3(Mathf.Abs(scaling.modifierX), 0, 0);
    }
    private void Update()
    {
        timer += Time.deltaTime;
        timer2 += Time.deltaTime;
        
        if(timer >= 0 && timer < 39)
        {
            if(timer2 >= cooldown)
            {
                Easy();
                timer2 = 0;
            }
        }
        if (timer >= 40 && timer < 80)
        {
            if (timer2 >= cooldown)
            {
                Medium();
                timer2 = 0;
            }
        }

        if (timer >= 80 && timer < 98)
        {
            if (timer2 >= cooldown)
            {
                Hard();
                timer2 = 0;
            }
        }

        else if(timer >= 103 && spawned && !bossKilled)
        {
            score.enabled = false;
            GameObject clone = Instantiate(boss, new Vector3(0, 8, -5), Quaternion.identity) as GameObject;
            Instantiate(help, transform.position, Quaternion.identity, clone.transform);
            spawned = false;
        }
        else if (bossKilled)
        {
            if (timer2 >= cooldown)
            {
                AfterBoss();
                timer2 = 0;
            }
        }


    }
    public void BossKilled()
    {
        timer2 = 2;
        SavingSystem.SavePlayer(gameLogicObject.GetComponent<GameLogic>(), ball.GetComponent<Ball>(), customize.GetComponent<Customize>(), this);
    }
    public void Easy()
    {
        chance = Random.Range(80, 101);
        int i = Random.Range(0, 6);
        while(i == prev)
        {
            i = Random.Range(0, 6);
        }
        switch(i)
        {
            case 0:
                StartCoroutine(Easy1()); break;
            case 1:
                StartCoroutine(Easy2()); break;
            case 2:
                StartCoroutine(Easy3()); break;
            case 3:
                StartCoroutine(Easy4()); break;
            case 4:
                StartCoroutine(Easy5()); break;
            default:
                StartCoroutine(Easy6()); break;
        }
        prev = i;
    }

    public void Medium()
    {
        cooldown = 5f;
        chance = Random.Range(80, 101);
        i = Random.Range(0, 4);
        while(i == prev)
        {
            i = Random.Range(0, 3);
        }
        if (i == 0)
        {
            StartCoroutine(Medium1());
        }
        else if (i == 1)
        {
            StartCoroutine(Medium2());
        }
        else if (i == 2)
        {
            StartCoroutine(Medium3());
        }
        else
        {
            StartCoroutine(Medium4());
        }
        prev = i;
    }

    public void Hard()
    {
        int i = Random.Range(0, 4);
        if (i == 0)
        {
            StartCoroutine(Hard1());
        }
        else if (i == 1)
        {
            StartCoroutine(Hard2());
        }
        else if (i == 2)
        {
            StartCoroutine(Hard3());
        }
        else
        {
            StartCoroutine(Hard4());
        }
    }

    public void AfterBoss()
    {
        cooldown = 5f;
        chance = Random.Range(80, 101);

        i = Random.Range(0, 14);

        while (i == prev)
        {
            i = Random.Range(0, 14);
        }
        if (i == 0)
        {
            StartCoroutine(Easy1());
        }
        else if (i == 1)
        {
            StartCoroutine(Easy2());
        }
        else if (i == 2)
        {
            StartCoroutine(Easy3());
        }
        else if (i == 3)
        {
            StartCoroutine(Easy4());
        }
        else if (i == 4)
        {
            StartCoroutine(Easy5());
        }
        else if (i == 5)
        {
            StartCoroutine(Easy6());
        }
        else if (i == 6)
        {
            StartCoroutine(Medium1());
        }
        else if (i == 7)
        {
            StartCoroutine(Medium2());
        }
        else if (i == 8)
        {
            StartCoroutine(Medium3());
        }
        else if (i == 9)
        {
            StartCoroutine(Medium4());
        }
        else if (i == 10)
        {
            StartCoroutine(Hard1());
        }
        else if (i == 11)
        {
            StartCoroutine(Hard2());
        }
        else if (i == 12)
        {
            StartCoroutine(Hard3());
        }
        else
        {
            StartCoroutine(Hard4());
        }

        prev = i;
    }

    IEnumerator Easy1()
    {
        Instantiate(spikeObstacle, new Vector3(spawnPoints[1].transform.position.x, spawnPoints[1].transform.position.y, 4), Quaternion.identity, parentGameObject);
        DropChance(0,0);      
        yield return new WaitForSeconds(1f);
        Instantiate(spear, new Vector3(spawnPoints[2].transform.position.x, spawnPoints[2].transform.position.y, 4), Quaternion.identity, parentGameObject);
        Instantiate(spikeObstacle, new Vector3(spawnPoints[0].transform.position.x, spawnPoints[0].transform.position.y, 4), Quaternion.identity, parentGameObject);
        yield return new WaitForSeconds(1f);
        Instantiate(spikeObstacle, new Vector3(spawnPoints[2].transform.position.x, spawnPoints[2].transform.position.y, 4), Quaternion.identity, parentGameObject);
    }
    IEnumerator Easy2()
    {
        int j = -1, i = -1;
        cooldown = 4.5f;
        DropChance(1, 1);
        while(j == prevj)
            j = Random.Range(0, 3);
        while (i == previ)
            i = Random.Range(0, 3);
        switch (j)
        {
            case 0:
                Instantiate(circle, new Vector3(spawnPoints[0].transform.position.x, spawnPoints[0].transform.position.y, 4), Quaternion.identity, parentGameObject); break;
            case 1:
                GameObject clone = Instantiate(enemyMissile, new Vector3(spawnPoints[1].transform.position.x, spawnPoints[1].transform.position.y, 4), Quaternion.identity, parentGameObject) as GameObject;
                if (!spawnedMissile)
                    Instantiate(help, new Vector3(0,0,0), Quaternion.identity, clone.transform);
                break;
            default:
                Instantiate(circle, new Vector3(spawnPoints[2].transform.position.x, spawnPoints[2].transform.position.y, 4), Quaternion.identity, parentGameObject); break;
        }
        
        yield return new WaitForSeconds(2f);
        Instantiate(spikeObstacle, new Vector3(spawnPoints[Mathf.Abs(i - j)].transform.position.x, spawnPoints[Mathf.Abs(i - j)].transform.position.y, 4), Quaternion.identity, parentGameObject);
        yield return new WaitForSeconds(1f);
        spawnedMissile = true;
        cooldown = 3f;
        previ = i;
        prevj = j;
    }
    IEnumerator Easy3()
    {
        yield return new WaitForSeconds(0.7f);
        Instantiate(rotatingDoubleRectangle, new Vector3(spawnPoints[0].transform.position.x, spawnPoints[0].transform.position.y, 4), Quaternion.identity, parentGameObject);
        DropChance(2, 2);
        yield return new WaitForSeconds(2f);
        Instantiate(smallRectangle, new Vector3(spawnPoints[1].transform.position.x, spawnPoints[1].transform.position.y, 4), Quaternion.identity, parentGameObject);
        Instantiate(smallRectangle, new Vector3(spawnPoints[2].transform.position.x, spawnPoints[2].transform.position.y, 4), Quaternion.identity, parentGameObject);
    }
    IEnumerator Easy4()
    {
        DropChance(1, 1);
        int j = Random.Range(0,2);
        if (j == 0)
        {
            
            GameObject clone = Instantiate(enemyMissile, new Vector3(spawnPoints[4].transform.position.x, spawnPoints[4].transform.position.y, -1), Quaternion.identity, parentGameObject) as GameObject;
            if (!spawnedMissile)
                Instantiate(help, new Vector3(0,0,0), Quaternion.identity, clone.transform);
        }
        else
        {
            GameObject clone = Instantiate(enemyMissile, new Vector3(spawnPoints[3].transform.position.x, spawnPoints[3].transform.position.y, -1), Quaternion.identity, parentGameObject) as GameObject;
            if (!spawnedMissile)
                Instantiate(help, new Vector3(0, 0, 0), Quaternion.identity, clone.transform);
        }
        spawnedMissile = true;
        yield return new WaitForSeconds(1f);
        Instantiate(rotatingRectangle, new Vector3(spawnPoints[1].transform.position.x, spawnPoints[1].transform.position.y, 4), Quaternion.identity, parentGameObject);
        Instantiate(rotatingRectangle, new Vector3(spawnPoints[2].transform.position.x, spawnPoints[2].transform.position.y, 4), Quaternion.identity, parentGameObject);
    }
    IEnumerator Easy5()
    {
        DropChance(1, 1);
        Instantiate(circle, new Vector3(spawnPoints[1].transform.position.x, spawnPoints[1].transform.position.y, 4), Quaternion.identity, parentGameObject);
        yield return new WaitForSeconds(1f);
        Instantiate(circle, new Vector3(spawnPoints[0].transform.position.x, spawnPoints[0].transform.position.y, 4), Quaternion.identity, parentGameObject);
        yield return new WaitForSeconds(1f);
        Instantiate(circle, new Vector3(spawnPoints[1].transform.position.x, spawnPoints[1].transform.position.y, 4), Quaternion.identity, parentGameObject);
        yield return new WaitForSeconds(1f);
    }
    IEnumerator Easy6()
    {
        DropChance(0, 0);
        yield return new WaitForSeconds(1f);
        Instantiate(rotatingDoubleRectangle, new Vector3(spawnPoints[0].transform.position.x, spawnPoints[0].transform.position.y, 4), Quaternion.identity, parentGameObject);
        yield return new WaitForSeconds(.5f);
        Instantiate(smallRectangle, new Vector3(spawnPoints[1].transform.position.x, spawnPoints[1].transform.position.y, 4), Quaternion.identity, parentGameObject);
        yield return new WaitForSeconds(1f);
        GameObject clone = Instantiate(enemyMissile, new Vector3(spawnPoints[0].transform.position.x, spawnPoints[0].transform.position.y, 4), Quaternion.identity, parentGameObject) as GameObject;
        if (!spawnedMissile)
            Instantiate(help, clone.transform.position, Quaternion.identity, clone.transform);
        spawnedMissile = true;
    }
    IEnumerator Medium1()
    {
        int j = Random.Range(0, 2);
        DropChance(1, 1);
        Instantiate(smallRectangle, new Vector3(spawnPoints[4].transform.position.x - 100, spawnPoints[4].transform.position.y, 4), Quaternion.identity, parentGameObject);

        if (j == 0)
        {
            Instantiate(rotatingRectangle, new Vector3(spawnPoints[2].transform.position.x, spawnPoints[2].transform.position.y, 4), Quaternion.identity, parentGameObject);
            yield return new WaitForSeconds(1f);
            Instantiate(rotatingRectangle, new Vector3(spawnPoints[1].transform.position.x, spawnPoints[1].transform.position.y, 4), Quaternion.identity, parentGameObject);
        }
        else
        {
            Instantiate(rotatingRectangle, new Vector3(spawnPoints[1].transform.position.x, spawnPoints[1].transform.position.y, 4), Quaternion.identity, parentGameObject);
            yield return new WaitForSeconds(1f);
            Instantiate(rotatingRectangle, new Vector3(spawnPoints[2].transform.position.x, spawnPoints[2].transform.position.y, 4), Quaternion.identity, parentGameObject);
        }
        yield return new WaitForSeconds(1f);
        Instantiate(circle, new Vector3(spawnPoints[0].transform.position.x, spawnPoints[0].transform.position.y, 4), Quaternion.identity, parentGameObject);
    }
    IEnumerator Medium2()
    {
        int j = Random.Range(0, 2);
        DropChance(2, 2);
        if (j == 0)
        {
            Instantiate(enemyMissile, new Vector3(spawnPoints[4].transform.position.x, spawnPoints[4].transform.position.y, 4), Quaternion.identity, parentGameObject);
            yield return new WaitForSeconds(1f);
            Instantiate(enemyMissile, new Vector3(spawnPoints[3].transform.position.x, spawnPoints[3].transform.position.y, 4), Quaternion.identity, parentGameObject);
            Instantiate(smallRectangle, new Vector3(spawnPoints[0].transform.position.x, spawnPoints[0].transform.position.y, 4), Quaternion.identity, parentGameObject);
            DropChance(1,1);
            yield return new WaitForSeconds(1f);
            Instantiate(enemyMissile, new Vector3(spawnPoints[4].transform.position.x, spawnPoints[4].transform.position.y, 4), Quaternion.identity, parentGameObject);
            yield return new WaitForSeconds(1f);
        }
        else
        {
            Instantiate(enemyMissile, new Vector3(spawnPoints[3].transform.position.x, spawnPoints[3].transform.position.y, 4), Quaternion.identity, parentGameObject);
            yield return new WaitForSeconds(1f);
            Instantiate(enemyMissile, new Vector3(spawnPoints[4].transform.position.x, spawnPoints[4].transform.position.y, 4), Quaternion.identity, parentGameObject);
            Instantiate(smallRectangle, new Vector3(spawnPoints[0].transform.position.x, spawnPoints[0].transform.position.y, 4), Quaternion.identity, parentGameObject);
            DropChance(1,1);
            yield return new WaitForSeconds(1f);
            Instantiate(enemyMissile, new Vector3(spawnPoints[3].transform.position.x, spawnPoints[3].transform.position.y, 4), Quaternion.identity, parentGameObject);
            yield return new WaitForSeconds(1f);
        }
    }
    IEnumerator Medium3()
    {
        DropChance(2, 2);
        Instantiate(smallRectangle, new Vector3(spawnPoints[0].transform.position.x, spawnPoints[0].transform.position.y, 4), Quaternion.identity, parentGameObject);
        yield return new WaitForSeconds(1f);
        Instantiate(circle, new Vector3(spawnPoints[2].transform.position.x, spawnPoints[2].transform.position.y, 4), Quaternion.identity, parentGameObject);
        DropChance(1,1);
        yield return new WaitForSeconds(1f);
        Instantiate(circle, new Vector3(spawnPoints[1].transform.position.x, spawnPoints[1].transform.position.y, 4), Quaternion.identity, parentGameObject);
        yield return new WaitForSeconds(1f);
        int j = Random.Range(0, 4);
        if (j == 1)
        {
            Instantiate(circle, new Vector3(spawnPoints[1].transform.position.x, spawnPoints[1].transform.position.y, 4), Quaternion.identity, parentGameObject);
        }
        else if (j == 2)
        {
            Instantiate(circle, new Vector3(spawnPoints[2].transform.position.x, spawnPoints[2].transform.position.y, 4), Quaternion.identity, parentGameObject);
        }
        else
        {
            Instantiate(circle, new Vector3(spawnPoints[0].transform.position.x, spawnPoints[0].transform.position.y, 4), Quaternion.identity, parentGameObject);
        }
    }
    IEnumerator Medium4()
    {
        Instantiate(spikeObstacle, new Vector3(spawnPoints[1].transform.position.x, spawnPoints[1].transform.position.y, 4), Quaternion.identity, parentGameObject);
        Instantiate(spikeObstacle, new Vector3(spawnPoints[2].transform.position.x, spawnPoints[2].transform.position.y, 4), Quaternion.identity, parentGameObject);
        Instantiate(circle, new Vector3(spawnPoints[0].transform.position.x, spawnPoints[0].transform.position.y, 4), Quaternion.identity, parentGameObject);
        yield return new WaitForSeconds(1f);
        Instantiate(spikeObstacle, new Vector3(spawnPoints[1].transform.position.x, spawnPoints[1].transform.position.y, 4), Quaternion.identity, parentGameObject);
        Instantiate(spikeObstacle, new Vector3(spawnPoints[2].transform.position.x, spawnPoints[2].transform.position.y, 4), Quaternion.identity, parentGameObject);
        Instantiate(circle, new Vector3(spawnPoints[1].transform.position.x, spawnPoints[0].transform.position.y, 4), Quaternion.identity, parentGameObject);
        DropChance(0,0);
        yield return new WaitForSeconds(1f);
        Instantiate(spikeObstacle, new Vector3(spawnPoints[1].transform.position.x, spawnPoints[1].transform.position.y, 4), Quaternion.identity, parentGameObject);
        Instantiate(spikeObstacle, new Vector3(spawnPoints[2].transform.position.x, spawnPoints[2].transform.position.y, 4), Quaternion.identity, parentGameObject);
        Instantiate(circle, new Vector3(spawnPoints[2].transform.position.x, spawnPoints[0].transform.position.y, 4), Quaternion.identity, parentGameObject);
        yield return new WaitForSeconds(1f);
        Instantiate(spikeObstacle, new Vector3(spawnPoints[1].transform.position.x, spawnPoints[1].transform.position.y, 4), Quaternion.identity, parentGameObject);
        Instantiate(spikeObstacle, new Vector3(spawnPoints[2].transform.position.x, spawnPoints[2].transform.position.y, 4), Quaternion.identity, parentGameObject);
        Instantiate(circle, new Vector3(spawnPoints[1].transform.position.x, spawnPoints[0].transform.position.y, 4), Quaternion.identity, parentGameObject);
    }
    IEnumerator Hard1()
    {
        Debug.Log("Hard1");
        Instantiate(smallRectangle, new Vector3(spawnPoints[1].transform.position.x - 100, spawnPoints[1].transform.position.y, 4), Quaternion.identity, parentGameObject);
        Instantiate(circle, new Vector3(spawnPoints[1].transform.position.x, spawnPoints[1].transform.position.y, 4), Quaternion.identity, parentGameObject);
        DropChance(2,2);
        yield return new WaitForSeconds(1f);
        Instantiate(rotatingDoubleRectangle, new Vector3(spawnPoints[0].transform.position.x, spawnPoints[0].transform.position.y, 4), Quaternion.identity, parentGameObject);
        yield return new WaitForSeconds(1f);
        Instantiate(circle, new Vector3(spawnPoints[1].transform.position.x, spawnPoints[1].transform.position.y, 4), Quaternion.identity, parentGameObject);
    }
    IEnumerator Hard2()
    {
        Debug.Log("Hard2");
        yield return new WaitForSeconds(0.5f);
        Instantiate(rotatingDoubleRectangle, new Vector3(spawnPoints[0].transform.position.x, spawnPoints[0].transform.position.y, 4), Quaternion.identity, parentGameObject);
        yield return new WaitForSeconds(1.5f);
        
        int j = Random.Range(0, 3);
        GameObject clone;
        switch(j)
        {
            case 0:
                clone = Instantiate(Warning, new Vector3(spawnPoints[5].transform.position.x, spawnPoints[5].transform.position.y, 4), Quaternion.identity, parentGameObject) as GameObject;
                clone.GetComponent<Warning>().CallCoroutine(new Vector3(spawnPoints[5].transform.position.x, spawnPoints[5].transform.position.y, 4));
                DropChance(2,2);
                break;
            case 1:
                clone = Instantiate(Warning, new Vector3(spawnPoints[6].transform.position.x, spawnPoints[6].transform.position.y, 4), Quaternion.identity, parentGameObject) as GameObject;
                clone.GetComponent<Warning>().CallCoroutine(new Vector3(spawnPoints[6].transform.position.x, spawnPoints[6].transform.position.y, 4));
                DropChance(0,0);
                break;
            default:
                clone = Instantiate(Warning, new Vector3(spawnPoints[7].transform.position.x, spawnPoints[7].transform.position.y, 4), Quaternion.identity, parentGameObject) as GameObject;
                clone.GetComponent<Warning>().CallCoroutine(new Vector3(spawnPoints[7].transform.position.x, spawnPoints[7].transform.position.y, 4));
                DropChance(1,1);
                break;
        }
        yield return new WaitForSeconds(0.5f);
        Instantiate(smallRectangle, new Vector3(spawnPoints[1].transform.position.x - 100, spawnPoints[1].transform.position.y, 4), Quaternion.identity, parentGameObject);
        Instantiate(circle, new Vector3(spawnPoints[1].transform.position.x, spawnPoints[1].transform.position.y, 4), Quaternion.identity, parentGameObject);
    }
    IEnumerator Hard3()
    {
        Debug.Log("Hard3");
        Instantiate(smallRectangle, new Vector3(spawnPoints[4].transform.position.x - 100, spawnPoints[4].transform.position.y, 4), Quaternion.identity, parentGameObject);
        Instantiate(circle, new Vector3(spawnPoints[1].transform.position.x, spawnPoints[1].transform.position.y, 4), Quaternion.identity, parentGameObject);
        yield return new WaitForSeconds(0.5f);
        Instantiate(enemyMissile, new Vector3(spawnPoints[4].transform.position.x, spawnPoints[4].transform.position.y, 4), Quaternion.identity, parentGameObject);
        yield return new WaitForSeconds(0.7f);
        Instantiate(circle, new Vector3(spawnPoints[1].transform.position.x, spawnPoints[1].transform.position.y, 4), Quaternion.identity, parentGameObject);
        DropChance(2,2);
        Instantiate(enemyMissile, new Vector3(spawnPoints[1].transform.position.x, spawnPoints[4].transform.position.y, 4), Quaternion.identity, parentGameObject);
    }
    IEnumerator Hard4()
    {
        Debug.Log("Hard4");
        Instantiate(smallRectangle, new Vector3(spawnPoints[1].transform.position.x , spawnPoints[1].transform.position.y, 4), Quaternion.identity, parentGameObject);
        Instantiate(circle, new Vector3(spawnPoints[0].transform.position.x, spawnPoints[0].transform.position.y, 4), Quaternion.identity, parentGameObject);
        Instantiate(smallRectangle, new Vector3(spawnPoints[2].transform.position.x, spawnPoints[2].transform.position.y, 4), Quaternion.identity, parentGameObject);
        yield return new WaitForSeconds(1f);
        Instantiate(smallRectangle, new Vector3(spawnPoints[1].transform.position.x, spawnPoints[1].transform.position.y, 4), Quaternion.identity, parentGameObject);
        Instantiate(circle, new Vector3(spawnPoints[1].transform.position.x, spawnPoints[0].transform.position.y, 4), Quaternion.identity, parentGameObject);
        Instantiate(smallRectangle, new Vector3(spawnPoints[2].transform.position.x, spawnPoints[2].transform.position.y, 4), Quaternion.identity, parentGameObject);
        yield return new WaitForSeconds(1f);
        DropChance(0,0);
        Instantiate(smallRectangle, new Vector3(spawnPoints[1].transform.position.x, spawnPoints[1].transform.position.y, 4), Quaternion.identity, parentGameObject);
        Instantiate(circle, new Vector3(spawnPoints[2].transform.position.x, spawnPoints[0].transform.position.y, 4), Quaternion.identity, parentGameObject);
        Instantiate(smallRectangle, new Vector3(spawnPoints[2].transform.position.x, spawnPoints[2].transform.position.y, 4), Quaternion.identity, parentGameObject);
        yield return new WaitForSeconds(1f);
        Instantiate(smallRectangle, new Vector3(spawnPoints[1].transform.position.x, spawnPoints[1].transform.position.y, 4), Quaternion.identity, parentGameObject);
        Instantiate(circle, new Vector3(spawnPoints[1].transform.position.x, spawnPoints[0].transform.position.y, 4), Quaternion.identity, parentGameObject);
        Instantiate(smallRectangle, new Vector3(spawnPoints[2].transform.position.x, spawnPoints[2].transform.position.y, 4), Quaternion.identity, parentGameObject);
        yield return new WaitForSeconds(1f);
        Instantiate(smallRectangle, new Vector3(spawnPoints[1].transform.position.x, spawnPoints[1].transform.position.y, 4), Quaternion.identity, parentGameObject);
        Instantiate(circle, new Vector3(spawnPoints[0].transform.position.x, spawnPoints[0].transform.position.y, 4), Quaternion.identity, parentGameObject);
        Instantiate(smallRectangle, new Vector3(spawnPoints[2].transform.position.x, spawnPoints[2].transform.position.y, 4), Quaternion.identity, parentGameObject);
    }
    IEnumerator Hard5()
    {
        Debug.Log("Hard5");
        Instantiate(enemyMissile, new Vector3(spawnPoints[4].transform.position.x, spawnPoints[4].transform.position.y, 4), Quaternion.identity, parentGameObject);
        Instantiate(enemyMissile, new Vector3(spawnPoints[3].transform.position.x, spawnPoints[3].transform.position.y, 4), Quaternion.identity, parentGameObject);
        cooldown = 15f;
        GameObject clone;
        int m = Random.Range(0, 3);
        int n = Random.Range(0, 3);
        while(n == m)
        {
            n = Random.Range(0, 3);
        }
        switch(m)
        {
            case 0:
                clone = Instantiate(Warning, new Vector3(spawnPoints[5].transform.position.x, spawnPoints[5].transform.position.y, 4), Quaternion.identity, parentGameObject) as GameObject;
                clone.GetComponent<Warning>().CallCoroutine(new Vector3(spawnPoints[5].transform.position.x, spawnPoints[5].transform.position.y, 4));
                DropChance(2,2);
                break;
            case 1:
                clone = Instantiate(Warning, new Vector3(spawnPoints[6].transform.position.x, spawnPoints[6].transform.position.y, 4), Quaternion.identity, parentGameObject) as GameObject;
                clone.GetComponent<Warning>().CallCoroutine(new Vector3(spawnPoints[6].transform.position.x, spawnPoints[6].transform.position.y, 4));
                DropChance(0,0);
                break;
            default:
                clone = Instantiate(Warning, new Vector3(spawnPoints[7].transform.position.x, spawnPoints[7].transform.position.y, 4), Quaternion.identity, parentGameObject) as GameObject;
                clone.GetComponent<Warning>().CallCoroutine(new Vector3(spawnPoints[7].transform.position.x, spawnPoints[7].transform.position.y, 4));
                DropChance(1,1);
                break;
        }
        Instantiate(enemyMissile, new Vector3(spawnPoints[1].transform.position.x, spawnPoints[4].transform.position.y, 4), Quaternion.identity, parentGameObject);
        Instantiate(enemyMissile, new Vector3(spawnPoints[2].transform.position.x, spawnPoints[3].transform.position.y, 4), Quaternion.identity, parentGameObject);
        switch (n)
        {
            case 0:
                clone = Instantiate(Warning, new Vector3(spawnPoints[5].transform.position.x, spawnPoints[5].transform.position.y, 4), Quaternion.identity, parentGameObject) as GameObject;
                clone.GetComponent<Warning>().CallCoroutine(new Vector3(spawnPoints[5].transform.position.x, spawnPoints[5].transform.position.y, 4));
                break;
            case 1:
                clone = Instantiate(Warning, new Vector3(spawnPoints[6].transform.position.x, spawnPoints[6].transform.position.y, 4), Quaternion.identity, parentGameObject) as GameObject;
                clone.GetComponent<Warning>().CallCoroutine(new Vector3(spawnPoints[6].transform.position.x, spawnPoints[6].transform.position.y, 4));
                break;
            default:
                clone = Instantiate(Warning, new Vector3(spawnPoints[7].transform.position.x, spawnPoints[7].transform.position.y, 4), Quaternion.identity, parentGameObject) as GameObject;
                clone.GetComponent<Warning>().CallCoroutine(new Vector3(spawnPoints[7].transform.position.x, spawnPoints[7].transform.position.y, 4));
                break;
        }
        yield return new WaitForSeconds(4f);
        Instantiate(enemyMissile, new Vector3(spawnPoints[0].transform.position.x, spawnPoints[4].transform.position.y, 4), Quaternion.identity, parentGameObject);
        Instantiate(enemyMissile, new Vector3(spawnPoints[2].transform.position.x, spawnPoints[3].transform.position.y, 4), Quaternion.identity, parentGameObject);
        m = Random.Range(0, 3);
        n = Random.Range(0, 3);
        while (n == m)
        {
            n = Random.Range(0, 3);
        }
        switch (m)
        {
            case 0:
                clone = Instantiate(Warning, new Vector3(spawnPoints[5].transform.position.x, spawnPoints[5].transform.position.y, 4), Quaternion.identity, parentGameObject) as GameObject;
                clone.GetComponent<Warning>().CallCoroutine(new Vector3(spawnPoints[5].transform.position.x, spawnPoints[5].transform.position.y, 4));
                DropChance(2,2);
                break;
            case 1:
                clone = Instantiate(Warning, new Vector3(spawnPoints[6].transform.position.x, spawnPoints[6].transform.position.y, 4), Quaternion.identity, parentGameObject) as GameObject;
                clone.GetComponent<Warning>().CallCoroutine(new Vector3(spawnPoints[6].transform.position.x, spawnPoints[6].transform.position.y, 4));
                DropChance(0,0);
                break;
            default:
                clone = Instantiate(Warning, new Vector3(spawnPoints[7].transform.position.x, spawnPoints[7].transform.position.y, 4), Quaternion.identity, parentGameObject) as GameObject;
                clone.GetComponent<Warning>().CallCoroutine(new Vector3(spawnPoints[7].transform.position.x, spawnPoints[7].transform.position.y, 4));
                DropChance(1,1);
                break;
        }
        Instantiate(enemyMissile, new Vector3(spawnPoints[4].transform.position.x, spawnPoints[4].transform.position.y, 4), Quaternion.identity, parentGameObject);
        Instantiate(enemyMissile, new Vector3(spawnPoints[1].transform.position.x, spawnPoints[3].transform.position.y, 4), Quaternion.identity, parentGameObject);
        switch (n)
        {
            case 0:
                clone = Instantiate(Warning, new Vector3(spawnPoints[5].transform.position.x, spawnPoints[5].transform.position.y, 4), Quaternion.identity, parentGameObject) as GameObject;
                clone.GetComponent<Warning>().CallCoroutine(new Vector3(spawnPoints[5].transform.position.x, spawnPoints[5].transform.position.y, 4));
                break;
            case 1:
                clone = Instantiate(Warning, new Vector3(spawnPoints[6].transform.position.x, spawnPoints[6].transform.position.y, 4), Quaternion.identity, parentGameObject) as GameObject;
                clone.GetComponent<Warning>().CallCoroutine(new Vector3(spawnPoints[6].transform.position.x, spawnPoints[6].transform.position.y, 4));
                break;
            default:
                clone = Instantiate(Warning, new Vector3(spawnPoints[7].transform.position.x, spawnPoints[7].transform.position.y, 4), Quaternion.identity, parentGameObject) as GameObject;
                clone.GetComponent<Warning>().CallCoroutine(new Vector3(spawnPoints[7].transform.position.x, spawnPoints[7].transform.position.y, 4));
                break;
        }
        yield return new WaitForSeconds(4f);
        Instantiate(enemyMissile, new Vector3(spawnPoints[2].transform.position.x, spawnPoints[4].transform.position.y, 4), Quaternion.identity, parentGameObject);
        Instantiate(enemyMissile, new Vector3(spawnPoints[0].transform.position.x, spawnPoints[3].transform.position.y, 4), Quaternion.identity, parentGameObject);
        m = Random.Range(0, 3);
        n = Random.Range(0, 3);
        while (n == m)
        {
            n = Random.Range(0, 3);
        }
        switch (m)
        {
            case 0:
                clone = Instantiate(Warning, new Vector3(spawnPoints[5].transform.position.x, spawnPoints[5].transform.position.y, 4), Quaternion.identity, parentGameObject) as GameObject;
                clone.GetComponent<Warning>().CallCoroutine(new Vector3(spawnPoints[5].transform.position.x, spawnPoints[5].transform.position.y, 4));
                DropChance(2,2);
                break;
            case 1:
                clone = Instantiate(Warning, new Vector3(spawnPoints[6].transform.position.x, spawnPoints[6].transform.position.y, 4), Quaternion.identity, parentGameObject) as GameObject;
                clone.GetComponent<Warning>().CallCoroutine(new Vector3(spawnPoints[6].transform.position.x, spawnPoints[6].transform.position.y, 4));
                DropChance(0,0);
                break;
            default:
                clone = Instantiate(Warning, new Vector3(spawnPoints[7].transform.position.x, spawnPoints[7].transform.position.y, 4), Quaternion.identity, parentGameObject) as GameObject;
                clone.GetComponent<Warning>().CallCoroutine(new Vector3(spawnPoints[7].transform.position.x, spawnPoints[7].transform.position.y, 4));
                DropChance(1,1);
                break;
        }
        Instantiate(enemyMissile, new Vector3(spawnPoints[1].transform.position.x, spawnPoints[4].transform.position.y, 4), Quaternion.identity, parentGameObject);
        Instantiate(enemyMissile, new Vector3(spawnPoints[3].transform.position.x, spawnPoints[3].transform.position.y, 4), Quaternion.identity, parentGameObject);
        switch (n)
        {
            case 0:
                clone = Instantiate(Warning, new Vector3(spawnPoints[5].transform.position.x, spawnPoints[5].transform.position.y, 4), Quaternion.identity, parentGameObject) as GameObject;
                clone.GetComponent<Warning>().CallCoroutine(new Vector3(spawnPoints[5].transform.position.x, spawnPoints[5].transform.position.y, 4));
                break;
            case 1:
                clone = Instantiate(Warning, new Vector3(spawnPoints[6].transform.position.x, spawnPoints[6].transform.position.y, 4), Quaternion.identity, parentGameObject) as GameObject;
                clone.GetComponent<Warning>().CallCoroutine(new Vector3(spawnPoints[6].transform.position.x, spawnPoints[6].transform.position.y, 4));
                break;
            default:
                clone = Instantiate(Warning, new Vector3(spawnPoints[7].transform.position.x, spawnPoints[7].transform.position.y, 4), Quaternion.identity, parentGameObject) as GameObject;
                clone.GetComponent<Warning>().CallCoroutine(new Vector3(spawnPoints[7].transform.position.x, spawnPoints[7].transform.position.y, 4));
                break;
        }
        yield return new WaitForSeconds(4f);
        Instantiate(enemyMissile, new Vector3(spawnPoints[4].transform.position.x, spawnPoints[4].transform.position.y, 4), Quaternion.identity, parentGameObject);
        Instantiate(enemyMissile, new Vector3(spawnPoints[3].transform.position.x, spawnPoints[3].transform.position.y, 4), Quaternion.identity, parentGameObject);
        m = Random.Range(0, 3);
        n = Random.Range(0, 3);
        while (n == m)
        {
            n = Random.Range(0, 3);
        }
        switch (m)
        {
            case 0:
                clone = Instantiate(Warning, new Vector3(spawnPoints[5].transform.position.x, spawnPoints[5].transform.position.y, 4), Quaternion.identity, parentGameObject) as GameObject;
                clone.GetComponent<Warning>().CallCoroutine(new Vector3(spawnPoints[5].transform.position.x, spawnPoints[5].transform.position.y, 4));
                break;
            case 1:
                clone = Instantiate(Warning, new Vector3(spawnPoints[6].transform.position.x, spawnPoints[6].transform.position.y, 4), Quaternion.identity, parentGameObject) as GameObject;
                clone.GetComponent<Warning>().CallCoroutine(new Vector3(spawnPoints[6].transform.position.x, spawnPoints[6].transform.position.y, 4));
                break;
            default:
                clone = Instantiate(Warning, new Vector3(spawnPoints[7].transform.position.x, spawnPoints[7].transform.position.y, 4), Quaternion.identity, parentGameObject) as GameObject;
                clone.GetComponent<Warning>().CallCoroutine(new Vector3(spawnPoints[7].transform.position.x, spawnPoints[7].transform.position.y, 4));
                break;
        }
        Instantiate(enemyMissile, new Vector3(spawnPoints[1].transform.position.x, spawnPoints[4].transform.position.y, 4), Quaternion.identity, parentGameObject);
        Instantiate(enemyMissile, new Vector3(spawnPoints[2].transform.position.x, spawnPoints[3].transform.position.y, 4), Quaternion.identity, parentGameObject);
        switch (n)
        {
            case 0:
                clone = Instantiate(Warning, new Vector3(spawnPoints[5].transform.position.x, spawnPoints[5].transform.position.y, 4), Quaternion.identity, parentGameObject) as GameObject;
                clone.GetComponent<Warning>().CallCoroutine(new Vector3(spawnPoints[5].transform.position.x, spawnPoints[5].transform.position.y, 4));
                break;
            case 1:
                clone = Instantiate(Warning, new Vector3(spawnPoints[6].transform.position.x, spawnPoints[6].transform.position.y, 4), Quaternion.identity, parentGameObject) as GameObject;
                clone.GetComponent<Warning>().CallCoroutine(new Vector3(spawnPoints[6].transform.position.x, spawnPoints[6].transform.position.y, 4));
                break;
            default:
                clone = Instantiate(Warning, new Vector3(spawnPoints[7].transform.position.x, spawnPoints[7].transform.position.y, 4), Quaternion.identity, parentGameObject) as GameObject;
                clone.GetComponent<Warning>().CallCoroutine(new Vector3(spawnPoints[7].transform.position.x, spawnPoints[7].transform.position.y, 4));
                break;
        }
        cooldown = defaultCooldown;
    }

    public void DropChance(int x, int y)
    {
        tetrahedronChance = Mathf.Clamp(tetrahedronChance, 0, 6);
        bulletChance = Mathf.Clamp(bulletChance, 7, 100);
        chance = Random.Range(0, 101);
        if (chance <= tetrahedronChance)
        {
            Instantiate(tetrahedron, new Vector3(spawnPoints[x].transform.position.x, spawnPoints[y].transform.position.y, 4), Quaternion.identity, parentGameObject);
        }
        if(chance >= bulletChance && upgrades.missileEnabled)
        {
            Instantiate(ammo, new Vector3(spawnPoints[x].transform.position.x, spawnPoints[y].transform.position.y, 4), Quaternion.identity, parentGameObject);
        }
    }
    public void CheckChance()
    {
        tetrahedronChance = upgrades.tetrahedronChance;
        bulletChance = upgrades.bulletChance;
    }

}
