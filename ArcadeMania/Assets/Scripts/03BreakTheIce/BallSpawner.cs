using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        // If number of balls is less than maxBalls and there is no ball in the scene
        if (currentBalls < maxBalls && GameObject.FindObjectOfType<BallController>() == null)
        {
            // Spawn a ball
            Instantiate(ballPrefab, new Vector2(playerTransform.position.x, ballHeight), Quaternion.identity);
            currentBalls++;
        }
    }

    private void OnBallDestroyed()
    {
        currentBalls--;
    }
}
