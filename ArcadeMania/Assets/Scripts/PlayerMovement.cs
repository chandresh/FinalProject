using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] float speed = 10f;
    [SerializeField] bool canJump = false;
    [SerializeField] float jumpForce = 10f;

    private Rigidbody2D rb;

    private GetInput getInput;

    private int enemyLayer;

    // Start is called before the first frame update
    void Start()
    {
        // check if the rigidbody2D component is attached to the player
        rb = this.GetComponent<Rigidbody2D>();
        if (!rb)
        {
            // Get it from a child object
            rb = this.GetComponentInChildren<Rigidbody2D>();
        }
        getInput = this.GetComponent<GetInput>();
        enemyLayer = LayerMask.NameToLayer("Enemy");
    }

    // Physics code goes in FixedUpdate
    private void FixedUpdate()
    {
        MovePlayer();
        JumpPlayer();
        SetPlayerDirection();
    }

    void JumpPlayer()
    {

        if (canJump && getInput.isJumping)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    private void MovePlayer()
    {
        // Y is zero as we don't have jump functionality for player in this stage
        rb.velocity = new Vector2(getInput.directionX * speed, rb.velocity.y);
        // Y speed would be based on gravity and jump
        rb.velocity = new Vector2(getInput.directionX * speed, rb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == enemyLayer)
        {
            // speed = 0;
            // rb.position = new Vector2(rb.position.x, -4f);
        }
    }

    private void SetPlayerDirection()
    {
        if (getInput.directionX > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (getInput.directionX < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}
