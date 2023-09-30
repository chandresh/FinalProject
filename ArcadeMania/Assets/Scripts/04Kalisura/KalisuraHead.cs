using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KalisuraHead : MonoBehaviour
{

    [SerializeField] HealthSystem kalisuraHealthSystem;
    KalisuraMovement kalisuraMovement;

    private void Awake() {
        // Find the KalisuraMovement script in the parent object
        kalisuraMovement = GetComponentInParent<KalisuraMovement>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Bullet")
        {
            kalisuraHealthSystem.TakeDamage(10);
            kalisuraMovement.playerIsMoving = true;
        }
    }
}
