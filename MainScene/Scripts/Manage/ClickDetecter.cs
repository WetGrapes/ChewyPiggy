using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickDetecter : MonoBehaviour {
	BoxCollider Render;
	PigTransformManagerScript Trans;

	void Start(){
		Render = GetComponent<BoxCollider> ();
		Trans = GameObject.FindGameObjectWithTag ("PigTransformManager").GetComponent<PigTransformManagerScript> ();
	}
	void OnMouseDown() {
		if (Input.mousePosition.x < Render.size.x * Screen.width / 2) {
			Trans.left = true;
			Trans.right = false;
			Trans.rotate = 180;
		} else {
			Trans.right = true;
			Trans.left = false;
			Trans.rotate = 0;
		}
		Trans.forceTrue = true;
	}
	void OnMouseUp(){
		Trans.left = false;
		Trans.right = false;
		Trans.forceTrue = false;
	}
}
