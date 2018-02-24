using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTheGame : MonoBehaviour {

	InterfaceManagerScript Interface;

	void Start () {
		Interface = GameObject.FindGameObjectWithTag ("InterfaceManager").GetComponent<InterfaceManagerScript> ();
		if(Interface == null)
			Debug.Log ("PigTransformManagerScript - InterfaceManager not found");
	}

	void OnMouseDown()
	{
		Interface.StartGameTrue = false;
		Interface.AbilitiesTrue = true;
		Interface.AccountantTrue = true;
		Interface.PauseTrue = true;
		Interface.LifeTimeTrue = true;
	}

}
