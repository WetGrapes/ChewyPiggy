using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AccountantTime : MonoBehaviour {
	TimeManage Manage;
	[SerializeField]Text txt = null;

	string Zero = "0" , Zero2 ;

	void Start () {
		Manage = GameObject.FindGameObjectWithTag ("LifeTimeManager").GetComponent<TimeManage> ();
		#if UNITY_EDITOR
		if(Manage == null)
			Debug.Log ("AccountantTime - LifeTimeManager not found");
		#endif
	}

	void FixedUpdate () {
		

		if (Manage.Second == 0) Zero2 = "0";
		else Zero2 = "";
		txt.text = Zero + Manage.Minute.ToString () + "." + Manage.Second.ToString () + Zero2;
	}


	void OnMouseUp()
	{
		Manage.accountant = false;
		Manage.clock = true;
	}

}
