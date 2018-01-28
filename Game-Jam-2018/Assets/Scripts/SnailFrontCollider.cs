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
        gameObject.GetComponentInParent<Snail>().left = !gameObject.GetComponentInParent<Snail>().left;
        gameObject.GetComponentInParent<Snail>().transform.Rotate(0, 180, 0);
        if (collision.gameObject.tag == "player")
        {
            collision.gameObject.GetComponent<Player>().OnHit(gameObject.GetComponentInParent<Snail>().gameObject, gameObject.GetComponentInParent<Snail>().damage);
            if (gameObject.GetComponentInParent<Snail>().left)
            {
                collision.gameObject.GetComponent<Player>().GetComponent<ConstantForce2D>().force = new Vector2(-10f, 0);
            }
            else
            {
                collision.gameObject.GetComponent<Player>().GetComponent<ConstantForce2D>().force = new Vector2(10f, 0);
            }
            
        }
    }

    
}
