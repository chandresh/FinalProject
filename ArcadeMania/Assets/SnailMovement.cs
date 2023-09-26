using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnailMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;
    Animator snailAnimator;
    [SerializeField] int lives = 2;

    int initialLives;
    float transparency;
    SpriteRenderer spriteRenderer;

    bool isInShell = false;
    GameObject player;

    Rigidbody2D snailRigidbody;
    Camera mainCamera;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        snailAnimator = GetComponent<Animator>();
        initialLives = lives;
    }
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        snailRigidbody = GetComponent<Rigidbody2D>();
        mainCamera = Camera.main;
    }

    void Update()
    {
        MoveTowardPlayer();
    }

    void MoveTowardPlayer()
    {
        if (isInShell)
        {
            return;
        }

        Vector2 direction = (player.transform.position - transform.position).normalized;
        Vector2 velocity = new Vector2(direction.x * moveSpeed, snailRigidbody.velocity.y);

        // Check if enemy and player are on the same screen
        Vector3 screenPosEnemy = mainCamera.WorldToViewportPoint(transform.position);
        Vector3 screenPosPlayer = mainCamera.WorldToViewportPoint(player.transform.position);

        if (screenPosEnemy.x >= 0 && screenPosEnemy.x <= 1 &&
            screenPosEnemy.y >= 0 && screenPosEnemy.y <= 1 &&
            screenPosPlayer.x >= 0 && screenPosPlayer.x <= 1 &&
            screenPosPlayer.y >= 0 && screenPosPlayer.y <= 1)
        {
            // If both are on the screen, move the enemy towards the player
            snailRigidbody.velocity = velocity;
        }
        else
        {
            // If not, stop the enemy
            snailRigidbody.velocity = new Vector2(0, snailRigidbody.velocity.y);
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

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "PlayerParts")
        {
            HealthSystem healthSystem = other.gameObject.GetComponent<HealthSystem>();
            if (healthSystem == null)
            {
                healthSystem = other.gameObject.GetComponentInParent<HealthSystem>();
            }

            if (healthSystem != null)
            {
                healthSystem.TakeDamage(20);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isInShell)
        {
            StartCoroutine(FlashGreen());
            return;
        }

        // if bullet hits snail and snail is not in shell
        if (other.gameObject.tag == "Bullet" && !isInShell)
        {
            isInShell = true;
            lives--;

            // Update the transparency based on lives
            transparency = (float)lives / initialLives;
            spriteRenderer.color = new Color(1f, 1f, 1f, transparency);

            snailAnimator.SetBool("IsShell", true);
            StartCoroutine(FlashRed());
            StartCoroutine(ShellTime());
            if (lives <= 0)
            {
                Destroy(gameObject);
            }
        }

    }

    IEnumerator FlashRed()
    {
        spriteRenderer.color = new Color(1f, 0f, 0f, transparency);
        yield return new WaitForSeconds(0.5f);
        spriteRenderer.color = new Color(1f, 1f, 1f, transparency);
    }

    IEnumerator FlashGreen()
    {
        spriteRenderer.color = new Color(0f, 1f, 0f, transparency);
        yield return new WaitForSeconds(0.2f);
        spriteRenderer.color = new Color(1f, 1f, 1f, transparency);
    }

    IEnumerator ShellTime()
    {
        yield return new WaitForSeconds(3);
        snailAnimator.SetBool("IsShell", false);
        isInShell = false;
    }

}
