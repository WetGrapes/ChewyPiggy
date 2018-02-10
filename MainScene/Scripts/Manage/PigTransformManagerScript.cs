using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigTransformManagerScript : MonoBehaviour {
	InterfaceManagerScript Interface;
	public Transform MainPersonTransform;
	public Vector2 PigPos;
	public bool Dead, left, right, forceTrue, grounded, downSight, TwoTaps;
	public float force, speed, rotate, timer;

	void Start () {
		if (MainPersonTransform)
			PigPos = MainPersonTransform.position;
		else 
			Debug.Log ("PigTransformManagerScript - MainPersonTransform not found");
		Dead = false;
		Interface = GameObject.FindGameObjectWithTag ("InterfaceManager").GetComponent<InterfaceManagerScript> ();
		if(Interface == null)
			Debug.Log ("PigTransformManagerScript - InterfaceManager not found");
	}


	void Update () {
		if (MainPersonTransform)
			PigPos = MainPersonTransform.position;
		if (speed <= 1f) {
			Interface.DownSightTrue = true;
		} else {
			Interface.DownSightTrue = false;
		}
	}
	void FixedUpdate(){
		if (Dead) {
			Interface.GameOverTrue = Dead;
			//Interface.LifeTime.SetActive (!Dead) ;
			//Interface.DoubleJump.SetActive (!Dead) ;
		}
	}
	void LateUpdate(){
		if (speed <= 1f) {
			Interface.DownSightCan = true;
		} else {			
			Interface.DownSightCan = false;
		}
	}

}
