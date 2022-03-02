using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrandpaMovement : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    public float checkRadius;
    
    float dashDirection;
    bool isDashinig;
    public float dashForce;
    public float dashTimer;
    float currentDashTimer;
    //public ParticleSystem particles;

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
        moveDirection = Input.GetAxis("Horizontal2"); //Scale of -1 -> 1.
        if(Input.GetButtonDown("Jump2") && isGrounded)
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

        //Dash
        if(isJumping && !isDashinig){
            isDashinig = true;
            currentDashTimer = dashTimer;
            rb.velocity = Vector2.zero;
            dashDirection = (int)moveDirection;
            //particles.Play();
        }

        if(isDashinig){
            rb.velocity = new Vector2(moveDirection * dashForce, rb.velocity.y);
            //rb.velocity = transform.right * dashDirection * dashForce* 10000;
            currentDashTimer -= Time.deltaTime;

            if(currentDashTimer <= 0){
                isDashinig = false;
            }
        }
    }

    //Better for handing Physics, called before each internal physics update (about 50x per sec)
    private void FixedUpdate()
    {
        //Check if grounded
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundObjects);
        print("isGround is " + isGrounded);
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
