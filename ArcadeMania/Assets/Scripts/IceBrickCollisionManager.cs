using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBrickCollisionManager : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // If the other object has a tag Ball
        if (other.CompareTag("Ball"))
        {
            Debug.Log("Ball collided with IceBrick");
            // Destroy this IceBrick
            Destroy(gameObject);
        }

        // If the other object has a tag PlayerShield then destroy the PlayerShield
        if (other.CompareTag("PlayerShield"))
        {
            // Destroy the player
            Destroy(other.gameObject);
        }

        // If the other object has a tag PlayerParts then find and destroy the Player
        if (other.CompareTag("PlayerParts"))
        {
            // Destroy the player
            Destroy(GameObject.Find("Player"));
        }

    }
}
