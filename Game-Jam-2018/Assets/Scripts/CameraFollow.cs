using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public GameObject target;
	public float offset = 2.5f;

	private SpriteRenderer sr;

	private bool flip_state_last;
	private float animation_time = 0f;
	public float transition_speed = 0.5f;

	void Start() {
		sr = target.GetComponentInChildren<SpriteRenderer>();
		flip_state_last = sr.flipX;
	}

	void LateUpdate() {
		Vector3 tp = target.transform.position; // Target position
		Vector3 cp = transform.position; // Camera position

		if (sr.flipX != flip_state_last) {
			animation_time = 0f;
			flip_state_last = sr.flipX;
		}

		if (animation_time < transition_speed) {
			animation_time += Time.deltaTime;

			if (sr.flipX) {
				cp.x = tp.x + offset - (2 * offset * (animation_time / transition_speed));
			} else {
				cp.x = tp.x - offset + (2 * offset * (animation_time / transition_speed));;
			}
		} else {
			if (sr.flipX) {
				cp.x = tp.x - offset;
			} else {
				cp.x = tp.x + offset;
			}
		}

		transform.position = cp;
	}
}
