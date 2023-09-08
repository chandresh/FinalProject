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
            // Next scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        // Destroy this key if it collides with anything
        Destroy(gameObject);
    }
}
