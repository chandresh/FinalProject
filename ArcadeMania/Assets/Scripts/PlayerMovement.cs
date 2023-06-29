using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 10f;
    private Rigidbody2D rb;

    private GetInput getInput;

    private int enemyLayer;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        getInput = this.GetComponent<GetInput>();
        enemyLayer = LayerMask.NameToLayer("Enemy");
    }

    // Physics code goes in FixedUpdate
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(getInput.directionX * speed, 0);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == enemyLayer)
        {
            // speed = 0;
            // rb.position = new Vector2(rb.position.x, -4f);
        }
    }
}
