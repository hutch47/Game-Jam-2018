using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiGroundCollier : MonoBehaviour {

    TiScript script;
    float relScale;

	// Use this for initialization
	void Start () {
        script = this.transform.parent.GetComponent<TiScript>();
        relScale = script.relScaleX;
    }

    // Update is called once per frame
    void Update() {
        //Add layer mask later
        Collider2D[] hitColliders = Physics2D.OverlapBoxAll(transform.position - new Vector3(0, 0.80f / relScale, 0), new Vector2(0.5f / relScale, 1.7f / relScale), Vector2.Angle(Vector2.zero, transform.position));
        if (hitColliders.Length > 1)
        {
            script.falling = false;
        }

        hitColliders = Physics2D.OverlapCircleAll(transform.position - new Vector3(0.9f / relScale, 0, 0), 0.2f / relScale);
        if (hitColliders.Length > 1)
        {
            if (Input.GetButtonDown("Jump"))
            {
                script.rb.AddForce(new Vector2(2f / relScale, 3f / relScale), ForceMode2D.Impulse);
            }
        }

        hitColliders = Physics2D.OverlapCircleAll(transform.position + new Vector3(0.9f / relScale, 0, 0), 0.2f / relScale);
        if (hitColliders.Length > 1)
        {
            if (Input.GetButtonDown("Jump"))
            {
                script.rb.AddForce(new Vector2(-2f / relScale, 3f / relScale), ForceMode2D.Impulse);
            }
        }
    }

    void OnDrawGizmos()
    {
        Vector3 centre = transform.position;
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(centre - new Vector3(0, 0.80f / relScale, 0), new Vector3(1.75f / relScale, 0.5f / relScale));
        Gizmos.DrawWireSphere(centre - new Vector3(0.27f / relScale, 0, 0), 0.7f / relScale);
        Gizmos.DrawWireSphere(centre + new Vector3(0.27f / relScale, 0, 0), 0.7f / relScale);
    }
}
