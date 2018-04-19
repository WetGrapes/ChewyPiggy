using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VisitedIslandsText : MonoBehaviour {


	[SerializeField]Text txt = null;



	void FixedUpdate () {
		txt.text = "Visited islands \t\t" + TotalCounterManage.MyVisitedIslandCount.ToString ();
	}
}
