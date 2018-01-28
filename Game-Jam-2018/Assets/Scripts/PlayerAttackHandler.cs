using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackHandler : MonoBehaviour {

    public float damage;
    public float range;
    public GameObject collidedObject;
    private RaycastHit2D rayhit;
    private GameObject child;

    public AudioSource source;
    public AudioClip attackSound;

	// Use this for initialization
	void Start () {
        damage = 7f;
        range = 4.20f;
        child = transform.Find("Slash Attack").gameObject;
        child.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Attack")) {
            source.PlayOneShot(attackSound, 1.0f);
            StartCoroutine(HandleAttack());
            Debug.Log("Attacking!");
            // Detect enemy with linecast
            rayhit = Physics2D.Linecast(transform.position, transform.position + new Vector3(range * transform.localScale.x, 0, 0), 1 << 11);
            if (rayhit) {
                collidedObject = rayhit.collider.gameObject;
                collidedObject.GetComponent<Rigidbody2D>().AddForce(transform.right * transform.localScale.x * range * 500);
                collidedObject.GetComponent<Enemy>().OnHit(gameObject, damage);
            }
            else {
                rayhit = new RaycastHit2D();
            }
        }
	}

    private IEnumerator HandleAttack() {
        child.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        child.SetActive(false);
    }

    void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + new Vector3(range * transform.localScale.x, 0, 0));
    }
}
