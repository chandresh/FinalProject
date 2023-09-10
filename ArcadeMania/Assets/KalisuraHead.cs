using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KalisuraHead : MonoBehaviour
{

    [SerializeField] HealthSystem kalisuraHealthSystem;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("KalisuraHead OnTriggerEnter2D " + other.tag);

        if (other.tag == "Bullet")
        {
            kalisuraHealthSystem.TakeDamage(10);
        }
    }
}
