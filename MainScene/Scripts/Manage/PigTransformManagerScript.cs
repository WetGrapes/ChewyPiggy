using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigTransformManagerScript : MonoBehaviour {
	InterfaceManagerScript Interface;

	public Transform MainPersonTransform;
	public float force;

	[System.NonSerialized] public Vector2 PigPos;
	[System.NonSerialized] public bool left, right, forceTrue, grounded, Dead, TwoTaps;
	public bool InGame;
	[System.NonSerialized] public float speed, rotate;

	void Start () {
		if (MainPersonTransform)
			PigPos = MainPersonTransform.position;
		#if UNITY_EDITOR
		else 
			Debug.Log ("PigTransformManagerScript - MainPersonTransform not found");
		#endif
		
		Dead = false;

		Interface = GameObject.FindGameObjectWithTag ("InterfaceManager").GetComponent<InterfaceManagerScript> ();
		#if UNITY_EDITOR
		if(Interface == null)
			Debug.Log ("PigTransformManagerScript - InterfaceManager not found");
		#endif
	}


	void Update () {
		if (MainPersonTransform)
			PigPos = MainPersonTransform.position;
	
	}

	void FixedUpdate(){
		if (!Interface.GameOverTrue && !Interface.PauseMenu && !Interface.StartGameTrue)
			InGame = true;
		else
			InGame = false;

		
		if (Dead) {
			Interface.GameOverTrue = Dead;
			Interface.LifeTimeTrue  = !Dead ;
		}



	}

}
