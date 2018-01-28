using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySnailAttackHandler : MonoBehaviour {

    public float damage;
    public float range;
    public GameObject collidedObject;
    private RaycastHit2D rayhit;
    private GameObject child;

    // Use this for initialization
    void Start () {
        damage = 4f;
        range = 4.20f;
        child = transform.Find("Slash Attack").gameObject;
        child.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        rayhit = Physics2D.Linecast(transform.position, transform.position + new Vector3(range * transform.localScale.x, 0, 0) );
	}

    private IEnumerator HandleAttack()
    {
        child.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        child.SetActive(false);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + new Vector3(range * transform.localScale.x, 0, 0));
    }
}
