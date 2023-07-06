using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{

    private Rigidbody2D ballRb;
    [SerializeField] private float ballSpeed = 500f;
    [SerializeField] private float playerShieldHeight = 2.0f;


    private void Awake()
    {
        ballRb = this.GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        Invoke("SetBallRandomDirection", 1f);
    }

    private void Update()
    {

        // If the ball is below 2.23 on the y axis then increase gravity to 1
        if (transform.localPosition.y < playerShieldHeight)
        {
            // Debug.Log("Gravity increased");
            // ballRb.gravityScale = 1f;
        }
    }


    private void SetBallRandomDirection()
    {
        // Add a force to the ball down and to the left or right
        Vector2 force = new Vector2();
        force.x = Random.Range(-1f, 1f);
        force.y = -1f;

        // Add the force to the ball
        ballRb.AddForce(force.normalized * ballSpeed);
    }

}
