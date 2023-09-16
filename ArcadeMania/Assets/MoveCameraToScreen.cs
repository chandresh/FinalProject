using UnityEngine;

public class MoveCameraToScreen : MonoBehaviour
{
    public Transform[] cameraZones;  // Array of camera zones (Transforms)
    public float transitionSpeed = 2.0f;  // Speed of camera movement
    public Transform player;

    private int currentZone = 0;  // The current camera zone index
    private Transform cameraTransform;

    void Start()
    {
        cameraTransform = GetComponent<Transform>();
        SpawnEnemiesForZone(currentZone);
    }

    void Update()
    {
        Vector3 screenPos = Camera.main.WorldToViewportPoint(player.position);

        // Check if the player is out of the screen on the right side
        if (screenPos.x > 1 && currentZone < cameraZones.Length - 1)
        {
            currentZone++;
            SpawnEnemiesForZone(currentZone);
        }
        // Check if the player is out of the screen on the left side
        else if (screenPos.x < 0 && currentZone > 0)
        {
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
        int enemyCount = UnityEngine.Random.Range(2, 8);

        for (int i = 0; i < enemyCount; i++)
        {
            GameObject enemy = EnemyPool.Instance.GetEnemy();
            Vector3 spawnPos = new Vector3(
                UnityEngine.Random.Range(cameraZones[zone].position.x - 5, cameraZones[zone].position.x + 10),
                UnityEngine.Random.Range(cameraZones[zone].position.y - 6, cameraZones[zone].position.y - 8),
                0
            );

            enemy.transform.position = spawnPos;
            enemy.SetActive(true);
        }
    }
}
