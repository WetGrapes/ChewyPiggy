using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeadsText : MonoBehaviour {


	[SerializeField]Text txt = null;



	void FixedUpdate () {
		txt.text = "Deads \t\t\t\t\t\t\t" + TotalCounterManage.MyDeadCount.ToString ();
	}
}
