using UnityEngine;
using System.Collections.Generic;


public class MoveCameraToScreen : MonoBehaviour
{
    public Transform[] cameraZones;  // Array of camera zones (Transforms)
    public float transitionSpeed = 2.0f;  // Speed of camera movement
    public Transform player;

    private int currentZone = 0;  // The current camera zone index

    // Store a list of enemies for each zone
    // This is to fix the issue of enemies keep increasing
    // when the player moves back and forth between zones
    private List<GameObject>[] zoneEnemies;
    private Transform cameraTransform;

    void Start()
    {
        cameraTransform = GetComponent<Transform>();

        // Initialize the list of enemies for each zone
        zoneEnemies = new List<GameObject>[cameraZones.Length];

        for (int i = 0; i < cameraZones.Length; i++)
        {
            zoneEnemies[i] = new List<GameObject>();
        }
        SpawnEnemiesForZone(currentZone);
    }

    void Update()
    {
        Vector3 screenPos = Camera.main.WorldToViewportPoint(player.position);

        // Check if the player is out of the screen on the right side
        if (screenPos.x > 1 && currentZone < cameraZones.Length - 1)
        {
            // Deactivate all enemies in the current zone
            DeactivateEnemiesForZone(currentZone);

            currentZone++;
            SpawnEnemiesForZone(currentZone);
        }
        // Check if the player is out of the screen on the left side
        else if (screenPos.x < 0 && currentZone > 0)
        {
            // Deactivate all enemies in the current zone
            DeactivateEnemiesForZone(currentZone);
            currentZone--;
            SpawnEnemiesForZone(currentZone);
        }

        // Move camera to the new zone
        Vector3 targetPosition = new Vector3(
            cameraZones[currentZone].position.x,
            cameraZones[currentZone].position.y,
            cameraTransform.position.z
        );

        cameraTransform.position = Vector3.Lerp(
            cameraTransform.position,
            targetPosition,
            Time.deltaTime * transitionSpeed
        );
    }

    void SpawnEnemiesForZone(int zone)
    {
        // Only spawn enemies if the list for this zone is empty
        if (zoneEnemies[zone].Count == 0)
        {
            // Spawn "Enemy" type enemies
            int enemyCount = UnityEngine.Random.Range(2, 5);
            for (int i = 0; i < enemyCount; i++)
            {
                GameObject enemy = EnemyPool.Instance.GetEnemy("Enemy");
                Vector3 spawnPos = new Vector3(
                    UnityEngine.Random.Range(cameraZones[zone].position.x - 5, cameraZones[zone].position.x + 10),
                    UnityEngine.Random.Range(cameraZones[zone].position.y - 6, cameraZones[zone].position.y - 8),
                    0
                );
                enemy.transform.position = spawnPos;
                enemy.SetActive(true);
                zoneEnemies[zone].Add(enemy); // Add the enemy to the list for this zone
            }

            // Spawn "Snail" type enemies
            int snailCount = UnityEngine.Random.Range(1, 3);
            for (int i = 0; i < snailCount; i++)
            {
                GameObject snail = EnemyPool.Instance.GetEnemy("Snail");
                Vector3 spawnPos = new Vector3(
                    UnityEngine.Random.Range(cameraZones[zone].position.x - 5, cameraZones[zone].position.x + 10),
                    UnityEngine.Random.Range(cameraZones[zone].position.y + 8, cameraZones[zone].position.y + 3),
                    0
                );
                snail.transform.position = spawnPos;
                snail.SetActive(true);
                zoneEnemies[zone].Add(snail); // Add the snail to the list for this zone
            }
        }
        else
        {
            // Reactivate enemies for this zone
            foreach (GameObject enemy in zoneEnemies[zone])
            {
                enemy.SetActive(true);
            }
        }
    }


    void DeactivateEnemiesForZone(int zone)
    {
        for (int i = zoneEnemies[zone].Count - 1; i >= 0; i--)
        {
            GameObject enemy = zoneEnemies[zone][i];

            if (enemy == null)
            {
                zoneEnemies[zone].RemoveAt(i);
                continue;
            }

            enemy.SetActive(false);
        }
    }

}
