using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour {
	
	Vector2 playerVelocity;
	Vector2 gravityVelocity;
	[SerializeField] float maxYvel;
	bool grounded;
	[SerializeField] float moveSpeed;
	[SerializeField] float jumpForce;
	[SerializeField] float jumpCooldown;
	bool canJump = true;
	[SerializeField] float gravity;
	Rigidbody2D rb;
	SpriteRenderer renderer;
	
	
	[SerializeField] Sprite altSprite;
	Sprite ogSprite;
	
	int triggerObjects = 0;
	
	void OnTriggerEnter() {
		triggerObjects++;
	}
	
	void OnTriggerExit() {
		triggerObjects--;
	}
	
	
	void Start() {
		rb = GetComponent<Rigidbody2D>();
		renderer = GetComponent<SpriteRenderer>();
		ogSprite = renderer.sprite;
	}
	
	void PlayerMove() {
		grounded = triggerObjects > 0;
		
		
		if (canJump && Input.GetKey(Keybinds.birdJump)) {
			//playerVelocity += Vector2.up * jumpForce;
			//transform.position += Vector3.up * 0.2f;
			rb.AddForce(Vector2.up * jumpForce);
			StartCoroutine(JumpCooldown());
		}
		
		
		//gravity
		gravityVelocity -= Vector2.up * gravity * Time.deltaTime;
		if (grounded) gravityVelocity = Vector2.zero;
	}
	
	IEnumerator JumpCooldown() {
		canJump = false;
		renderer.sprite = altSprite;
		yield return new WaitForSeconds(jumpCooldown / 2);
		renderer.sprite = ogSprite;
		yield return new WaitForSeconds(jumpCooldown / 2);
		canJump = true;
		yield break;
	}
	
	void Update() {
		PlayerMove();
		//rb.velocity = playerVelocity + gravityVelocity;
		//rb.velocity = new Vector2(playerVelocity.x, rb.velocity.y);
		//rb.AddForce(Vector2.up * (playerVelocity.y + gravityVelocity.y));
		//rb.AddForce(playerVelocity + gravityVelocity, ForceMode2D.Impulse);
	}
	
}
