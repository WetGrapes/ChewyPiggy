using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterfaceManagerScript : MonoBehaviour {
	public GameObject CanvasOb;
	[System.NonSerialized] public bool CanvasObTrue;
	[Space]
	public GameObject DoubleJump;
	public int DoubleJumpQuantity;
	[System.NonSerialized] public bool DoubleJumpTrue;
	[Space]
	public GameObject LifeTime;
	public float LifeTimeNow;
	[System.NonSerialized] public bool LifeTimeTrue;
	[Space]
	public GameObject GameOver;
	[System.NonSerialized] public bool GameOverTrue;
	[Space]
	public GameObject DownSight;
	[System.NonSerialized] public bool DownSightTrue;
	[System.NonSerialized] public bool DownSightCan;
	[System.NonSerialized] public float DownSightTimer;



	void Start () {
		CanvasObTrue = true;
		CanvasOb.SetActive (CanvasObTrue);
		DoubleJumpTrue = true;
		DoubleJump.SetActive (DoubleJumpTrue);
		LifeTimeTrue = true;
		LifeTime.SetActive (LifeTimeTrue);
		GameOverTrue = false;
		GameOver.SetActive (GameOverTrue);
		DownSightTrue = false;
		DownSight.SetActive (DownSightTrue);
	}
	
	void Update(){
		DownSightAct ();
	}
	void FixedUpdate () {
		DoubleJump.SetActive (DoubleJumpTrue);
		LifeTime.SetActive (LifeTimeTrue);
		GameOver.SetActive (GameOverTrue);


	}
		



	void DownSightAct(){
		if (DownSightCan) {
			if (DownSightTimer >= 0)
				DownSightTimer -= Time.fixedDeltaTime;
			else
				DownSight.SetActive (DownSightTrue);
		} else {
			DownSightTimer = 1f;
		}
	}
}
