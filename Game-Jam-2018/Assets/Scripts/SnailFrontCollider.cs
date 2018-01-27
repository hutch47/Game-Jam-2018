using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnailFrontCollider : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.otherCollider.Equals(gameObject.GetComponentInParent<Snail>().collider))
        gameObject.GetComponentInParent<Snail>().left = !gameObject.GetComponentInParent<Snail>().left;
        gameObject.GetComponentInParent<Snail>().transform.localScale = new Vector3(-0.5f, 0.5f);
    }
}
