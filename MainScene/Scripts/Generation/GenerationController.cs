using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Sprites;

public class GenerationController : MonoBehaviour {

	public ListOfLevels[] Datas;

	public GameObject Ground;
	public SpriteRenderer GroundRenderer;
	public bool Right, GenerationActive = true;

	GameObject[] GB = new GameObject[8000];
	GameObject[] Obs = new GameObject[500];
	[SerializeField] private GameObject[] EdgeChecher = new GameObject[6];

	Vector2 LimitValue,   PercentLimit;
	Vector3 Coordinate, LeftCoord, RightCoord, MaxCoord, ObjectCoordinate;

	int numOfEdgeChecker = 2;

	float RanZ, RanX, RanY, YBeforeDownSet;
	int  RanObs, RanUpDown, LevelStage, RanList, RanParts, UpDownRanInit;
	int NumOfObjects, NumOfGround;
	int GroundSet , DownSet, AmountSet;
	int XLvl=1, GBSetStep=0;
	int[] GBSet = new int[8], ObsSet = new int[8];
	float Timer = 2f;

	void Start () {

		if (GenerationActive == true) {
			for (LevelStage = Datas [0].Parts.Length; LevelStage != 0; LevelStage--) {	//считываем список частей
				
				RanParts = Random.Range (0, Datas [0].Parts.Length);		//выбираем случайную часть
				RanList = Random.Range (0, Datas [0].Parts [RanParts].ObsList.Length);	//Выбираем случайный лист с объектами	

				Coordinate = new Vector3 (Coordinate.x, Coordinate.y, -5); // сдвигаем вперед
				Coordinate -= new Vector3 (0, 25, 0);

				LeftCoord = Coordinate;
				RightCoord = Coordinate;

				LeftCoord -= new Vector3 (Random.Range (0, 10), 0, 0);
				RightCoord += new Vector3 (Random.Range (0, 10), 0, 0);

				Coordinate = LeftCoord;
				XLvl = -1;
				FullGroundInstantiate ();
				Coordinate = RightCoord;
				XLvl = 1;
				FullGroundInstantiate ();
				//Debug.Log ("Done!");
			}
			GenerationActive = false;
		}
	}

	/*void Update () {
		
		Timer -= Time.deltaTime;
		if (Timer < 0) {
			CreateInTime ();
			Timer = 2f;
		}


	}*/



	/*void CreateInTime()
	{
		
		Coordinate = new Vector3 (0, Coordinate.y, -5);
		Coordinate -= new Vector3 (0, LimitValue.y-5, 0);
		LeftCoord = new Vector3 (Random.Range(0, 10), Coordinate.y, 0);
		RightCoord = new Vector3 (Random.Range(0, 10), Coordinate.y, 0);

		RanParts = Random.Range(0, Datas [0].Parts.Length);		//выбираем случайную часть
		RanList = Random.Range(0, Datas [0].Parts [RanParts].ObsList.Length);	//Выбираем случайный лист с объектами				

		Coordinate = LeftCoord;
		XLvl = -1;
		FullGroundInstantiate ();

		RanParts = Random.Range(0, Datas [0].Parts.Length);		//выбираем случайную часть
		RanList = Random.Range(0, Datas [0].Parts [RanParts].ObsList.Length);	//Выбираем случайный лист с объектами				

		Coordinate = RightCoord;
		XLvl = 1;
		FullGroundInstantiate ();

		Coordinate-= new Vector3 (0, LimitValue.y-5, 0);
		FullGroundInstantiate ();



	}*/





	void FullGroundInstantiate()
	{
		if (XLvl == 1)
			EdgeChecher [numOfEdgeChecker++] = Instantiate (GameObject.Find ("LeftChecker"), Coordinate, Quaternion.identity) as GameObject;
		else
			EdgeChecher [numOfEdgeChecker++] = Instantiate (GameObject.Find ("RightChecker"), Coordinate, Quaternion.identity) as GameObject;


		for (AmountSet = 1 + Random.Range (1, Datas [0].Parts [RanParts].AmountSet); AmountSet >= 0; AmountSet--) {
			
			UpDownRanInit = Datas [0].Parts [RanParts].ObsList [RanList].UpDownRandom;
			RanUpDown = Random.Range (-UpDownRanInit, UpDownRanInit + 1);		//берем сдвиг высот
			RanY = GroundRenderer.sprite.bounds.size.y * RanUpDown;		//превращаем в Y

			if (RanUpDown > 1) {
				for (; RanUpDown != 0; RanUpDown--) {
					Coordinate += new Vector3 (0, GroundRenderer.sprite.bounds.size.y, 0);
					InstantiateGround (2, 0);
				}
			} else if (RanUpDown < -1) {
				for (; RanUpDown != 0; RanUpDown++) {
					Coordinate -= new Vector3 (0, GroundRenderer.sprite.bounds.size.y, 0);
					InstantiateGround (2, 0);
				}
			} else {
				Coordinate += new Vector3 (0, RanY, 0);				//сдвигаем координаты
			}	

			InstantiateGround (1 + Datas [0].Parts [RanParts].ObsList [RanList].SetOfGround, 2);
		}


		if (XLvl == 1)
			EdgeChecher [numOfEdgeChecker++] = Instantiate (GameObject.Find ("RightChecker"), MaxCoord, Quaternion.identity) as GameObject;
		else
			EdgeChecher [numOfEdgeChecker++] = Instantiate (GameObject.Find ("LeftChecker"), MaxCoord, Quaternion.identity) as GameObject;
	}


	void InstantiateGround(int SetOfGround, int ChanceOfPanel)
	{
		int Chance = Random.Range (0, ChanceOfPanel*3);
		if (ChanceOfPanel != 0) RanY = GroundRenderer.sprite.bounds.size.y * Random.Range (1, 5);


		for (GroundSet = Random.Range (1, SetOfGround); GroundSet != 0; GroundSet--) {
			if (NumOfGround < GB.Length ) 
			{
				RanX = XLvl*GroundRenderer.sprite.bounds.size.x;
				Coordinate += new Vector3 (RanX, 0, 0);

				if ((Chance > ChanceOfPanel - (ChanceOfPanel / 2)) && ChanceOfPanel != 0 
					&& NumOfGround + 1 < GB.Length && NumOfGround < LimitValue.x+LimitValue.y) {

					if (Chance == ChanceOfPanel * 3 - 3) {
						GroundSet = 1;

					} else {
						Coordinate += new Vector3 (RanX, 2*RanY, 0);
						IfMax ();
						CreateObject (0);
						instgr ();
						Coordinate -= new Vector3 (RanX, 2*RanY, 0);
						CreateObject (1);
						DownGround ();


					}
				} else {
					IfMax ();
					CreateObject (1);
					DownGround ();
				}
			
			}
		}
	}


	void DownGround()
	{
		YBeforeDownSet = Coordinate.y;

		for (DownSet = 1+Random.Range (1, Datas [0].Parts [RanParts].ObsList [RanList].DownSet)
			; DownSet != 0; DownSet--) {

			Coordinate -= new Vector3 (0, GroundRenderer.sprite.bounds.size.y, 0);
			instgr ();
		}

		Coordinate = new Vector3 (Coordinate.x, YBeforeDownSet, -5);

	}

	void IfMax()
	{
		if (MaxCoord.y < Coordinate.y) {
			MaxCoord = Coordinate;
		}
	}

	void CreateObject(int up)
	{
		
		if (Random.Range (0, 20) < 9) {
			
			RanObs = Random.Range (0, Datas [0].Parts [RanParts].ObsList [RanList].Obs.Length);
			RanZ = Random.Range ( 0,  4);
			RanX = Random.Range (0.4f,  GroundRenderer.sprite.bounds.size.x - 0.4f);

			if (up == 1)	ObjectCoordinate = new Vector3 (Coordinate.x + RanX, Coordinate.y - (1.1f*GroundRenderer.sprite.bounds.size.y), RanZ);
			else ObjectCoordinate = new Vector3 (Coordinate.x + RanX, Coordinate.y - (0.5f*GroundRenderer.sprite.bounds.size.y), RanZ);

			Obs [NumOfObjects] = Instantiate (Datas [0].Parts [RanParts].ObsList [RanList].Obs [RanObs].Obs, ObjectCoordinate, Quaternion.identity) as GameObject;
			NumOfObjects++;

			RanX = XLvl * GroundRenderer.sprite.bounds.size.x;
			RanZ = -5;
		}
	}

	void instgr(){
		GB [NumOfGround] = Instantiate (Ground, Coordinate, Quaternion.identity) as GameObject;
		if (NumOfGround + 1 < 8000)
			NumOfGround++;
		else NumOfGround = 0;
	}


}
