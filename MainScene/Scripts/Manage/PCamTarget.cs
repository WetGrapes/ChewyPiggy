using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCamTarget : MonoBehaviour {
	PigTransformManagerScript Trans;
	float timer;

	void Start () {
		Trans = GameObject.FindGameObjectWithTag ("PigTransformManager").GetComponent<PigTransformManagerScript> ();
	}
	

	void Update () {
		if (Trans.downSight) {
			transform.localPosition = new Vector3 (2, -15, 0);
			timer = 0.5f;
		} else {
			if (timer>=0)
				transform.localPosition = new Vector3 (2, 7, 0);
			else
				transform.localPosition = new Vector3 (2, 1, 0);
			timer -= Time.deltaTime;
		}
	}
}
