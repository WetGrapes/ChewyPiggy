using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AccountantTime : MonoBehaviour {

	InterfaceManagerScript Interface;
	[SerializeField]Text txt = null;
	int  Minute, Second, allTime;
	string Zero = "0" , Zero2 ;

	void Start () {
		Interface = GameObject.FindGameObjectWithTag ("InterfaceManager").GetComponent<InterfaceManagerScript> ();
		if(Interface == null)
			Debug.Log ("PigTransformManagerScript - InterfaceManager not found");
	}

	void FixedUpdate () {
		
		allTime = (int)Interface.LifeTimeNow;
		Minute = allTime / 60;
		Second = allTime % 60;
		if (Second == 0) Zero2 = "0";
		else Zero2 = "";
		txt.text = Zero + Minute.ToString () + "." + Second.ToString () + Zero2;
	}


}
