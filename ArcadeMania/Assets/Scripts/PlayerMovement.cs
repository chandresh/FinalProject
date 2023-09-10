using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public class PlayerMovement : MonoBehaviour
{

    [SerializeField] float speed = 10f;
    [SerializeField] bool canJump = false;
    [SerializeField] float jumpForce = 10f;

    [SerializeField] GameObject bullet;
    [SerializeField] Transform gun;

    bool isJumping = false;
    Vector2 moveInput;
    public float directionX, directionY;

    private Rigidbody2D rb;

    public int healthRegenerationRate = 0;

    private int enemyLayer, groundLayer;

    private BoxCollider2D playerCollider;

    // Subscribe to events
    private void OnEnable()
    {
        // Subscribe to the OnDeath event
        GetComponent<HealthSystem>().OnDeath += OnDeath;
    }

    // Unsubscribe from events
    private void OnDisable()
    {
        GetComponent<HealthSystem>().OnDeath -= OnDeath;
    }

    void OnDeath(string tag)
    {
        if (tag == "Player" || tag == "PlayerParts")
        {
            // Save Game Data
            GameData.UpdateHighestRound(4);
            GameData.LoadingStatus = GameLoadingStatus.Lost;
            GameData.SetStatusMessage();
            GameData.SaveData();
            // Load the intro scene
            SceneManager.LoadScene(0);

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // check if the rigidbody2D component is attached to the player
        rb = GetComponent<Rigidbody2D>();
        if (!rb)
        {
            // Get it from a child object
            rb = GetComponentInChildren<Rigidbody2D>();
        }

        playerCollider = GetComponent<BoxCollider2D>();

        if (!playerCollider)
        {
            Debug.Log("playerCollider is null");
            playerCollider = GetComponentInChildren<BoxCollider2D>();
        }

        enemyLayer = LayerMask.NameToLayer("Enemy");
        groundLayer = LayerMask.NameToLayer("Ground");
        Debug.Log("groundLayer: " + groundLayer);
    }

    // Physics code goes in FixedUpdate
    private void FixedUpdate()
    {
        MovePlayer();
        JumpPlayer();
        SetPlayerDirection();
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
        directionX = moveInput.x;
        directionY = moveInput.y;
    }

    void OnJump(InputValue jump)
    {
        if (canJump && jump.isPressed)
        {
            isJumping = true;
        }
    }

    void OnFire(InputValue value)
    {
        Instantiate(bullet, gun.position, transform.rotation);
    }

    void JumpPlayer()
    {
        // Debug.Log("playerCollider.IsTouchingLayers(groundLayer): " + playerCollider.IsTouchingLayers(groundLayer));

        if (!playerCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            return;
        }

        if (canJump && isJumping)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isJumping = false;
        }
    }

    private void MovePlayer()
    {
        // Y is zero as we don't have jump functionality for player in this stage
        rb.velocity = new Vector2(directionX * speed, rb.velocity.y);
        // Y speed would be based on gravity and jump
        rb.velocity = new Vector2(directionX * speed, rb.velocity.y);
    }




    private void SetPlayerDirection()
    {
        if (directionX > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (directionX < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}
