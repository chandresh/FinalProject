using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KeyCollisionController : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        // If the other object has a tag Player
        if (other.CompareTag("Player"))
        {
            // Save Game Data
            GameData.UpdateHighestRound(3);
            // Load the intro scene
            SceneManager.LoadScene(0);
        }

        // Destroy this key if it collides with anything
        Destroy(gameObject);
    }
}
