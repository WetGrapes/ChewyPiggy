using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownSightTap : MonoBehaviour {
	PigTransformManagerScript Trans;
	// Use this for initialization
	void Start () {
		Trans = GameObject.FindGameObjectWithTag ("PigTransformManager").GetComponent<PigTransformManagerScript> ();
	}
	
	void OnMouseDrag(){
		Trans.downSight = true;
		Trans.speed = 0;
		Trans.TwoTaps = false;
	}

	void OnMouseUp(){
		Trans.downSight = false;
	}
}
