using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafFactory : MonoBehaviour {

	public GameObject Leaf;
	GameObject NewLeaf;
	float xRand, timer = 0f;

	CameraManage CamManager;
	Camera Cam;
	
	void Start(){
		timer += Random.Range (0.1f, 2f);

		CamManager = GameObject.FindGameObjectWithTag ("Camera").GetComponent<CameraManage> ();
		Cam = GameObject.FindGameObjectWithTag ("Camera").GetComponent<Camera> ();
	}

	void Update () {
		if (timer > 0) 
			timer -= Time.deltaTime;
		 else {
			xRand = Random.Range (-1f, 1);
			NewLeaf = Instantiate (Leaf, new Vector3 (transform.position.x + xRand, transform.position.y, transform.position.z), 
				Quaternion.identity) as GameObject;
			NewLeaf.transform.SetParent (transform.parent);
			timer = 0f + Random.Range (0.1f, 2f);
		}
	}


	void FixedUpdate () {
		if (Mathf.Abs (transform.position.x - CamManager.ThisCamTransform.position.x) >
			Cam.orthographicSize * 2 + 5 || 
			Mathf.Abs (transform.position.y - CamManager.ThisCamTransform.position.y) >
			Cam.orthographicSize * 2 + 5)
			timer = 0f + Random.Range (0.1f, 2f);
	}
}
