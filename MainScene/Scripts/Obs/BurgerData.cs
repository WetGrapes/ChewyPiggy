using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurgerData : MonoBehaviour {
	GameObject TransformManager, InterfaceManager;
	Vector2 PigPos;
	void Start(){
		TransformManager = GameObject.FindGameObjectWithTag ("PigTransformManager");
		InterfaceManager = GameObject.FindGameObjectWithTag ("InterfaceManager");
	}
	void FixedUpdate(){
		PigPos = TransformManager.GetComponent<PigTransformManagerScript> ().PigPos;
		if (Mathf.Abs (PigPos.x - transform.position.x) < 1.0f &&
			Mathf.Abs (PigPos.y - transform.position.y) < 1.0f ) {
			InterfaceManager.GetComponent<InterfaceManagerScript> ().LifeTimeNow += 30;
			Destroy (transform.gameObject);
		}
	}
}
