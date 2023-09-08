using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;
    [SerializeField] float lerpSpeed = 1f;
    [SerializeField] float lerpDistance = 2.5f;
    [SerializeField] GameObject player;
    Rigidbody2D myRigidbody;
    Camera mainCamera;

    Vector3 startPos;
    Vector3 endPos;
    float lerpTime;


    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        mainCamera = Camera.main;


        startPos = transform.position;
        endPos = new Vector3(transform.position.x, transform.position.y + lerpDistance, transform.position.z);
        lerpTime = 0;


    }

    void MoveTowardPlayer()
    {
        Vector2 direction = (player.transform.position - transform.position).normalized;
        Vector2 velocity = new Vector2(direction.x * moveSpeed, 0); // Set y-velocity to 0

        // Check if enemy and player are on the same screen
        Vector3 screenPosEnemy = mainCamera.WorldToViewportPoint(transform.position);
        Vector3 screenPosPlayer = mainCamera.WorldToViewportPoint(player.transform.position);

        if (screenPosEnemy.x >= 0 && screenPosEnemy.x <= 1 &&
            screenPosEnemy.y >= 0 && screenPosEnemy.y <= 1 &&
            screenPosPlayer.x >= 0 && screenPosPlayer.x <= 1 &&
            screenPosPlayer.y >= 0 && screenPosPlayer.y <= 1)
        {
            // If both are on the screen, move the enemy towards the player
            myRigidbody.velocity = velocity;
        }
        else
        {
            // If not, stop the enemy
            myRigidbody.velocity = Vector2.zero;
        }

        // Flip the enemy sprite if moving right
        if (direction.x > 0)
        {
            transform.localScale = new Vector2(-1f, 1f);
        }
        else
        {
            transform.localScale = new Vector2(1f, 1f);
        }

    }




    void Update()
    {
        MoveTowardPlayer();


    }


}
