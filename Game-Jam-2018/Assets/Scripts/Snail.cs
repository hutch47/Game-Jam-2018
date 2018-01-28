using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snail : MonoBehaviour {
    //Just gonna go ahead and steal some code from Jacob's TiScript

    //I guess it just knows where it is
    public Vector3 pos;
    public Rigidbody2D rb; //and again, whatever you want to call it

    //public bool falling = false;
    public bool left = true;

    private float movespeed = 0.02f;

    public float damage = 10;

    //public int health = 30;

    public float relScaleX;
    public float relScaleY;

    public bool moveChange;

    // Use this for initialization
    void Start()
    {
        pos = transform.position;
        Debug.Log("pos is " + pos.x);
        rb = GetComponent<Rigidbody2D>();
        relScaleX = transform.localScale.x;
        relScaleY = transform.localScale.y;
        moveChange = false;
    }


    // Update is called once per frame
    void Update () {
        if (moveChange) {
            transform.localScale = new Vector3(transform.localScale.x * -1, 1, 1);
            moveChange = false;
        }
        Vector3 position = this.transform.position;
        transform.localScale = new Vector3(relScaleX, 1, 1);
        if (left)
        {
            position.x -= movespeed;
        }
        else
        {
            position.x += movespeed;
        }
        this.transform.position = position;
        transform.localScale = new Vector3(relScaleX, relScaleY, 1);
        
        
    }

    public void OnDrawGizmos()
    {
        Vector3 centre = transform.position;
        Gizmos.color = Color.red;
        Gizmos.DrawCube(centre, new Vector3());
    }

}
