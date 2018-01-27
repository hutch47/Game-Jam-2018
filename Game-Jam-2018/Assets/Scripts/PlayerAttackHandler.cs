using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackHandler : MonoBehaviour {

    public float damage;
    public float range;
    public GameObject collidedObject;
    private RaycastHit2D rayhit;

	// Use this for initialization
	void Start () {
        damage = 7f;
        range = 3f;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Attack")) {
            // Detect enemy with linecast
            rayhit = Physics2D.Linecast(transform.position, transform.position + new Vector3(range, 0, 0), 1 << 9);
            if (rayhit) {
                collidedObject = rayhit.collider.gameObject;
                collidedObject.GetComponent<Health>().value -= damage;
                collidedObject.GetComponent<Rigidbody2D>().AddForce(transform.right * range * 500);
                collidedObject.GetComponent<Enemy>().OnHit(gameObject);
            }
            else {
                rayhit = new RaycastHit2D();
            }
            
        }
	}
    void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + new Vector3(range, 0, 0));
    }
}
