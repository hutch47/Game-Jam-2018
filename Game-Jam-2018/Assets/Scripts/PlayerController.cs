using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private bool jump = false;

	public Transform groundCheck;
	private bool grounded = false;
	private bool justGrounded = false;

	private Rigidbody2D rb;


    public float relScaleX;
    public float relScaleY;

    public float speed = 0.2f;

    public float jumpForce = 1000f;
	public float maxVelocity = 5f;
	public float moveForce = 50f;
    public int runModifier = 2;

    public AudioClip jumpSound;
	public AudioClip jumpLandSound;
	public float jumpLandSoundMinVelocity = 10.0f;
	private bool jumpLandSoundPlayed = false;
	private AudioSource source;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		source = GetComponent<AudioSource>();
        relScaleX = transform.localScale.x;
        relScaleY = transform.localScale.y;
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


        if (Input.GetButton("Horizontal") && Input.GetAxisRaw("Horizontal") > 0)
        {
            Vector3 position = this.transform.position;
            if (Input.GetButton("Fire3"))
            {
                position.x += speed * runModifier;
            }
            else
            {
                position.x += speed;
            }
            this.transform.position = position;
            transform.localScale = new Vector3(relScaleX, relScaleY, 1);
        }
        else if (Input.GetButton("Horizontal") && Input.GetAxisRaw("Horizontal") < 0)
        {
            Vector3 position = this.transform.position;
            if (Input.GetButton("Fire3"))
            {
                position.x -= speed * runModifier;
            }
            else
            {
                position.x -= speed;
            }
            this.transform.position = position;
            transform.localScale = new Vector3(-relScaleX, relScaleY, 1);
        }

        // Ensure we don't go too fast
        /*if(Mathf.Abs(rb.velocity.x) > maxVelocity)
			rb.velocity = new Vector2 (Mathf.Sign(rb.velocity.x) * maxVelocity, rb.velocity.y);
            */
        if (jump) {
			rb.AddForce(new Vector2(0f, jumpForce));
			jump = false;
		}
	}
}
