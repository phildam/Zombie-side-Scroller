using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float runSpeed = 10.0f;
	public float walkSpeed = 2.0f;
	bool running;

	private Rigidbody myRB;
	private Animator myAnim;
	
	bool grounded = false;
	Collider[] groundCollisions;
	float groundCheckRadius = 0.2f;
	public LayerMask groundLayer;
	public Transform groundCheck;
	public float jumpHeight;

	public string facingDirection = "right";

	void Start () {
		Physics.gravity = new Vector3(0, -27.0F, 0);
		myRB = GetComponent<Rigidbody>();
		myAnim = GetComponent<Animator>();
	}
	
	void Update () {
		
	}

	private void FixedUpdate() {
		bool running = false;
		if(grounded && Input.GetAxis("Jump") > 0) {
			grounded = false;
			myAnim.SetBool("grounded", grounded);
			myRB.AddForce(new Vector3(0, jumpHeight, 0));
		}

		groundCollisions = Physics.OverlapSphere(groundCheck.position, groundCheckRadius, groundLayer);
		grounded = groundCollisions.Length > 0 ? true : false;
		myAnim.SetBool("grounded", grounded);

		float move = Input.GetAxis("Horizontal");
		myAnim.SetFloat("speed", Mathf.Abs(move));

		float sneaking = Input.GetAxisRaw("Fire3");
		myAnim.SetFloat("sneaking", sneaking);

		float firing = Input.GetAxis("Fire1");
		myAnim.SetFloat("shooting", firing);

		if((sneaking > 0 || firing > 0) && grounded) {
			myRB.velocity = new Vector3(move * walkSpeed, myRB.velocity.y, 0);
		} else {
			myRB.velocity = new Vector3(move * runSpeed, myRB.velocity.y, 0);
			if(Mathf.Abs(move) > 0) {
				running = true;
			}
		}

		 if(move > 0) changeDirection("right");
		 else if(move < 0) changeDirection("left");
	}

	private void changeDirection(string direction) {
		Vector3 scale = transform.localScale;
		int scaleZ = direction == "right" ? 1 : -1;
		facingDirection = direction;
		scale.z = scaleZ;
		transform.localScale = scale;
	}

	public float getFacingDirection() {
		if(facingDirection == "right") {
			return 1;
		}
		return -1;
	}

	public bool isRunning() {
		return running;
	}

}
