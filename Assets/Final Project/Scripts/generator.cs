using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generator : MonoBehaviour
{
    public Transform[] Spawners;
    public GameObject EnemyPrefab;
    public float maxWaitTime;
    bool readyToSpawn = true;



    // Update is called once per frame
    void Update()
    {
        if (readyToSpawn && GameObject.FindObjectsOfType<enemyBlendTree>().Length <= 15)
            StartCoroutine("Spawn");

        if (GameManager.GetScore() > 10)
        {
            maxWaitTime = 100 / GameManager.GetScore() / 2;
        }
    }

    public IEnumerator Spawn() 
    {
        readyToSpawn = false;
        yield return new WaitForSeconds(Random.Range(0,maxWaitTime));
        int spawn = Random.Range(0, Spawners.Length);
        GameObject instance = Instantiate(EnemyPrefab, Spawners[spawn].position, Spawners[spawn].rotation, null);
        if (GameManager.GetScore() > 10)
        {
            instance.GetComponent<enemyBlendTree>().runSpeed = EnemyPrefab.GetComponent<enemyBlendTree>().runSpeed + GameManager.GetScore() / 70;
        }
            readyToSpawn = true;
    }
}
