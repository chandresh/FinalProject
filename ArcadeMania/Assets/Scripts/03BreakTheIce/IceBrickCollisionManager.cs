using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IceBrickCollisionManager : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // If the other object has a tag Ball
        if (other.CompareTag("Ball"))
        {
            AudioManager.instance.PlayBulletHitSound();
            // Destroy this IceBrick
            Destroy(gameObject);
        }

        // If the other object has a tag PlayerShield then destroy the PlayerShield
        if (other.CompareTag("PlayerShield"))
        {
            AudioManager.instance.PlayBulletHitSound();
            // Destroy the player
            Destroy(other.gameObject);
        }

        // If the other object has a tag PlayerParts then find and destroy the Player
        if (other.CompareTag("PlayerParts") || other.CompareTag("Player"))
        {
            AudioManager.instance.PlayDeathSound();
            // Game over
            // Load the main menu with a loss
            GameData.UpdateHighestRound(3);
            GameData.LoadingStatus = GameLoadingStatus.Lost;
            GameData.SetStatusMessage();
            GameData.SaveData();
            // Load the intro scene
            SceneManager.LoadScene(0);
        }

    }
}
