using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KeyCollisionController : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {


        //If the ball hits the key
        if (other.CompareTag("Ball"))
        {

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
