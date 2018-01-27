using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snail : MonoBehaviour {
    //Just gonna go ahead and steal some code from Jacob's TiScript

    //I guess it just knows where it is
    public Vector3 pos;
    public Rigidbody2D rb; //and again, whatever you want to call it

    public bool falling = false;
    private bool jumping = false;

    public int health = 30;

    public float relScaleX;
    public float relScaleY;

    // Use this for initialization
    void Start()
    {
        pos = transform.position;
        Debug.Log("pos is " + pos.x);
        rb = GetComponent<Rigidbody2D>();
        relScaleX = transform.localScale.x;
        relScaleY = transform.localScale.y;
    }


    // Update is called once per frame
    void Update () {
        Vector3 position = this.transform.position;
        position.x -= 0.03f;
        this.transform.position = position;
        transform.localScale = new Vector3(relScaleX, relScaleY, 1);
    }
}
