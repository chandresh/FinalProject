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

            // Save Game Data
            GameData.UpdateHighestRound(2);
            GameData.LoadingStatus = GameLoadingStatus.Won;
            GameData.SetStatusMessage();
            GameData.SaveData();

            Debug.Log("First Won - " + GameData.StatusMessage + " - " + GameData.HighestRound + " - " + GameData.LoadingStatus);

            // Load the intro scene
            SceneManager.LoadScene(0);
        }
    }

}
