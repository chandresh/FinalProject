using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject iceBrickPrefab, keyPrefab;

    [SerializeField] float minKeySpawnTime = 20f, maxKeySpawnTime = 30f;

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
            Instantiate(iceBrickPrefab, spawnPoints[spawnIndex].position, spawnPoints[spawnIndex].rotation);
            timer = Time.time + spawnDelay;
        }

        //randomly between min and max set time spawn a key
        Invoke("SpawnKey", Random.Range(minKeySpawnTime, maxKeySpawnTime));
    }

    private void SpawnKey()
    {
        // Find object by tag "key" and if it is null then spawn a key
        if (GameObject.FindWithTag("Key") == null)
        {
            int spawnIndex = Random.Range(0, spawnPoints.Length);
            Instantiate(keyPrefab, spawnPoints[spawnIndex].position, spawnPoints[spawnIndex].rotation);
        }
    }
}
