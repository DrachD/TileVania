using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool drawDebugRaycasts = true; // Should the envinronment checks be vesualized
    
    public bool isOnGround;
    public bool isJumping;
    public bool doubleJump;
    public bool doubleJumpPressed;
    bool isHeadBlocked;

    [Header("Environmant Check Properties")]
    public float groundDistance = .4f; // The reach distance for wall grabs
    public float footOffset = .4f;

    [SerializeField] float moveSpeed;
    [SerializeField] float jumpVelocity;

    [HideInInspector] public float horizontal;
    [HideInInspector] public bool jumpPressed;
    [HideInInspector] public bool crouchPressed;

    public LayerMask groundLayer;   // Layer of the ground

    [SerializeField] GameObject playerPrefab;
    Rigidbody2D rb2D;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = playerPrefab.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
    }

    private void FixedUpdate()
    {
        // Check the environment to determine status
        PhysicsCheck();

        GroundMovement();
        MidAirMovement();
    }

    void ProcessInputs()
    {
        horizontal = Input.GetAxis("Horizontal");
        jumpPressed = Input.GetButton("Jump");
        //doubleJumpPressed = Input.GetButtonDown("Jump");
    }

    void GroundMovement()
    {
        if (isOnGround)
        {
            doubleJump = false;

            rb2D.velocity = new Vector2(horizontal * moveSpeed, rb2D.velocity.y);

            if (jumpPressed)
            {
                rb2D.velocity += new Vector2(0, jumpVelocity);
            }
        }
    }

    void MidAirMovement()
    {
        if (!isOnGround)
        {
            rb2D.velocity = new Vector2(horizontal * moveSpeed, rb2D.velocity.y);
            
            if (!doubleJump)
            {
                if (Input.GetButtonDown("Jump"))
                {
                    rb2D.velocity += new Vector2(0, jumpVelocity);
                    doubleJump = true;
                }
            }
        }
    }

    void PhysicsCheck()
    {
        isOnGround = false;
        isJumping = true;
        isHeadBlocked = false;

        RaycastHit2D leftCheck = Raycast(new Vector2(-footOffset, 0f), Vector2.down, groundDistance);
        RaycastHit2D rightCheck = Raycast(new Vector2(footOffset, 0f), Vector2.down, groundDistance);

        if (leftCheck || rightCheck)
        {
            isOnGround = true;
            isJumping = false;
        }
    }

    RaycastHit2D Raycast(Vector2 offset, Vector2 rayDirection, float length)
    {
        // Call the overloaded Raycast() method using the ground layermask and return
        // the result
        return Raycast(offset, rayDirection, length, groundLayer);
    }

    RaycastHit2D Raycast(Vector2 offset, Vector2 rayDirection, float length, LayerMask mask)
    {
        // Record the player`s position
        Vector2 pos = transform.position;

        // Send out the desired raycast and record the result
        RaycastHit2D hit = Physics2D.Raycast(pos + offset, rayDirection, length, mask);

        // If we want to show debug raycasts in the scene...
        if (drawDebugRaycasts)
        {
            // ...determine the color based on if the raycast hit...
            Color color = hit ? Color.red : Color.green;
            // ...and draw the ray in the scene view
            Debug.DrawRay(pos + offset, rayDirection * length, color);
        }

        // Return the results of the raycast
        return hit;
    }
}