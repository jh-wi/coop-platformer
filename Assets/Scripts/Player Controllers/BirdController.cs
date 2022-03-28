using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : PlayerController {
	
	//[SerializeField] Sprite altSprite;

	Animator animator;
	Sprite ogSprite;
	
	protected override void Start() {
		base.Start();
		ogSprite = renderer.sprite;
		animator = GetComponent<Animator>();
		Debug.Log(animator);
	}
	
	protected override void PlayerMove() {
		
		if (canJump && Input.GetKey(Keybinds.birdJump)/* && Vector3.Dot(transform.up, Vector3.up) > 0.75*/) {
			//playerVelocity += Vector2.up * jumpForce;
			//transform.position += Vector3.up * 0.2f;
			rb.AddForce(Vector2.up * jumpForce);
			StartCoroutine(JumpCooldown());
		}
		
		rb.velocity = new Vector2(0, rb.velocity.y);
		if (Input.GetKey(Keybinds.birdRight)) {
			rb.velocity = new Vector2(rb.velocity.x + moveSpeed * Time.deltaTime, rb.velocity.y);
			animator.SetBool("isWalking", true);
		}
		else if (Input.GetKey(Keybinds.birdLeft)) {
			rb.velocity = new Vector2(rb.velocity.x - moveSpeed * Time.deltaTime, rb.velocity.y);
			animator.SetBool("isWalking", true);
		}
		else {
			animator.SetBool("isWalking", false);
		}

		
		
		//gravity
		gravityVelocity -= Vector2.up * gravity * Time.deltaTime;
		if (grounded) gravityVelocity = Vector2.zero;
	}
	
	IEnumerator JumpCooldown() {
		canJump = false;
		//renderer.sprite = altSprite;
		animator.SetBool("isFlying", true);
		yield return new WaitForSeconds(jumpCooldown / 2);
		renderer.sprite = ogSprite;
		yield return new WaitForSeconds(jumpCooldown / 2);
		canJump = true;
		animator.SetBool("isFlying", false);
		yield break;
	}
	
	/*void Update() {
		PlayerMove();
		//rb.velocity = playerVelocity + gravityVelocity;
		//rb.velocity = new Vector2(playerVelocity.x, rb.velocity.y);
		//rb.AddForce(Vector2.up * (playerVelocity.y + gravityVelocity.y));
		//rb.AddForce(playerVelocity + gravityVelocity, ForceMode2D.Impulse);
	}*/
	
}
