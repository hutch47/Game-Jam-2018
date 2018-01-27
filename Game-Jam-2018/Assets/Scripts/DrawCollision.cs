using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnDrawGizmos()
    {
        Vector3 centre = transform.position;
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(centre, GetComponent<BoxCollider2D>().bounds.size);
    }
}
