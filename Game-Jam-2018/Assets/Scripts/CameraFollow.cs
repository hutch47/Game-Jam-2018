using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public GameObject target;
	public float offset = 2.5f;

	private bool flip_state_last;
	private float animation_time = 0f;
	public float transition_speed = 0.5f;

	void Start() {
		flip_state_last = target.transform.localScale.x < 0;


		transform.position = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z);
	}

	void LateUpdate() {
		Vector3 tp = target.transform.position; // Target position
		Vector3 cp = transform.position; // Camera position

		bool flipped = target.transform.localScale.x < 0;

		if (flipped != flip_state_last) {
			animation_time = 0f;
			flip_state_last = flipped;
		}

		if (animation_time < transition_speed) {
			animation_time += Time.deltaTime;

			if (flipped) {
				cp.x = tp.x + offset - (2 * offset * (animation_time / transition_speed));
			} else {
				cp.x = tp.x - offset + (2 * offset * (animation_time / transition_speed));;
			}
		} else {
			if (flipped) {
				cp.x = tp.x - offset;
			} else {
				cp.x = tp.x + offset;
			}
		}

		transform.position = cp;
	}
}
