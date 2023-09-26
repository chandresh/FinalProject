using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    // Singleton enemy pool
    public static EnemyPool Instance;

    // Reference to the enemy prefab
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject snailPrefab;

    // Pool size
    [SerializeField] int initialPoolSize = 10;

    // Queues of enemies to fetch from
    private Queue<GameObject> enemyPool;
    private Queue<GameObject> snailPool;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        enemyPool = new Queue<GameObject>();
        snailPool = new Queue<GameObject>();

        InitializePool(enemyPool, enemyPrefab);
        InitializePool(snailPool, snailPrefab);
    }

    private void InitializePool(Queue<GameObject> pool, GameObject prefab)
    {
        for (int i = 0; i < initialPoolSize; i++)
        {
            GameObject enemy = Instantiate(prefab);
            enemy.SetActive(false);
            pool.Enqueue(enemy);
        }
    }


    public GameObject GetEnemy()
    {
        return this.GetEnemy("Enemy");
    }

    public GameObject GetEnemy(string type)
    {
        Queue<GameObject> pool = (type == "Snail") ? snailPool : enemyPool;
        GameObject prefab = (type == "Snail") ? snailPrefab : enemyPrefab;

        if (pool.Count == 0)
        {
            GameObject enemy = Instantiate(prefab);
            enemy.SetActive(false);
            pool.Enqueue(enemy);
        }

        return pool.Dequeue();
    }

    public void ReturnToPool(GameObject enemy, string type)
    {
        enemy.SetActive(false);
        Queue<GameObject> pool = (type == "Snail") ? snailPool : enemyPool;
        pool.Enqueue(enemy);
    }
}
