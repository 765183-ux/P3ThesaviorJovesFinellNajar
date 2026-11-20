using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 7f;
    public float jumpForce = 12f;

    [Header("Ground Detection")]
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private float moveInput;
    private bool isGrounded;
    private Animator anim;
    private SpriteRenderer spriteRenderer;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Get left/right input (-1 for Left/A, 1 for Right/D)
        moveInput = Input.GetAxisRaw("Horizontal");

        // Check if the groundCheck circle overlaps with the Ground layer
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // Trigger jump when pressing Space (or default Jump button) while grounded
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
       
    }


    void FixedUpdate()
    {
        // Apply horizontal movement smoothly in FixedUpdate for consistent physics
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
    }
} 