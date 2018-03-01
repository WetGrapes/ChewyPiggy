using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManage : MonoBehaviour {
	InterfaceManagerScript Interface;
	float Timer = 0;
	[System.NonSerialized] public int  Minute=1, Second=0, allTime=60;
	[System.NonSerialized] public bool clock = true, accountant = false;

	void Start () {
		Interface = GameObject.FindGameObjectWithTag ("InterfaceManager").GetComponent<InterfaceManagerScript> ();
		#if UNITY_EDITOR
		if(Interface == null)
			Debug.Log ("TimeManage - InterfaceManager not found");
		#endif
	}
	

	void FixedUpdate () {
		if (Interface.LifeTimeTrue == true) {
			if (Timer <= 1)
				Timer += Time.fixedDeltaTime;
			else {
				Interface.LifeTimeNow -= 1;
				if (Interface.LifeTimeNow <= 0)
					Interface.GameOverTrue = true;
				Timer = 0;
			}
			allTime = (int)Interface.LifeTimeNow;
			Minute = allTime / 60;
			Second = allTime % 60;

			Interface.ClockTrue = clock;
			Interface.AccountantTrue = accountant;
		}


	}
}
