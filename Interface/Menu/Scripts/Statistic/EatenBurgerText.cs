using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EatenBurgerText : MonoBehaviour {

	[SerializeField]Text txt = null;



	void FixedUpdate () {
		txt.text = "Eaten burgers \t\t" + TotalCounterManage.MyEatenBurgerCount.ToString ();
	}
}
