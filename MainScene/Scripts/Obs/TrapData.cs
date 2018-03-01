using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapData : MonoBehaviour {
	GameObject ManagerTransform;
	Vector2 PigPos;
	bool _ACTIVE = true;
	void Start () {
		ManagerTransform = GameObject.FindGameObjectWithTag ("PigTransformManager");
		GetComponent<SpriteList> ().number = 1;
	}
	void FixedUpdate () {
		PigPos = ManagerTransform.GetComponent<PigTransformManagerScript> ().PigPos;
		if (Mathf.Abs (PigPos.x - transform.position.x) < 0.5f &&
		    Mathf.Abs (PigPos.y - transform.position.y) < 0.5f &&
		    _ACTIVE == true) 
		{
			ManagerTransform.GetComponent<PigTransformManagerScript> ().Dead = _ACTIVE;
			_ACTIVE = false;
			GetComponent<SpriteList> ().number = 0;
		}

	}
}
