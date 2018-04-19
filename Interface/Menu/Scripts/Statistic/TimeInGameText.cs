using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeInGameText : MonoBehaviour {

	[SerializeField]Text txt = null;



	void FixedUpdate () {
		txt.text = "Time in game \t\t\t" + TotalCounterManage.MyPlayingTimeSecondsCount.ToString ();
	}
}
