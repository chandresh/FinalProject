using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    // Singleton enemy pool
    public static EnemyPool Instance;

    // Reference to the enemy prefab
    [SerializeField] GameObject enemyPrefab;

    // Pool size
    [SerializeField] int initialPoolSize = 10;

    // Queue of enemies to fetch from
    private Queue<GameObject> enemyPool;

    void Awake()
    {
        // Singleton - only one pool
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        // Initialize the pool
        enemyPool = new Queue<GameObject>();
        for (int i = 0; i < initialPoolSize; i++)
        {
            GameObject enemy = Instantiate(enemyPrefab);
            enemy.SetActive(false);
            enemyPool.Enqueue(enemy);
        }
    }

    public GameObject GetEnemy()
    {
        if (enemyPool.Count == 0)
        {
            // Create new enemy if pool is empty
            GameObject enemy = Instantiate(enemyPrefab);

            // Keep the enemy inactive and add to the pool
            enemy.SetActive(false);
            enemyPool.Enqueue(enemy);
        }

        return enemyPool.Dequeue();
    }

    public void ReturnToPool(GameObject enemy)
    {
        enemy.SetActive(false);
        enemyPool.Enqueue(enemy);
    }
}
