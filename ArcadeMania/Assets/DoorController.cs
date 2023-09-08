using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorController : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the player has entered the door using compareTag
        if (other.CompareTag("Player") || other.CompareTag("PlayerParts"))
        {
            Debug.Log("DoorController OnTriggerEnter2D Player");

            // Load the next scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

}
