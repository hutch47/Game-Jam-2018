using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {

    public float damage;
    public float range;

	// Use this for initialization
	void Start () {
        damage = 5f;
        range = 2f;
	}
	
	// Update is called once per frame
	void Update () {

	}

    void OnCollisionEnter2D(Collision2D coll) {
        Debug.Log("COLLIDED");
        if (coll.gameObject.tag == "Enemy")
            coll.gameObject.GetComponent<Enemy>().hp.value -= damage;
    }
}
