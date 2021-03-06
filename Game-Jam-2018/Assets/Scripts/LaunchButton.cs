﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchButton : MonoBehaviour {

    public Rigidbody2D rb;
	public AudioClip sound;
	private AudioSource source;
    public Vector2 force = new Vector2(0, 50);

	// Use this for initialization
	void Start () {
        //rb = GetComponent<Rigidbody2D>();
		source = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            rb = collision.gameObject.GetComponent<Rigidbody2D>();
            rb.AddForce(force, ForceMode2D.Impulse);

			// Play launch button sound 
			source.PlayOneShot(sound, 1.0f);
        }
    }
}
