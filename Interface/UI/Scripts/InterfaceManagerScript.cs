using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterfaceManagerScript : MonoBehaviour {
	public GameObject CanvasOb;
	[System.NonSerialized] public bool CanvasObTrue;
	[Space]


	[Header("Время")]
	[Space]
	public float LifeTimeNow;
	[System.NonSerialized] public bool LifeTimeTrue;
	[Space]
	public GameObject Clock;
	[System.NonSerialized] public bool ClockTrue;
	public GameObject Accountant;
	[System.NonSerialized] public bool AccountantTrue;
	[Space]


	[Header("Способности")]
	[Space]
	public GameObject Abilities;
	[System.NonSerialized] public bool AbilitiesTrue;
	[System.NonSerialized] public bool AbilitiesMenu;
	[Space]
	public GameObject DoubleJump;
	[System.NonSerialized] public bool DoubleJumpTrue;

	public GameObject SuperPig;
	[System.NonSerialized] public bool SuperPigTrue;

	public GameObject Snack;
	[System.NonSerialized] public bool SnackTrue;

	public GameObject Compass;
	[System.NonSerialized] public bool CompassTrue;
	[Space]


	[Header("Пауза")]
	[Space]
	public GameObject Pause;
	[System.NonSerialized] public bool PauseTrue;
	[System.NonSerialized] public bool PauseMenu;
	[Space]
	public GameObject Background;
	[System.NonSerialized] public bool BackgroundTrue;
	[Space]
	public GameObject RUN;
	[System.NonSerialized] public bool RUNTrue;

	public GameObject Relax;
	[System.NonSerialized] public bool RelaxTrue;
	[Space]


	[Header("Прочее")]
	[Space]
	public GameObject StartGame;
	[System.NonSerialized] public bool StartGameTrue;
	[Space]
	public GameObject GameOver;
	[System.NonSerialized] public bool GameOverTrue;
	[Space]
	public GameObject DownSight;
	[System.NonSerialized] public bool DownSightTrue;
	[System.NonSerialized] public bool DownSightActivate;
	[System.NonSerialized] public bool DownSightCan;
	[System.NonSerialized] public float DownSightTimer;



	void Start () {
		CanvasObTrue = true;

		LifeTimeTrue = false;
		ClockTrue = false;
		AccountantTrue = false;

		AbilitiesTrue = false;
		DoubleJumpTrue = false;
		SuperPigTrue = false;
		SnackTrue = false;
		CompassTrue = false;

		PauseTrue = false;
		RUNTrue = false;
		RelaxTrue = false;

		StartGameTrue = true;
		GameOverTrue = false;
		DownSightTrue = false;


		Act (ref DownSight, "DownSight",  DownSightTrue);
	}



	void Act(ref GameObject  Name, string nameOfObject, bool NameTrue) {
		if (Name != null)
			Name.gameObject.SetActive (NameTrue);
		/*#if UNITY_EDITOR
		else
			Debug.Log (nameOfObject + " not found");
		#endif*/
	}



	void Update(){
		DownSightAct ();
	}
	void FixedUpdate () {
		if (GameOverTrue == true)
			Die ();
		AllAct ();
	}






	void DownSightAct(){
		if (!StartGameTrue && DownSightCan) {
			if (DownSightTimer >= 0)
				DownSightTimer -= Time.fixedDeltaTime;
			else
				DownSightTrue = true;
		} else {
			DownSightTimer = 1f;
			DownSightTrue = false;
		}
	}

	void Die()
	{
		LifeTimeTrue = false;
		ClockTrue = false;
		AccountantTrue = false;

		AbilitiesTrue = false;
		DoubleJumpTrue = false;
		SuperPigTrue = false;
		SnackTrue = false;
		CompassTrue = false;

		PauseTrue = false;
		RUNTrue = false;
		RelaxTrue = false;

		StartGameTrue = false;
		DownSightTrue = false;
		DownSightTimer = 1f;
	}



	void AllAct(){
		Act (ref CanvasOb, "CanvasOb", CanvasObTrue);

		Act (ref Clock, "Clock",  ClockTrue);
		Act (ref Accountant, "Accountant",  AccountantTrue);

		Act (ref Abilities, "Abilities",  AbilitiesTrue);
		Act (ref DoubleJump, "DoubleJump",  DoubleJumpTrue);
		Act (ref SuperPig, "SuperPig",  SuperPigTrue);
		Act (ref Snack, "Snack",  SnackTrue);
		Act (ref Compass, "Compass",  CompassTrue);

		Act (ref Pause, "Pause",  PauseTrue);
		Act (ref RUN, "RUN",  RUNTrue);
		Act (ref Relax, "Relax",  RelaxTrue);

		Act (ref DownSight, "DownSight", DownSightTrue);
		Act (ref StartGame, "StartGame", StartGameTrue);
		Act (ref GameOver, "GameOver",  GameOverTrue);

	}
}
