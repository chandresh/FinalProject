using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KalisuraMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;
    [SerializeField] float lerpSpeed = 1f;
    [SerializeField] float lerpDistance = 2.5f;
    GameObject player;

    const float RUN_DISTANCE = 10.0f;
    const float ATTACK_DISTANCE = 5.0f;


    Animator myAnimator;

    Rigidbody2D myRigidbody;
    Camera mainCamera;

    Vector3 startPos;
    Vector3 endPos;
    float lerpTime;
    Rigidbody2D playerRigidbody;

    bool playerIsMoving = false;
    public float health = 100.0f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerRigidbody = player.GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
        mainCamera = Camera.main;

        startPos = transform.position;
        endPos = new Vector3(transform.position.x, transform.position.y + lerpDistance, transform.position.z);
        lerpTime = 0;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        DamagedAnimation();

        if (health <= 0)
        {
            // Add code to handle enemy death, like playing an animation
            Destroy(gameObject);
        }
    }

    // Set all animations to false
    void ResetAnimations()
    {
        myAnimator.SetBool("isWalking", false);
        myAnimator.SetBool("isRunning", false);
        myAnimator.SetBool("isAttacking", false);
        myAnimator.SetBool("isDamaged", false);
        myAnimator.SetBool("isCrouching", false);
    }

    void IdleAnimation()
    {
        ResetAnimations();
    }

    void WalkAnimation()
    {
        MoveTowardPlayer();
        UpAndDownLerp();
        ResetAnimations();
        myAnimator.SetBool("isWalking", true);
    }

    void RunAnimation()
    {
        MoveTowardPlayer();
        UpAndDownLerp();
        ResetAnimations();
        myAnimator.SetBool("isRunning", true);
    }

    void AttackAnimation()
    {
        ResetAnimations();
        myAnimator.SetBool("isAttacking", true);
    }

    void CrouchAnimation()
    {
        ResetAnimations();
        myAnimator.SetBool("isCrouching", true);
    }

    void DamagedAnimation()
    {
        ResetAnimations();
        myAnimator.SetBool("isDamaged", true);
    }

    bool isPlayerMoving()
    {
        return playerRigidbody.velocity != Vector2.zero;
    }

    void Update()
    {

        float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);

        Debug.Log("Distance to player: " + distanceToPlayer);

        if (isPlayerMoving())
        {
            Debug.Log("Player is moving");
            playerIsMoving = true;
        }

        if (playerIsMoving && distanceToPlayer > RUN_DISTANCE)
        {
            WalkAnimation();
        }
        else if (playerIsMoving && distanceToPlayer <= ATTACK_DISTANCE)
        {
            AttackAnimation();
        }
        else if (playerIsMoving && distanceToPlayer <= RUN_DISTANCE)
        {
            RunAnimation();
        }

        // Kalisura heals automatically as time goes on
        RegenerateHealth();
    }

    void RegenerateHealth()
    {
        if (health < 100)
        {
            health += 2 * Time.deltaTime;
        }

        if (health > 100)
        {
            health = 100;
        }
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

    void UpAndDownLerp()
    {
        lerpTime += Time.deltaTime * lerpSpeed;
        float newY = Mathf.Lerp(startPos.y, endPos.y, Mathf.PingPong(lerpTime, 1));

        // Update only the y component of the position
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
