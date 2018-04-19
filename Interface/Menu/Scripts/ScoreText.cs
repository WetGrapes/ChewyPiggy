using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour {

	[SerializeField]Text txt = null;

	

	void FixedUpdate () {
		txt.text = TotalCounterManage.MyScoreCount.ToString ();
	}
}
