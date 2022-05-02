using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerController : MonoBehaviour {
	
	protected Vector2 playerVelocity;
	protected Vector2 gravityVelocity;
	protected bool grounded;
	[SerializeField] protected float moveSpeed;
	[SerializeField] protected float jumpForce;
	[SerializeField] protected float jumpCooldown;
	protected bool canJump = true;
	[SerializeField] protected float gravity;
	protected Rigidbody2D rb;
	protected SpriteRenderer rend;
	
	protected int triggerObjects = 0;
	
	void OnTriggerEnter2D() {
		triggerObjects++;
	}
	
	void OnTriggerExit2D() {
		triggerObjects--;
	}
	
	
	protected virtual void Start() {
		rb = GetComponent<Rigidbody2D>();
		rend = GetComponent<SpriteRenderer>();
	}
	
	protected abstract void PlayerMove();
	
	void Update() {
		grounded = triggerObjects > 0;
		PlayerMove();
		//rb.velocity = playerVelocity + gravityVelocity;
		//rb.velocity = new Vector2(playerVelocity.x, rb.velocity.y);
		//rb.AddForce(Vector2.up * (playerVelocity.y + gravityVelocity.y));
		//rb.AddForce(playerVelocity + gravityVelocity, ForceMode2D.Impulse);
	}
	
	protected IEnumerator JumpCooldown() {
		canJump = false;
		yield return new WaitForSeconds(jumpCooldown);
		canJump = true;
		yield break;
	}
	
}
