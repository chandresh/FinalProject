using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorController : MonoBehaviour
{

    GameData gameData;

    void Start()
    {
        gameData = new GameData();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the player has entered the door using compareTag
        if (other.CompareTag("Player") || other.CompareTag("PlayerParts"))
        {
            Debug.Log("DoorController OnTriggerEnter2D Player");

            // Save Game Data
            gameData.UpdateHighestRound(2);
            // TODO: Update highest score
            gameData.SaveData();

            // Load the next scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

}
