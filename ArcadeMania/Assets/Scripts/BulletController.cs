using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] float bulletSpeed = 20f;
    Rigidbody2D bulletRB;
    PlayerMovement playerMovement;
    float speedInXDirection;
    void Start()
    {
        bulletRB = GetComponent<Rigidbody2D>();
        playerMovement = FindObjectOfType<PlayerMovement>();
        speedInXDirection = playerMovement.transform.localScale.x * bulletSpeed;
    }
    void Update()
    {
        bulletRB.velocity = new Vector2(speedInXDirection, 0f);

        // Destroy the bullet after 2 seconds
        Destroy(gameObject, 2f);
    }
    void OnTriggerEnter2D(Collider2D other)
    {


        if (other.tag == "Enemy")
        {
            Destroy(other.gameObject);
        }


        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(gameObject);
    }
}
