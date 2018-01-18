using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigTransformManagerScript : MonoBehaviour {
	InterfaceManagerScript Interface;
	public Transform MainPersonTransform;
	public Vector2 PigPos;
	public bool Dead,  left, right, forceTrue, grounded;
	public float force, speed, rotate;

	void Start () {
		if (MainPersonTransform)
			PigPos = MainPersonTransform.position;
		Dead = false;
		Interface = GameObject.FindGameObjectWithTag ("InterfaceManager").GetComponent<InterfaceManagerScript> ();
	}


	void Update () {
		if (MainPersonTransform)
			PigPos = MainPersonTransform.position;
		else 
			Debug.Log ("PigTransformManagerScript MainPersonTransform not found");
		
	}
	void FixedUpdate(){
		if (Dead) {
			Interface.GameOverTrue = Dead;
			Interface.LifeTime.SetActive (!Dead) ;
			Interface.DoubleJump.SetActive (!Dead) ;
		}
	}

}
