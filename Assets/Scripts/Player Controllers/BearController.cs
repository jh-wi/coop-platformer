using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearController : PlayerController {
	
	int lastDir = 0;
	
	Animator animator;
	float jumpMultiplyer = 1;
	private bool facingRight = false;
    private bool leftCurrent = true;
	public static Vector3 theScale;
	
	
	bool glasses;
	
	bool left;
	bool right;
	bool up;
	
	protected override void Start() {
		base.Start();
		animator = GetComponent<Animator>();
	}
	
	protected override void PlayerMove() {
		left = Input.GetKey(Keybinds.bearLeft);
		right = Input.GetKey(Keybinds.bearRight);
		up = Input.GetKey(Keybinds.bearJump);
    }
	
	void FixedUpdate() {
		
		//print(grounded);
		if (!glasses) {
			return;
		}
		
		if (up && canJump && grounded) {
            //GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpForce);
			//rb.AddForce(Vector2.up * jumpForce);
			rb.velocity = new Vector2(rb.velocity.x, jumpForce);
			StartCoroutine(JumpCooldown());
        }
		
		rb.velocity = new Vector2(0, rb.velocity.y);
        if (left){
            leftCurrent = true;
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
        } else if (right){
            leftCurrent = false;
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        }
		
		if (!leftCurrent && facingRight)
            Flip();
        else if (leftCurrent && !facingRight)
            Flip();
		
		
		
		/*if (canJump && grounded) {
			rb.velocity = new Vector2(0, rb.velocity.y);
		}
		if (Input.GetKey(Keybinds.bearRight) && grounded) {
			rb.velocity = new Vector2(moveSpeed * Time.deltaTime, rb.velocity.y);
			lastDir = 1;
		}
		if (Input.GetKey(Keybinds.bearLeft) && grounded) {
			rb.velocity = new Vector2(-moveSpeed * Time.deltaTime, rb.velocity.y);
			lastDir = -1;
		}
		
		
		if (Input.GetKeyDown(Keybinds.bearJump) && grounded) {
			//playerVelocity += Vector2.up * jumpForce;
			//transform.position += Vector3.up * 0.2f;
			//rb.AddForce(new Vector2(Mathf.Sign(rb.velocity.x) * jumpForce * 2, jumpForce));
			rb.velocity = new Vector2(lastDir * jumpForce * jumpMultiplyer, jumpForce * jumpMultiplyer);
			StartCoroutine(JumpCooldown());
		}
		
		
		//gravity
		gravityVelocity -= Vector2.up * gravity * Time.deltaTime;
		if (grounded) gravityVelocity = Vector2.zero;
		if (rb.velocity == Vector2.zero || !grounded) {
			animator.SetBool("walking", false);
		} else {
			animator.SetBool("walking", true);
		}
		if (rb.velocity.x > 0) rend.flipX = false;
		if (rb.velocity.x < 0) rend.flipX = true;*/
	}
	
	

	public void OnGetGlasses() {
		Debug.Log("Got the glasses");
		glasses = true;
		jumpMultiplyer *= 2;
		animator.SetBool("wearingGlasses", true);
	}
	
	void Flip(){
		facingRight = !facingRight;
		theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
	
}
