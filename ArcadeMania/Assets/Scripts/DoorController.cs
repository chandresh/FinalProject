using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorController : MonoBehaviour
{



    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the player has entered the door using compareTag
        if (other.CompareTag("Player") || other.CompareTag("PlayerParts"))
        {
            // Save Game Data
            GameData.UpdateHighestRound(2);
            GameData.LoadingStatus = GameLoadingStatus.Won;
            GameData.SetStatusMessage();
            GameData.SaveData();

            // Load the intro scene
            SceneManager.LoadScene(0);
        }
    }

}
