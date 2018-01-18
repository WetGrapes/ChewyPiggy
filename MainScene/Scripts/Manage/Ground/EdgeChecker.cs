using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeChecker : MonoBehaviour {
	PigTransformManagerScript Trans;
	GenerationController Generator;
	Vector2 PigPos;
	[SerializeField] private bool Right;

	void Start () {
		Trans = GameObject.FindGameObjectWithTag ("PigTransformManager").GetComponent<PigTransformManagerScript> ();
		Generator = GameObject.FindGameObjectWithTag ("GenerationManager").GetComponent<GenerationController> ();
	}
	

	void FixedUpdate () {
		PigPos = Trans.GetComponent<PigTransformManagerScript> ().PigPos;
		if (Mathf.Abs (PigPos.x - transform.position.x) < 1f) {
			Generator.Right = Right;
			Generator.GenerationActive = true;
			Destroy (transform.gameObject);
		}
	}
}
