using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    public GameObject enemy;

    public GameObject spawn1;
    public GameObject spawn2;
    public GameObject spawn3;
    public GameObject spawn4;
    public GameObject spawn5;

    public bool portalOn = true;
    public float timePortalOn = 0.0f;
    public bool armadilha = true;

    public bool bridgeReached = true;
    public bool secondpart = true;
    public bool thirdpart = true;
    public bool topMoutain = true;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        //spawn5.SetActive(false);
        StartCoroutine(SpawnManager());

        yield return null;
    }

    // Update is called once per frame
    void Update()
    {
        //Pára de instanciar quando o portal termina de liberar a horda
        if (portalOn == false)
        {
            StopCoroutine("Portal1e4");
            StopCoroutine("Portal2e3");
            Debug.Log("parou routina portal 1");
        }

        // if (topMoutain)
        //{
        //    armadilha = true;
        // }
    }

    //Coordena todos os portais da fase.
    IEnumerator SpawnManager()
    {
        Debug.Log("começou a fase " + Time.time);

        if (bridgeReached)
        {
            portalOn = true;
            yield return StartCoroutine(Portal1e4(enemy, spawn1, timePortalOn));
            portalOn = false;
            spawn1.SetActive(false);
            Debug.Log("terminou a horda do portal 1");
        }

        if (secondpart)
        {
            portalOn = true;
            yield return StartCoroutine(Portal2e3(enemy, spawn2, spawn3, timePortalOn));
            portalOn = false;
            Debug.Log("terminou a horda do portal 2 e 3");
        }

        if (thirdpart)
        {
            portalOn = true;
            yield return StartCoroutine(Portal1e4(enemy, spawn4, timePortalOn));
            portalOn = false;
            spawn4.SetActive(false);
            Debug.Log("terminou a horda do portal 4");
        }

        if (armadilha)
        {
            //StartArmadilha();
            //ou
            portalOn = true;
            //spawn5.SetActive(true);
            yield return StartCoroutine(Portal5(enemy, spawn5, 5f));
            portalOn = false;
        }
    }

    IEnumerator Portal1e4(GameObject enemy, GameObject spawnPortal, float WaitTime)
    {
        Vector2 whereToSpawn;

        float initialTime = Time.time + WaitTime;

        while (Time.time < initialTime)
        {
            yield return new WaitForSeconds(Random.Range(1f, 3f));

            whereToSpawn = new Vector2(spawnPortal.transform.position.x, spawnPortal.transform.position.y);
            Instantiate(enemy, whereToSpawn, Quaternion.identity);
            Debug.Log("chega um inimigo no portal 1 " + Time.time);
        }
    }


    IEnumerator Portal2e3(GameObject enemy, GameObject spawnPortal2, GameObject spawnPortal3, float WaitTime)
    {
        Vector2 whereToSpawn;
        float localBornPortal2, localBornPortal3;
        float initialTime = Time.time + WaitTime;

        while (Time.time < initialTime)
        {
            yield return new WaitForSeconds(Random.Range(1f, 2f));
            localBornPortal2 = Random.Range(-2f, 2f);
            whereToSpawn = new Vector2(spawnPortal2.transform.position.x - localBornPortal2, spawnPortal2.transform.position.y);
            spawnPortal2.transform.position = new Vector2(spawnPortal2.transform.position.x - localBornPortal2, spawnPortal2.transform.position.y);
            Instantiate(enemy, whereToSpawn, Quaternion.identity);
            Debug.Log("chega um inimigo no portal 2 " + Time.time);

            yield return new WaitForSeconds(Random.Range(1f, 2f));
            localBornPortal3 = Random.Range(-2f, 2f);
            whereToSpawn = new Vector2(spawnPortal3.transform.position.x - localBornPortal3, spawnPortal3.transform.position.y);
            spawnPortal3.transform.position = new Vector2(spawnPortal3.transform.position.x - localBornPortal3, spawnPortal3.transform.position.y);
            Instantiate(enemy, whereToSpawn, Quaternion.identity);
            Debug.Log("chega um inimigo no portal 3 " + Time.time);
        }
    }

    IEnumerator Portal5(GameObject enemy, GameObject spawnPortal, float WaitTime)
    {
        Vector2 whereToSpawn;
        float initialTime = Time.time + WaitTime;

        while (Time.time < initialTime)
        {
            yield return new WaitForSeconds(Random.Range(1f, 2f));

            whereToSpawn = new Vector2(spawnPortal.transform.position.x, spawnPortal.transform.position.y);
            Instantiate(enemy, whereToSpawn, Quaternion.identity);
            Debug.Log("chega um inimigo no portal 5 " + Time.time);
        }

        yield return new WaitForSeconds(1f);
        spawnPortal.SetActive(false);
        topMoutain = false;
    }

    //IEnumerator StartArmadilha()
    //{
    //    portalOn = true;
    //    spawn5.SetActive(true);
    //    yield return StartCoroutine(Portal5(enemy, spawn5, 5f));
    //    portalOn = false;
    //}
}
