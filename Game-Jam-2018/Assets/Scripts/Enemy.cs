using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

    public Health hp;
    public GameObject deathEffect;
    private GameObject death2;
    private float opacity;
    private bool dead;

	// Use this for initialization
	void Start () {
        hp = GetComponent<Health>();
        hp.value = 25f;
        hp.max = 25f;
        opacity = 1f;
        dead = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (dead) {
            opacity -= 0.01f;
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, opacity);
        }
	}

    public void OnHit(GameObject source, float dmg) {
        hp.value -= dmg;
        if (hp.value <= 0) {
            dead = true;
            death2 = Instantiate(deathEffect, transform.position, deathEffect.transform.rotation);
            death2.transform.parent = gameObject.transform;
            StartCoroutine(HandleDeath());
            
        }
    }
    private IEnumerator HandleDeath()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
    }
}
