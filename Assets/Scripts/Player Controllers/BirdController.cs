// using System.Runtime.Intrinsics;
// using System.Numerics;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : PlayerController {
    
    public float HSpeed = 10f;
    private float curr_speed = 10f;
	private bool facingRight = false;
    private bool leftCurrent = true;

    //Used for flipping Character Direction
	public static Vector3 theScale;

	bool left;
	bool right;
	bool up;
	

	private Animator anim;

	void Awake (){
		anim = GetComponent<Animator> ();
        // GetComponent<Rigidbody2D>().velocity = new Vector2(curr_speed, GetComponent<Rigidbody2D>().velocity.y); 
	}

    /*void start(){
        GetComponent<Rigidbody2D>().velocity = new Vector2(curr_speed, GetComponent<Rigidbody2D>().velocity.y); 
    }*/

	void FixedUpdate (){
		
		//print($"up: {up}, canJump: {canJump}");
		
		//grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
		anim.SetBool ("isGrounded", grounded);
        anim.SetBool("isHopping", false);
        anim.SetBool("isFlying", false);
		anim.SetBool("gliding", false);

        // UnityEngine.Debug.Log("grounded: ");
        // UnityEngine.Debug.Log(grounded);
        
		if (up && canJump) {
			anim.SetBool("isFlying", true);
            //GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpForce);
			//rb.AddForce(Vector2.up * jumpForce);
			rb.velocity = new Vector2(rb.velocity.x, jumpForce);
			StartCoroutine(JumpCooldown());
        } else if (!up) {
			anim.SetBool("gliding", true);
		}
		//else if ((grounded) && Input.GetKey(down)){
        //     // anim.SetBool("ground", false);
        //     grounded = false;
        //     GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.y, landForce);
        // }

        rb.velocity = new Vector2(0, rb.velocity.y);
        if (left){
            leftCurrent = true;
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
			//if (grounded) {
       			anim.SetBool("isHopping", true);
			//}
        } else if (right){
            leftCurrent = false;
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
			//if (grounded) {
       			anim.SetBool("isHopping", true);
			//}
        }
		
        //Flipping direction character is facing based on players Input
        if (!leftCurrent && facingRight)
            Flip();
        else if (leftCurrent && !facingRight)
            Flip();

         
	}

	protected override void PlayerMove() {
		left = Input.GetKey(Keybinds.birdLeft);
		right = Input.GetKey(Keybinds.birdRight);
		up = Input.GetKey(Keybinds.birdJump);
    }
	
    ////Flipping direction of character
    void Flip(){
		facingRight = !facingRight;
		theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

}
