using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickDetecter : MonoBehaviour {
	BoxCollider Render;
	PigTransformManagerScript Trans;

	void Start(){
		Render = GetComponent<BoxCollider> ();
		Trans = GameObject.FindGameObjectWithTag ("PigTransformManager").GetComponent<PigTransformManagerScript> ();
		if(Trans == null)
			Debug.Log ("ClickDetecter - Transform Manager not found");
		
	}
	void OnMouseDrag() {
		if (Trans.StartG == false) {
			if (Input.touchCount == 1 || Input.touchCount == 0) {
				if (Input.mousePosition.x < Render.size.x * Screen.width / 2) {
					Trans.left = true;
					Trans.right = false;
					Trans.rotate = 180;
				} else {
					Trans.right = true;
					Trans.left = false;
					Trans.rotate = 0;
				}
			}

			if (Input.touchCount == 2)
				Trans.TwoTaps = true;
			else
				Trans.TwoTaps = false;
		
			Trans.forceTrue = true;
		}
	}
	void OnMouseUp(){
		Trans.left = false;
		Trans.right = false;
		Trans.forceTrue = false;
	}
}
