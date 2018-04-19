using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandController : MonoBehaviour {

	float timer=.5f;
	IslandManage m;
	void Start(){
		m = GetComponent<IslandManage> ();
	}
	void FixedUpdate (){
		if (timer >= 0)
			timer -= Time.deltaTime;
		else {
			m.LeftChecker = transform.GetChild (0).gameObject.GetComponent<Transform> ().transform;
			m.RightChecker = transform.GetChild (transform.childCount - 1).gameObject.GetComponent<Transform> ().transform;
			m.ThisIslandActivate = true;
			m.TimeToDie = 1f;
			Destroy (this);
		}
	}
}
