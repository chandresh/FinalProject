using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KeyCollisionController : MonoBehaviour
{
    GameData gameData;
    void Start()
    {
        gameData = new GameData();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        // If the other object has a tag Player
        if (other.CompareTag("Player"))
        {
            // Save Game Data
            gameData.UpdateHighestRound(3);
            // Next scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        // Destroy this key if it collides with anything
        Destroy(gameObject);
    }
}
