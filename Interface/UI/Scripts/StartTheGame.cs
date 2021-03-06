﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTheGame : MonoBehaviour {

	InterfaceManagerScript Interface;

	void Start () {
		Interface = GameObject.FindGameObjectWithTag ("InterfaceManager").GetComponent<InterfaceManagerScript> ();
		#if UNITY_EDITOR
		if(Interface == null)
			Debug.Log ("StartTheGame - InterfaceManager not found");
		#endif
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
