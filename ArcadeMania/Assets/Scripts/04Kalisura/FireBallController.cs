using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallController : MonoBehaviour
{
    Rigidbody2D rb;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        // rb.velocity = new Vector2(-50f, 0);
    }

    private void Update() {
        Destroy(gameObject, 4f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            AudioManager.instance.PlayBulletHitSound();
            other.gameObject.GetComponent<HealthSystem>().TakeDamage(10);
        }
    }

}