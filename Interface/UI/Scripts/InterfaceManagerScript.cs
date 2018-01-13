using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterfaceManagerScript : MonoBehaviour {
	public GameObject CanvasOb;
	public bool CanvasObTrue;
	public GameObject DoubleJump;
	public int DoubleJumpQuantity;
	public bool DoubleJumpTrue;
	public GameObject LifeTime;
	public float LifeTimeNow;
	public bool LifeTimeTrue;
	public GameObject GameOver;
	public bool GameOverTrue;

	// Use this for initialization
	void Start () {
		CanvasObTrue = true;
		CanvasOb.SetActive (CanvasObTrue);
		DoubleJumpTrue = true;
		DoubleJump.SetActive (DoubleJumpTrue);
		LifeTimeTrue = true;
		LifeTime.SetActive (LifeTimeTrue);
		GameOverTrue = false;
		GameOver.SetActive (GameOverTrue);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (DoubleJumpTrue) {
			DoubleJump.SetActive (DoubleJumpTrue);
			DoubleJumpTrue = false;
		}
		if (LifeTimeTrue) {
			LifeTime.SetActive (LifeTimeTrue);
			LifeTimeTrue = false;
		}
		if (GameOverTrue) {
			GameOver.SetActive (GameOverTrue);
			GameOverTrue = false;
		}

	}
}
