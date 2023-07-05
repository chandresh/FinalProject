using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Destroying " + other.gameObject);
        // Destroy the other prefab instance
        Destroy(other.gameObject);
    }
}
