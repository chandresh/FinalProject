using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Rigidbody of the player
    private Rigidbody2D playerRb;

    [SerializeField]
    float playerSpeed = 10;

    private void Awake()
    {
        // Set the playerRb with the Rigidbody Component
        playerRb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Capture the player movement (1 or -1)
        float playerMovement = Input.GetAxis("Horizontal");

        // Set player velocity
        float playerVelocity = playerMovement * playerSpeed;
        playerRb.velocity = new Vector2(playerVelocity, 0);
    }

}
