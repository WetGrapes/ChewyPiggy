using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRetraction : MonoBehaviour {

	[SerializeField] [Range(3,8)] float standartRange;
	[SerializeField] [Range(3,8)] float reverseRange;
	[SerializeField] bool Reverse;
	float speedy=.0f;
	PigTransformManagerScript Trans;
	Camera camera;
	void Start () {
		Trans = GameObject.FindGameObjectWithTag ("PigTransformManager").GetComponent<PigTransformManagerScript> ();
		camera = gameObject.GetComponent<Camera> ();
	}
	

	void FixedUpdate () {
		if (speedy <= Trans.speed / 4) {
			if (speedy <= 2.1f)
				speedy += Time.deltaTime * (speedy + 1f);
		} else {
			if (speedy >= 0.2f)
				speedy -= Time.deltaTime;
		}
		if (Reverse)
			camera.orthographicSize = reverseRange - speedy;
		else
			camera.orthographicSize = standartRange + speedy;
	}
}
