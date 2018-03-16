using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnactOutsideCamera : MonoBehaviour {

	CameraManage CamManager;
	Camera Cam;
	void Start () {
		CamManager = GameObject.FindGameObjectWithTag ("Camera").GetComponent<CameraManage> ();
		Cam = GameObject.FindGameObjectWithTag ("Camera").GetComponent<Camera> ();
	}


	void FixedUpdate () {
		if (Mathf.Abs (transform.position.x - CamManager.ThisCamTransform.position.x) >
			Cam.orthographicSize * 2 + 7 || 
			Mathf.Abs (transform.position.y - CamManager.ThisCamTransform.position.y) >
			Cam.orthographicSize * 2 + 7)
			gameObject.transform.GetChild (0).gameObject.SetActive (false);
		else
			gameObject.transform.GetChild (0).gameObject.SetActive (true);
	}
}

