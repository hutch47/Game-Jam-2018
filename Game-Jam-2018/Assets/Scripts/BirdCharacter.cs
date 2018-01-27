using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdCharacter : MonoBehaviour {

	private bool jump = false;

	public Transform groundCheck;
	private bool grounded = false;
	private Rigidbody2D rb;
	private SpriteRenderer sr;

	public float jumpForce = 1000f;
	public float maxVelocity = 5f;
	public float moveForce = 50f;

	public AudioClip jumpSound;
	private AudioSource source;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		sr = GetComponentInChildren<SpriteRenderer>();
		source = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		grounded = Physics2D.Linecast (transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

		if (Input.GetButtonDown ("Jump") && grounded) {
			jump = true;
			source.PlayOneShot (jumpSound, 1.0f);
		}
	}

	void FixedUpdate () {
		float h = Input.GetAxis("Horizontal");

		if (h < 0) {
			rb.AddForce (Vector2.left * moveForce); // Move left

			// Face left
			if (!sr.flipX) 
				sr.flipX = true;
		} else if (h > 0) {
			rb.AddForce (Vector2.right * moveForce); // Move right

			// Face right
			if (sr.flipX) 
				sr.flipX = false;
		}
			
		// Ensure we don't go too fast
		if(Mathf.Abs(rb.velocity.x) > maxVelocity)
			rb.velocity = new Vector2 (Mathf.Sign(rb.velocity.x) * maxVelocity, rb.velocity.y);

		if (jump) {
			rb.AddForce(new Vector2(0f, jumpForce));
			jump = false;
		}
	}
}
