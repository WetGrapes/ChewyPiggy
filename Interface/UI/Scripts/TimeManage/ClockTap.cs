using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Sprites;

public class ClockTap : MonoBehaviour {
	TimeManage Manage;

	void Start () {
		Manage = GameObject.FindGameObjectWithTag ("LifeTimeManager").GetComponent<TimeManage> ();
		#if UNITY_EDITOR
		if(Manage == null)
			Debug.Log ("AccountantTime - LifeTimeManager not found");
		#endif
		for (int i = 0; i < transform.childCount; i++)
			transform.GetChild (i).gameObject.SetActive (false);
	}
	void FixedUpdate () {

		ActTime  ( 60, 45, 0);
		ActTime  ( 45, 30, 1);
		ActTime  ( 30, 15, 2);
		ActTime  ( 15, 5, 3);
		ActTime  ( 5, 0, 4);
		if (Manage.Second < 5 && Manage.Minute == 0)
			GetComponent<SpriteRenderer> ().color = new Color (206f/255f,82f/255f,82f/255f,255f/255f);
		else
			GetComponent<SpriteRenderer> ().color = new Color (115f/255f,113f/255f,180f/255f,255f/255f);

	}

	void OnMouseUp()
	{
		Manage.accountant = true;
		Manage.clock = false;
	}


	void ActTime(int TimeS, int TimeN , int Num)
	{
		if (Manage.Second > TimeN && Manage.Second < TimeS) {
			for (int i = 0; i < transform.childCount; i++)
				transform.GetChild (i).gameObject.SetActive (false);
			transform.GetChild (Num).gameObject.SetActive (true);
		}
	}
}
