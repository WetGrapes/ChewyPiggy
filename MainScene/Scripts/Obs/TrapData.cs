using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapData : MonoBehaviour {
	GameObject ManagerTransform;
	Vector2 PigPos;
	bool _ACTIVE = true;
	void Start () {
		ManagerTransform = GameObject.FindGameObjectWithTag ("PigTransformManager");
	}
	void FixedUpdate () {
		PigPos = ManagerTransform.GetComponent<PigTransformManagerScript> ().PigPos;
		if (Mathf.Abs (PigPos.x - transform.position.x) < 1.0f &&
		    Mathf.Abs (PigPos.y - transform.position.y) < 1.0f &&
		    _ACTIVE == true) {
			ManagerTransform.GetComponent<PigTransformManagerScript> ().Dead = _ACTIVE;
			_ACTIVE = false;
			GetComponent<SpriteList> ().number = 1;
		}
	}
}
