using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiScript : MonoBehaviour {
    //I guess it just knows where it is
    public Vector3 pos;
    public Rigidbody2D rb; //and again, whatever you want to call it

    public bool falling = false;
    private bool jumping = false;

    public int health = 30;

    // Use this for initialization
    void Start () {
        pos = transform.position;
        Debug.Log("pos is " + pos.x);
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {

        //print(health);
        if (Input.GetButton("Horizontal") && Input.GetAxisRaw("Horizontal") > 0)
        {
            Vector3 position = this.transform.position;
            position.x += 0.05f;
            this.transform.position = position;
        }
        else if (Input.GetButton("Horizontal") && Input.GetAxisRaw("Horizontal") < 0)
        {
            Vector3 position = this.transform.position;
            position.x -= 0.05f;
            this.transform.position = position;
        }

        if (Input.GetButton("Jump"))
        {
            jumping = true;
            if (rb.velocity.magnitude > 2)
            {
                falling = true;
            }

            if (!falling)
            {
                rb.AddForce(new Vector2(0, 9), ForceMode2D.Impulse);
            }
        }
    }
}