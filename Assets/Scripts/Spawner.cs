using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    // Variables
    bool isSpawning = false;
    public float minTime = 5.0f;
    public float maxTime = 15.0f;
    public GameObject[] enemies;

    IEnumerator SpawnObject(int index, float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Instantiate(enemies[index], transform.position, transform.rotation);
   
        isSpawning = false;
    }

    // Update is called once per frame
    void Update ()
    {
        if (!isSpawning)
        {
            isSpawning = true;
            int enemyIndex = Random.Range(0, enemies.Length);
            StartCoroutine(SpawnObject(enemyIndex, Random.Range(minTime, maxTime)));
        }
    }
}
