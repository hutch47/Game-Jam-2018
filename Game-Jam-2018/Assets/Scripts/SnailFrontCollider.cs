using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnailFrontCollider : MonoBehaviour {

    Snail script;
    float relScale;

	// Use this for initialization
	void Start () {
        script = this.transform.parent.GetComponent<Snail>();
        relScale = script.relScaleX;
    }
	
	// Update is called once per frame
	void Update () {
        print(transform.position);
        Collider2D[] hitColliders = Physics2D.OverlapBoxAll(transform.position - new Vector3(0, 0.80f / relScale, 0), new Vector2(0.5f / relScale, 1.7f / relScale), Vector2.Angle(Vector2.zero, transform.position));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.otherCollider.Equals(gameObject.GetComponentInParent<Snail>().collider))
        gameObject.GetComponentInParent<Snail>().left = !gameObject.GetComponentInParent<Snail>().left;
        gameObject.GetComponentInParent<Snail>().transform.localScale = new Vector3(-0.5f, 0.5f);
    }

    
}
