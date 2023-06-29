using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Rigidbody of the player
    private Rigidbody2D playerRb;
    private BoxCollider2D playerBoxCollider;


    [SerializeField]
    float playerSpeed, playerJump;

    [SerializeField]
    private LayerMask groundLayer;

    private void Awake()
    {
        // Set the playerRb with the Rigidbody Component
        playerRb = GetComponent<Rigidbody2D>();
        playerBoxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        // Capture the player movement (1 or -1)
        float playerMovement = Input.GetAxis("Horizontal");
        FlipPlayer(playerMovement);
        MovePlayer(playerMovement);
        JumpPlayer();
    }

    private void JumpPlayer()
    {
        if (Input.GetAxis("Jump") > 0 && isPlayerGrounded())
        {
            playerRb.velocity = new Vector2(playerRb.velocity.x, playerJump);
        }
    }

    private void MovePlayer(float playerMovement)
    {
        // Set player velocity
        float playerVelocity = playerMovement * playerSpeed;
        playerRb.velocity = new Vector2(playerVelocity, playerRb.velocity.y);
    }

    private void FlipPlayer(float playerMovement)
    {
        // If Player is moving right
        if (playerMovement > 0.01f)
        {
            transform.localScale = Vector3.one;
        }

        // If Player is moving left
        if (playerMovement < -0.01f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
    private bool isPlayerGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(playerBoxCollider.bounds.center, playerBoxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }

    public bool canAttack()
    {
        return true;
    }
}
