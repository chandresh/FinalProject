using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System;


public class HealthSystem : MonoBehaviour
{
    public event Action<string> OnDeath;
    public float health = 100;
    [SerializeField] Scrollbar healthScrollbar;
    [SerializeField]
    bool regenerateHealth = false;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] AudioSource deathSound;
    [SerializeField] float deathDelay = 1.0f;

    public void TakeDamage(int damage)
    {
        health -= damage;
        UpdateHealthUI();
        // DamagedAnimation();

        if (health <= 0)
        {
            Die();
        }

        StartCoroutine(FlashRed());
    }

    private void Update()
    {
        RegenerateHealth();

        if (transform.position.y < -15)
        {
            Die();
        }
    }

    void UpdateHealthUI()
    {
        if (healthScrollbar != null)
        {
            healthScrollbar.size = health / 100f;
        }
    }

    void DamagedAnimation()
    {
    }

    void Die()
    {
        if (deathSound)
        {
            StartCoroutine(DieWithSound());
        }
        else
        {
            OnDeath?.Invoke(gameObject.tag);
        }
    }

    IEnumerator DieWithSound()
    {
        deathSound.Play();
        yield return new WaitForSeconds(deathDelay);
        OnDeath?.Invoke(gameObject.tag);
    }

    IEnumerator FlashRed()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        spriteRenderer.color = Color.white;
    }

    void RegenerateHealth()
    {
        if (regenerateHealth)
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
        healthScrollbar.size = health / 100f;
    }
}
