using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiGroundCollier : MonoBehaviour {

    TiScript script;

	// Use this for initialization
	void Start () {
        script = this.transform.parent.GetComponent<TiScript>();
    }

    // Update is called once per frame
    void Update() {
        //Add layer mask later
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position - new Vector3(0, 0.65f), 0.3f);
        print("Num colliders" + hitColliders.Length);
        if (hitColliders.Length > 1)
        {
            script.falling = false;
        }
        else
        {
            script.falling = true;
        }
    }

    void OnDrawGizmos()
    {
        Vector3 centre = transform.position;
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(centre - new Vector3(0, 0.65f, 0), new Vector3(1.5f, 0.4f));
    }
}
