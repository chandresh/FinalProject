using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseHealth : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
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
                healthSystem.Heal(40);
            }
            Destroy(this.gameObject);
        }

    }
}
