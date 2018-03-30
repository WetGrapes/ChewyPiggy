using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRetraction : MonoBehaviour {

	[SerializeField] [Range(3,8)] float standartRange = 4.5f;
	[SerializeField] [Range(3,8)] float reverseRange = 6.5f;
	[SerializeField] bool Reverse = true;
	float speedy = .0f;
	PigTransformManagerScript Trans;
	Camera cam;
	void Start () {
		Trans = GameObject.FindGameObjectWithTag ("PigTransformManager").GetComponent<PigTransformManagerScript> ();
		cam = gameObject.GetComponent<Camera> ();
	}
	

	void FixedUpdate () {
		if (speedy <= Trans.speed / 4) {
			if (speedy <= 2.1f)
				speedy += (Time.deltaTime / 1.25f);
		} else {
			if (speedy >= 0.2f)
				speedy -= Time.deltaTime / 0.75f;
		}
		if (Reverse)
			cam.orthographicSize = reverseRange - speedy;
		else
			cam.orthographicSize = standartRange + speedy;
	}
}
