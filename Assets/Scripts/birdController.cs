using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class birdController : MonoBehaviour
{
    public KeyCode left;
    public KeyCode right;
    public KeyCode up;
    public KeyCode down;
    
    private float HSpeed = 10f;
	//private float maxVertHSpeed = 20f;
	private bool facingRight = true;
    private bool leftCurrent = false;

    //Used for flipping Character Direction
	public static Vector3 theScale;

	//Jumping Stuff
	public Transform groundCheck;
	public LayerMask whatIsGround;
	private bool grounded = false;
	private float groundRadius = 0.5f;
	private float flyForce = 3f;
    private float landForce = -2f;

	private Animator anim;

	// Use this for initialization
	void Awake ()
	{
//		startTime = Time.time;
		anim = GetComponent<Animator> ();
	}

	void FixedUpdate ()
	{

		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
		anim.SetBool ("ground", grounded);


	}

	void Update()
	{

        // moveXInput = Input.GetAxis("Horizontal");

        if ((grounded) && Input.GetKey(up)){
            anim.SetBool("ground", false);

            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.y, flyForce);
        }else if ((grounded) && Input.GetKey(down)){
            anim.SetBool("ground", false);
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.y, landForce);
        }

         
        if ((grounded) && Input.GetKey(left))
        {
            leftCurrent = true;
            GetComponent<Rigidbody2D>().velocity = new Vector2(HSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }else if ((grounded) && Input.GetKey(right))
        {
            leftCurrent = false;
            GetComponent<Rigidbody2D>().velocity = new Vector2(-HSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }else{
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, GetComponent<Rigidbody2D>().velocity.y);   
        }

        //Flipping direction character is facing based on players Input
        if (!leftCurrent && facingRight)
            Flip();
        else if (leftCurrent && !facingRight)
            Flip();
    }
    ////Flipping direction of character
    void Flip()
	{
		facingRight = !facingRight;
		theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
