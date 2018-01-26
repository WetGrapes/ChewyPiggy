/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideOutsideCamera : MonoBehaviour {

	CameraManage CamManager;
	Camera Cam;
	void Start () {
		CamManager = GameObject.FindGameObjectWithTag ("Camera").GetComponent<CameraManage> ();
		Cam = GameObject.FindGameObjectWithTag ("Camera").GetComponent<Camera> ();
	}
	

	void FixedUpdate () {
		if (Mathf.Abs (transform.position.x - CamManager.ThisCamTransform.position.x) >
			Cam.orthographicSize * 2 + 2 || 
			Mathf.Abs (transform.position.y - CamManager.ThisCamTransform.position.y) >
			Cam.orthographicSize * 2 + 2)
			transform.GetComponent<SpriteRenderer> ().enabled = false;
		else
			transform.GetComponent<SpriteRenderer> ().enabled = true;
	}
}*/
