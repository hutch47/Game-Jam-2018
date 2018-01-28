using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private bool jump = false;

	public Transform groundCheck;
	private bool grounded = false;
	private bool justGrounded = false;

	private Rigidbody2D rb;

	public float jumpForce = 1000f;
	public float maxVelocity = 5f;
	public float moveForce = 50f;

	public AudioClip jumpSound;
	public AudioClip jumpLandSound;
	public float jumpLandSoundMinVelocity = 10.0f;
	private bool jumpLandSoundPlayed = false;
	private AudioSource source;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		source = GetComponent<AudioSource>();
	}

	// Update is called once per frame
	void Update () {

		if (Physics2D.Linecast (transform.position, groundCheck.position, 1 << LayerMask.NameToLayer ("Ground"))) {
			grounded = true;
		} else {
			grounded = false;
		}

		// If we hit the ground fast enough, play a sound effect
		if (!jumpLandSoundPlayed && grounded && rb.velocity.y < jumpLandSoundMinVelocity) {
			source.PlayOneShot (jumpLandSound, 1.0f);
			jumpLandSoundPlayed = true;
		} 

		if (rb.velocity.y >= jumpLandSoundMinVelocity && !grounded) {
			// Allow landing sound to be played again if we are no longer grounded
			jumpLandSoundPlayed = false;
		}

		if (Input.GetButtonDown ("Jump") && grounded) {
			jump = true;
			source.PlayOneShot (jumpSound, 1.0f);
		}
	}

	void FixedUpdate () {
		float h = Input.GetAxis("Horizontal");


		bool flipped = transform.localScale.x < 0;


		if (h < 0) {
			rb.AddForce (Vector2.left * moveForce); // Move left

			// Face left
			if (!flipped) {
				transform.localScale = new Vector3(transform.localScale.x*-1, transform.localScale.y, transform.localScale.z);
			}
		} else if (h > 0) {
			rb.AddForce (Vector2.right * moveForce); // Move right

			// Face right
			if (flipped) {
				transform.localScale = new Vector3(transform.localScale.x*-1, transform.localScale.y, transform.localScale.z);
			}
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
