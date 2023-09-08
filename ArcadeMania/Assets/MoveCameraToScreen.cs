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
    }

    void Update()
    {
        Vector3 screenPos = Camera.main.WorldToViewportPoint(player.position);

        // Check if the player is out of the screen on the right side
        if (screenPos.x > 1 && currentZone < cameraZones.Length - 1)
        {
            currentZone++;
        }
        // Check if the player is out of the screen on the left side
        else if (screenPos.x < 0 && currentZone > 0)
        {
            currentZone--;
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
}
