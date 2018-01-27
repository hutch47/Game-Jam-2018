using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdCharacter : MonoBehaviour {

	private bool jump = false;

	public Transform groundCheck;
	private bool grounded = false;
	private Rigidbody2D rb;

	public float jumpForce = 1000f;
	public float maxVelocity = 5f;
	public float moveForce = 50f;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		grounded = Physics2D.Linecast (transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

		if (Input.GetButtonDown("Jump") && grounded) 
			jump = true;
		
	}

	void FixedUpdate () {
		float h = Input.GetAxis("Horizontal");

		if (h < 0)
			rb.AddForce (Vector2.left * moveForce);
		else if (h > 0)
			rb.AddForce (Vector2.right * moveForce);

		// Ensure we don't go too fast
		if(Mathf.Abs(rb.velocity.x) > maxVelocity)
			rb.velocity = new Vector2 (Mathf.Sign(rb.velocity.x) * maxVelocity, rb.velocity.y);

		if (jump) {
			GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce));
			jump = false;
		}
	}
}
