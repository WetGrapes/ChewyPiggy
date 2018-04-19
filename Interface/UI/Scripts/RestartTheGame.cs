using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartTheGame : MonoBehaviour {

	InterfaceManagerScript Interface;

	void Start () {
		Interface = GameObject.FindGameObjectWithTag ("InterfaceManager").GetComponent<InterfaceManagerScript> ();
	}

	void OnMouseDown()
	{
		Interface.RestartActivated = true;;

	}
}
