using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManage : MonoBehaviour {
	InterfaceManagerScript Interface;
	PigTransformManagerScript Trans;

	float Timer = 0;
	[System.NonSerialized] public int  Minute=1, Second=0, allTime=60;
	[System.NonSerialized] public bool clock = true, accountant = false;

	void Start () {
		Trans = GameObject.FindGameObjectWithTag ("PigTransformManager").GetComponent<PigTransformManagerScript> ();
		Interface = GameObject.FindGameObjectWithTag ("InterfaceManager").GetComponent<InterfaceManagerScript> ();

	}
	

	void FixedUpdate () {
		if (Interface.LifeTimeTrue && !Interface.PauseMenu && !Interface.StartGameTrue) {
			if (Timer <= 1)
				Timer += Time.fixedDeltaTime;
			else {
				
				Interface.LifeTimeNow --;
				TotalCounterManage.MyPlayingTimeSecondsCount++;
				TotalCounterManage.score = true;
				TotalCounterManage.Upgrade++;
				if (Interface.LifeTimeNow <= 0) {
					Trans.Dead = true;
					TotalCounterManage.MyScoreCount -= 60;
					TotalCounterManage.MyDeadCount++;
				}
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
