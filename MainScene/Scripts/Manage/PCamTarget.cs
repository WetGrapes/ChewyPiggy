using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCamTarget : MonoBehaviour {
	InterfaceManagerScript Interface;
	float timer;

	void Start () {
		Interface = GameObject.FindGameObjectWithTag ("InterfaceManager").GetComponent<InterfaceManagerScript> ();
		#if UNITY_EDITOR
		if(Interface == null)
			Debug.Log ("DownSightTap - InterfaceManager not found");
		#endif
	}
	

	void Update () {
		if (Interface.DownSightActivate) {
			transform.localPosition = new Vector3 (transform.localPosition.x, -15, transform.localPosition.z);
			timer = 0.5f;
		} else {
			if (timer>=0)
				transform.localPosition = new Vector3 (transform.localPosition.x, 7, transform.localPosition.z);
			else
				transform.localPosition = new Vector3 (transform.localPosition.x, 1, transform.localPosition.z);
			timer -= Time.deltaTime;
		}
	}
}
