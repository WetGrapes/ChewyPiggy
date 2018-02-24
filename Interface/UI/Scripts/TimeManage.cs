using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManage : MonoBehaviour {
	InterfaceManagerScript Interface;
	float Timer = 0;

	void Start () {
		Interface = GameObject.FindGameObjectWithTag ("InterfaceManager").GetComponent<InterfaceManagerScript> ();
		if(Interface == null)
			Debug.Log ("TimeManage - InterfaceManager not found");
	}
	

	void FixedUpdate () {
		if (Interface.LifeTimeTrue == true) {
			if (Timer <= 1)
				Timer += Time.fixedDeltaTime;
			else {
				Interface.LifeTimeNow -= 1;
				Timer = 0;
			}
		}
	}
}
