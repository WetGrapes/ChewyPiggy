using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigTransformManagerScript : MonoBehaviour {
	InterfaceManagerScript Interface;

	public Transform MainPersonTransform;
	public float force;

	[System.NonSerialized] public Vector2 PigPos;
	[System.NonSerialized] public bool left, right, forceTrue, grounded, Dead,  downSight, TwoTaps , StartG;
	[System.NonSerialized] public float speed, rotate;

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
		if (StartG == false) {
			if (MainPersonTransform)
				PigPos = MainPersonTransform.position;
			if (speed <= 1f) {
				Interface.DownSightTrue = true;
			} else {
				Interface.DownSightTrue = false;
			}
		}
	}

	void FixedUpdate(){
		StartG = Interface.StartGameTrue;
		if (Dead) {
			Interface.GameOverTrue = Dead;
			Interface.LifeTimeTrue  = !Dead ;
		}
	}

	void LateUpdate(){
		if (StartG == false) {

			if (speed <= 1f) {
				Interface.DownSightCan = true;
			} else {			
				Interface.DownSightCan = false;
			}
		}
	}

}
