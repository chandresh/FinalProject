using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform[] spawnPoints;
    private float timer;
    public float spawnDelay = 1f;

    // Start is called before the first frame update
    void Start()
    {
        timer = Time.time + spawnDelay;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < Time.time)
        {
            int spawnIndex = Random.Range(0, spawnPoints.Length);
            // Instantiate(enemyPrefab, spawnPoints[spawnIndex].position, spawnPoints[spawnIndex].rotation);
            timer = Time.time + spawnDelay;
        }

    }
}
