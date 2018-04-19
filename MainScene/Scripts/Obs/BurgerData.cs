using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurgerData : MonoBehaviour {
	GameObject TransformManager;
	InterfaceManagerScript InterfaceManager;
	Vector2 PigPos;
	void Start(){
		TransformManager = GameObject.FindGameObjectWithTag ("PigTransformManager");
		InterfaceManager = GameObject.FindGameObjectWithTag ("InterfaceManager").GetComponent<InterfaceManagerScript> ();
	}
	void FixedUpdate(){
		PigPos = TransformManager.GetComponent<PigTransformManagerScript> ().PigPos;
		if (Mathf.Abs (PigPos.x - transform.position.x) < 1.0f &&
			Mathf.Abs (PigPos.y - transform.position.y) < 1.0f ) {
			InterfaceManager.LifeTimeNow += 15;
			TotalCounterManage.MyEatenBurgerCount++;
			TotalCounterManage.MyScoreCount += 20;
			if (InterfaceManager.LifeTimeNow > 60)
				InterfaceManager.LifeTimeNow = 60;
			Destroy (transform.gameObject);
		}
	}
}
