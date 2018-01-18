using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireStrike : MonoBehaviour {
	HunterMain Parent;
	float MaxTime;
	void Start () {
		Parent = GetComponentInParent<HunterMain> ();
		MaxTime = Parent.shotTime;
	}
	

	void Update () {
		if (Parent.shotTime > MaxTime-0.2f) {
			
		} else {
			gameObject.SetActive (false);
		}
		
	}
}
