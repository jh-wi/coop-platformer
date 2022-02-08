using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyBirdMovement : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    public float checkRadius;
    private Rigidbody2D rb;
    private bool facingRight = true;
    private float moveDirection;
    private bool isJumping = false;
    public Transform ceilingCheck;
    public Transform groundCheck;
    public LayerMask groundObjects;
    private bool isGrounded;

    //Awake is called after all objects are initialized. Called in a random order
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>(); //Will look for a component on this Game Object (what the scrip is attached to) of type Rigidbody2D
    }

    // Update is called once per frame
    void Update()
    {
        //Get Inputs
        moveDirection = Input.GetAxis("Horizontal"); //Scale of -1 -> 1.
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            isJumping = true;
        }

        //Animate
        if(moveDirection > 0 && !facingRight) {
            FlipCharacter();
        }
        else if (moveDirection < 0 && facingRight) {
            FlipCharacter();
        }

                //Move
        rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);
        if(isJumping) {
            rb.AddForce(new Vector2(0f, jumpForce));
        }
        isJumping = false;
    }

    //Better for handing Physics
    private void FixedUpdate()
    {
        //Check if grounded
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundObjects);
        //Move
        rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);
        if(isJumping) {
            rb.AddForce(new Vector2(0f, jumpForce));
        }
        isJumping = false;
    }

    private void FlipCharacter()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}
