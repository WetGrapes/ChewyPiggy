using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownSightTap : MonoBehaviour {
	InterfaceManagerScript Interface;
	void Start () {
		Interface = GameObject.FindGameObjectWithTag ("InterfaceManager").GetComponent<InterfaceManagerScript> ();
		#if UNITY_EDITOR
		if(Interface == null)
			Debug.Log ("DownSightTap - InterfaceManager not found");
		#endif
	}

	void OnMouseDown(){
		Interface.DownSightActivate = true;
	}

	void OnMouseUp(){
		Interface.DownSightActivate = false;
	}
}
