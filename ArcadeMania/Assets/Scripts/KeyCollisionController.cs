using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCollisionController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // If the other object has a tag Ball
        if (other.CompareTag("Ball"))
        {
            // TODO: Signal that this round is completed
        }

        // Destroy this key if it collides with anything
        Destroy(gameObject);
    }
}
