using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchButton : MonoBehaviour {

    public Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        //rb = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            rb = collision.gameObject.GetComponent<Rigidbody2D>();
            rb.AddForce(new Vector2(0, 10), ForceMode2D.Impulse);
        }
    }
}
