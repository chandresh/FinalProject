using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class DoorController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the player has touched the door
        if (other.CompareTag("Player") || other.CompareTag("PlayerParts"))
        {
            // Save Game Data
            GameData.UpdateHighestRound(2);
            GameData.LoadingStatus = GameLoadingStatus.Won;
            GameData.SetStatusMessage();
            GameData.SaveData();

            // Load the intro scene
            StartCoroutine(LoadIntroAfterSound());
        }
    }

    IEnumerator LoadIntroAfterSound()
    {
        AudioManager.instance.PlayRoundWonSound();
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(0);
    }


}
