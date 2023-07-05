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
            // Destroy(other.gameObject);
            // where did the ball hit the player
            // get the contact point

            Vector3 playerPosition = transform.position;

            // Position where the ball hit the player
            Vector2 contact = other.GetContact(0).point;

            // Calculate the difference between the player position and the contact position
            float difference = playerPosition.x - contact.x;

            // Half of the width of the player
            float width = other.otherCollider.bounds.size.x / 2;

            // Calculate the percentage of the difference
            float percentage = difference / width;

            // current angle of the ball
            float currentAngle = Vector2.SignedAngle(Vector2.up, other.rigidbody.velocity);
            float bounceAngle = (difference / width) * this.maxBounceAngle;

            // Calculate the new angle
            float newAngle = Mathf.Clamp(currentAngle + bounceAngle, -this.maxBounceAngle, this.maxBounceAngle);

            // Calculate the new direction
            Quaternion rotation = Quaternion.AngleAxis(newAngle, Vector3.forward);

            // Set the new velocity
            other.rigidbody.velocity = rotation * Vector2.up * other.rigidbody.velocity.magnitude;

        }
    }
}
