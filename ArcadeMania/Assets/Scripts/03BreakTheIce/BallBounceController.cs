using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBounceController : MonoBehaviour
{

    [SerializeField] float maxBounceAngle = 75f;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            Vector3 playerPosition = transform.position;

            // Position where the ball hit the player
            Vector2 contact = other.GetContact(0).point;

            // Difference between the player position and the contact position
            float difference = playerPosition.x - contact.x;

            // Half of the width of the player
            float width = other.otherCollider.bounds.size.x / 2;

            // Percentage of the difference
            float percentage = difference / width;

            // current angle of the ball
            float currentAngle = Vector2.SignedAngle(Vector2.up, other.rigidbody.velocity);
            float bounceAngle = (difference / width) * this.maxBounceAngle;

            // New angle, direction and velocity
            float newAngle = Mathf.Clamp(currentAngle + bounceAngle, -this.maxBounceAngle, this.maxBounceAngle);
            Quaternion rotation = Quaternion.AngleAxis(newAngle, Vector3.forward);
            other.rigidbody.velocity = rotation * Vector2.up * other.rigidbody.velocity.magnitude;
        }
    }
}
