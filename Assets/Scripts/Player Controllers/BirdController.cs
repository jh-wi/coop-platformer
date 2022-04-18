// using System.Runtime.Intrinsics;
// using System.Numerics;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour{
    
    public float HSpeed = 10f;
    private float curr_speed = 10f;
	private bool facingRight = false;
    private bool leftCurrent = true;

    //Used for flipping Character Direction
	public static Vector3 theScale;

	//Jumping Stuff
	public Transform groundCheck;
	public LayerMask whatIsGround;
	private bool grounded = false;
	private float groundRadius = 0.5f;
	public float flyForce = 3f;
    // private float landForce = -2f;

	private Animator anim;

	void Awake (){
		anim = GetComponent<Animator> ();
        // GetComponent<Rigidbody2D>().velocity = new Vector2(curr_speed, GetComponent<Rigidbody2D>().velocity.y); 
	}

    void start(){
        GetComponent<Rigidbody2D>().velocity = new Vector2(curr_speed, GetComponent<Rigidbody2D>().velocity.y); 
    }
    
    

	void FixedUpdate (){

		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
		anim.SetBool ("isGrounded", true);
        anim.SetBool("isHopping", false);
        anim.SetBool("isFlying", false);

        // UnityEngine.Debug.Log("grounded: ");
        // UnityEngine.Debug.Log(grounded);

        if(!grounded){
            anim.SetBool("isFlying", true);
        }
        

         
	}

	void Update(){
        

        if (Input.GetKeyDown(Keybinds.birdJump)){
            anim.SetBool("isGrounded", false);
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.y, flyForce);
           
        }//else if ((grounded) && Input.GetKey(down)){
        //     // anim.SetBool("ground", false);
        //     grounded = false;
        //     GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.y, landForce);
        // }

        
        if (Input.GetKey(Keybinds.birdLeft)){
            leftCurrent = true;
            curr_speed = -HSpeed;
        }else if (Input.GetKey(Keybinds.birdRight)){
            leftCurrent = false;
            curr_speed = HSpeed; 
        }else{
            curr_speed = 0;   
        }
        GetComponent<Rigidbody2D>().velocity = new Vector2(curr_speed, GetComponent<Rigidbody2D>().velocity.y); 
        //Flipping direction character is facing based on players Input
        if (!leftCurrent && facingRight)
            Flip();
        else if (leftCurrent && !facingRight)
            Flip();
    }
    ////Flipping direction of character
    void Flip(){
		facingRight = !facingRight;
		theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

}
