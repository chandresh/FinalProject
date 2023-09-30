using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallSpawner : MonoBehaviour
{

    public GameObject ballPrefab;
    public Transform playerTransform;
    public int maxBalls = 3;

    public float ballHeight = 4.0f;
    public int currentBalls = 0;

    // Update is called once per frame
    void Update()
    {
        GameObject[] allBalls = GameObject.FindGameObjectsWithTag("Ball");

        // If number of balls is less than maxBalls and there is no ball in the scene
        if (currentBalls < maxBalls && allBalls.Length == 0)
        {
            // Spawn a ball
            Instantiate(ballPrefab, new Vector2(playerTransform.position.x, ballHeight), Quaternion.identity);
            currentBalls++;
        }
        // If 3 balls are already used then the round is lost
        if (currentBalls == 3 && allBalls.Length == 0)
        {
            // Load the main menu with a loss
            GameData.UpdateHighestRound(3);
            GameData.LoadingStatus = GameLoadingStatus.Lost;
            GameData.SetStatusMessage();
            GameData.SaveData();
            // Load the intro scene
            SceneManager.LoadScene(0);
        }
    }

    private void OnBallDestroyed()
    {
        currentBalls--;
    }
}
