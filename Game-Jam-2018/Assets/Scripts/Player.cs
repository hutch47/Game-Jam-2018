using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public Health hp;
    public bool isAttacking;

	// Use this for initialization
	void Start () {
        hp = GetComponent<Health>();
        hp.value = 50f;
        hp.max = 50f;

	}
	
	// Update is called once per frame
	void Update () {

	}

    void UpdateHealthBar() {

    }
    public void OnHit() {

    }


    /*
     TO DO:
        Detect damage
        Encase HP with a setter/getter
     */
}
