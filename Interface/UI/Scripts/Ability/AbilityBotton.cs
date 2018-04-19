using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityBotton : MonoBehaviour {

	InterfaceManagerScript Interface;

	void Start () {
		Interface = GameObject.FindGameObjectWithTag ("InterfaceManager").GetComponent<InterfaceManagerScript> ();
		#if UNITY_EDITOR
		if(Interface == null)
			Debug.Log ("RestartTheGame - InterfaceManager not found");
		#endif
	}

	void OnMouseDown()
	{
		if (!Interface.AbilitiesMenu)
			Interface.AbilitiesMenu = true;
		else
			Interface.AbilitiesMenu = false;
	}
}
