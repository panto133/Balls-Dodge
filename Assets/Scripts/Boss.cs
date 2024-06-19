using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Boss : MonoBehaviour
{
    public GameObject spike;
    public GameObject obstacle;
    public GameObject warning;
    public GameObject circle;
    public GameObject rotatingDoubleRectangle;
    public GameObject rotatingRectangle;
    public GameObject spear;
    public GameObject missile;
    public GameObject particle;
    public GameObject prefab;

    GameObject clone;
    Touch touch;

    public Transform parent;

    public Slider slider;

    private Vector2 pos1;
    private Vector2 pos2;
    private Vector2 pos3;

    public Rigidbody2D rb;

    [SerializeField]
    private float HP = 1000f;
    private float timer = 3f;
    private int counter = 0;

    private int prev = -1;
    private int i;

    private bool didntAppear = true;

    private RaycastHit2D hit;

    Boss()
    {
        pos1 = new Vector3(-1f, 6f, -1f);
        pos2 = new Vector3(0f, 6f, -1f);
        pos3 = new Vector3(1f, 6f, -1f);
    }
    private void Update()
    {
        if(didntAppear)
            Appear();
        slider.value = HP;
        if (HP <= 0f)
        {
            GameObject.Find("Spawner").GetComponent<Spawning>().bossKilled = true;
            GameObject.Find("Spawner").GetComponent<Spawning>().score.enabled = true;
            GameObject.Find("GameLogic").GetComponent<GameLogic>().pentagons += 2000;
            GameObject.Find("Spawner").GetComponent<Spawning>().BossKilled();
            Instantiate(prefab, new Vector3(0, 5, 0), Quaternion.identity);
            Destroy(gameObject);
            Instantiate(particle, transform.position, Quaternion.identity);
        }
        timer += Time.deltaTime;
        if(timer >= 3f)
        {
            Randomize();
            timer = 0f;
        }
    }

    private void FixedUpdate()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(touch.position), Vector2.zero);
            if (hit.collider != null && touch.phase == TouchPhase.Began)
            {
                if (hit.collider.name == "Boss(Clone)")
                {
                    HP -= 10f;
                }
            }
        }
        if(Input.GetMouseButton(0))
        {
            hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null)
            {
                if (hit.collider.name == "Boss(Clone)")
                {
                    HP -= 10f;
                }
            }
        }
    }
    private void Randomize()
    {
        while (i == prev)
        {
            i = Random.Range(1, 10);
            counter++;
            if (counter >= 10)
            {
                break;
            }
        }
        prev = i;
        counter = 0;
        switch(i)
        {
            case 1:
                StartCoroutine(Wave1());
                break;
            case 2:
                StartCoroutine(Wave2());
                break;
            case 3:
                StartCoroutine(Wave3());
                break;
            case 4:
                StartCoroutine(Wave4());
                break;
            case 5:
                StartCoroutine(Wave5());
                break;
            case 6:
                StartCoroutine(Wave6());
                break;
            case 7:
                StartCoroutine(Wave7());
                break;
            case 8:
                StartCoroutine(Wave8());
                break;
            case 9:
                StartCoroutine(Wave9());
                break;
        }
    }
    private void Appear()
    {
        float speed = 100f;       
        if(transform.position.y <= 6f)
        {
            rb.velocity = new Vector2(0, 0);
            didntAppear = false;
        }
        else
        {
            rb.velocity = Vector2.down * Time.deltaTime * speed;
        }
    }
    IEnumerator Wave1()
    {
        Instantiate(spike, pos1, Quaternion.identity, parent);
        Instantiate(spike, pos3, Quaternion.identity, parent);
        yield return new WaitForSeconds(1f);
        Instantiate(missile, pos2, Quaternion.identity, parent);
    }
    IEnumerator Wave2()
    {
        Instantiate(spike, pos1, Quaternion.identity, parent);
        Instantiate(spike, pos2, Quaternion.identity, parent);
        yield return new WaitForSeconds(1f);
        Instantiate(missile, pos3, Quaternion.identity, parent);
    }
    IEnumerator Wave3()
    {
        Instantiate(spike, pos2, Quaternion.identity, parent);
        Instantiate(spike, pos3, Quaternion.identity, parent);
        yield return new WaitForSeconds(1f);
        Instantiate(missile, pos1, Quaternion.identity, parent);
    }
    IEnumerator Wave4()
    {
        Instantiate(rotatingDoubleRectangle, pos2, Quaternion.identity, parent);
        yield return new WaitForSeconds(1f);
        Debug.Log("Wave4");
    }
    IEnumerator Wave5()
    {
        Instantiate(rotatingRectangle, pos1, Quaternion.identity, parent);
        yield return new WaitForSeconds(1f);
        Instantiate(rotatingRectangle, pos3, Quaternion.identity, parent);
    }
    IEnumerator Wave6()
    {
        Instantiate(missile, pos1, Quaternion.identity, parent);
        Instantiate(missile, pos2, Quaternion.identity, parent);
        Instantiate(missile, pos3, Quaternion.identity, parent);
        yield return new WaitForSeconds(1.5f);
        Instantiate(missile, pos1, Quaternion.identity, parent);
        Instantiate(missile, pos2, Quaternion.identity, parent);
        Instantiate(missile, pos3, Quaternion.identity, parent);
    }
    IEnumerator Wave7()
    {
        Instantiate(circle, pos3, Quaternion.identity, parent);
        yield return new WaitForSeconds(.5f);
        Instantiate(circle, pos2, Quaternion.identity, parent);
        yield return new WaitForSeconds(.5f);
        Instantiate(circle, pos1, Quaternion.identity, parent);
    }
    IEnumerator Wave8()
    {
        Instantiate(spear, pos1, Quaternion.identity, parent);
        yield return new WaitForSeconds(.5f);
        Instantiate(circle, pos2, Quaternion.identity, parent);
    }
    IEnumerator Wave9()
    {
        clone = Instantiate(warning, new Vector3(pos1.x, pos1.y - 2, 2f), Quaternion.identity, parent) as GameObject;
        clone.GetComponent<Warning>().CallCoroutine(pos1);
        clone = Instantiate(warning, new Vector3(pos3.x, pos3.y - 2, 2f), Quaternion.identity, parent) as GameObject;
        clone.GetComponent<Warning>().CallCoroutine(pos3);
        Instantiate(obstacle, pos2, Quaternion.identity, parent);
        yield return new WaitForSeconds(.5f);
        Debug.Log("Wave9");
    }
}
