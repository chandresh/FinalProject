using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject iceBrickPrefab, keyPrefab;
    [SerializeField] float minKeySpawnTime = 20f, maxKeySpawnTime = 30f;
    public Transform[] spawnPoints;
    private float brickTimer;
    private float keyTimer;
    public float spawnDelay = 1f;

    // Start is called before the first frame update
    void Start()
    {
        brickTimer = Time.time + spawnDelay;
        keyTimer = Time.time + Random.Range(minKeySpawnTime, maxKeySpawnTime); // Initialize keyTimer
    }

    // Update is called once per frame
    void Update()
    {
        // Ice Brick Spawning
        if (brickTimer < Time.time)
        {
            int spawnIndex = Random.Range(0, spawnPoints.Length);
            Instantiate(iceBrickPrefab, spawnPoints[spawnIndex].position, spawnPoints[spawnIndex].rotation);
            brickTimer = Time.time + spawnDelay;
        }

        // Key Spawning
        if (keyTimer < Time.time)
        {
            SpawnKey();
            keyTimer = Time.time + Random.Range(minKeySpawnTime, maxKeySpawnTime); // Reset the keyTimer
        }
    }

    private void SpawnKey()
    {
        // Find object by tag "Key" and if it is null then spawn a key
        if (GameObject.FindWithTag("Key") == null)
        {
            int spawnIndex = Random.Range(0, spawnPoints.Length);
            Instantiate(keyPrefab, spawnPoints[spawnIndex].position, spawnPoints[spawnIndex].rotation);
        }
    }
}
