using System.Collections;
using UnityEngine;

public class SnailCollision : MonoBehaviour
{
    Animator snailAnimator;
    [SerializeField] int lives = 2;
    SpriteRenderer spriteRenderer;

    bool isInShell = false;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        snailAnimator = GetComponent<Animator>();
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
        Debug.Log("SnailCollision OnTriggerEnter2D " + other.gameObject.tag);

        // if bullet hits snail and snail is not in shell
        if (other.gameObject.tag == "Bullet" && !isInShell)
        {
            isInShell = true;
            lives--;
            snailAnimator.SetBool("IsShell", true);
            StartCoroutine(FlashRed());
            StartCoroutine(ShellTime());
            if (lives <= 0)
            {
                Destroy(gameObject);
            }
        }

        if (isInShell)
        {
            StartCoroutine(FlashGreen());
        }
    }

    IEnumerator FlashRed()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        spriteRenderer.color = Color.white;
    }

    IEnumerator FlashGreen()
    {
        spriteRenderer.color = Color.green;
        yield return new WaitForSeconds(0.2f);
        spriteRenderer.color = Color.white;
    }

    IEnumerator ShellTime()
    {
        yield return new WaitForSeconds(3);  // stay in shell form for 3 seconds
        snailAnimator.SetBool("IsShell", false); // Turn off shell animation
        isInShell = false; // Allow it to be hit again
    }
}
