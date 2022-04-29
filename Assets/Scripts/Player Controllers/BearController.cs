using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearController : PlayerController {
	
	int lastDir = 0;
	
	Animator animator;
	SpriteRenderer rend;
	float jumpMultiplyer = 1;
	
	protected override void Start() {
		base.Start();
		animator = GetComponent<Animator>();
		rend = GetComponent<SpriteRenderer>();
		
	}
	
	protected override void PlayerMove() {
		
		//print(grounded);
		
		if (canJump && grounded) {
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
		
		
		if (Input.GetKeyDown(Keybinds.bearJump) && grounded/* && Vector3.Dot(transform.up, Vector3.up) > 0.75*/) {
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
		if (rb.velocity.x < 0) rend.flipX = true;
	}
	
	IEnumerator JumpCooldown() {
		canJump = false;
		yield return new WaitForSeconds(jumpCooldown);
		canJump = true;
		yield break;
	}

	public void OnGetGlasses() {
		Debug.Log("Got the glasses");
		jumpMultiplyer *= 2;
	}
	
}
