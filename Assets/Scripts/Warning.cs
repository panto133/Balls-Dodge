using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warning : MonoBehaviour
{
    SpriteRenderer sprite;
    public GameObject superSpike;
    GameObject parentGameObject;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        parentGameObject = GameObject.Find("Enemies");
        sprite.enabled = false;
    }
    public IEnumerator Danger(Vector3 pos)
    {
        yield return new WaitForSeconds(0.5f);
        sprite.enabled = true;
        yield return new WaitForSeconds(0.5f);
        sprite.enabled = false;
        yield return new WaitForSeconds(0.5f);
        sprite.enabled = true;
        yield return new WaitForSeconds(0.5f);
        sprite.enabled = false;     
        yield return new WaitForSeconds(0.5f);
        sprite.enabled = true;
        yield return new WaitForSeconds(0.5f);
        sprite.enabled = false;
        Instantiate(superSpike, pos, Quaternion.identity, parentGameObject.transform);
        Destroy(gameObject);
    }
    public void CallCoroutine(Vector3 pos)
    {
        StartCoroutine(Danger(pos));
    }
}
