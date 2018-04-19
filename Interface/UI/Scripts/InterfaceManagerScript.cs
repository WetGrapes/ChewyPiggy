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
	public GameObject Restart;
	[System.NonSerialized] public bool RestartTrue;
	[System.NonSerialized] public bool RestartActivated;


	void Start () {
		AllFalse ();

		StartGameTrue = true;
	}




	void FixedUpdate () {
		if (GameOverTrue)
			GameOverFunc ();
		if (RestartActivated)
			RestartFunc ();
		if (StartGameTrue)
			StartGameFunc ();
		
		AbilityMenuAct (AbilitiesMenu);
		PauseMenuAct (PauseMenu);

		AllAct ();
	}

	void Act(ref GameObject  Name, string nameOfObject, bool NameTrue) {
		if (Name != null)
			Name.gameObject.SetActive (NameTrue);
	}

	void StartGameFunc(){
		AllFalse ();
		StartGameTrue = true;
		LifeTimeNow = 60;
	}



	public void GameOverFunc()
	{
		AllFalse ();
		GameOverTrue = true;
		RestartTrue = true;
	}

	void RestartFunc(){
		AllFalse ();

	}

	void AbilityMenuAct(bool Active)
	{
		DoubleJumpTrue = Active;
		SuperPigTrue = Active;
		SnackTrue = Active;
		CompassTrue = Active;
	}
	void PauseMenuAct(bool Active)
	{
		BackgroundTrue = Active;
		RUNTrue = Active;
		RelaxTrue = Active;
	}

	void AllFalse()
	{
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
		BackgroundTrue = false;
		RUNTrue = false;
		RelaxTrue = false;

		StartGameTrue = false;
		GameOverTrue = false;
		RestartTrue = false;
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
		Act (ref Background, "Background",  BackgroundTrue);
		Act (ref RUN, "RUN",  RUNTrue);
		Act (ref Relax, "Relax",  RelaxTrue);

		Act (ref StartGame, "StartGame", StartGameTrue);
		Act (ref GameOver, "GameOver",  GameOverTrue);
		Act (ref Restart, "Restart", RestartTrue);
	}
}
