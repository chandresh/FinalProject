using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KeyCollisionController : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        // If player collects the key - the player wins the round
        if (other.CompareTag("Player") || other.CompareTag("PlayerParts") || other.CompareTag("PlayerShield"))
        {

            // Play the Game Won Sound
            AudioManager.instance.PlayRoundWonSound();

            // Save Game Data
            GameData.UpdateHighestRound(4);
            GameData.LoadingStatus = GameLoadingStatus.Won;
            GameData.SetStatusMessage();
            GameData.SaveData();


            // Load the intro scene
            SceneManager.LoadScene(0);
        }

        // Destroy this key if it collides with anything
        Destroy(gameObject);
    }
}
