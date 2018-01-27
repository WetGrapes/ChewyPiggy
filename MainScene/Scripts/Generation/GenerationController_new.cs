using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Sprites;

public class GenerationController_new : MonoBehaviour {

	public ListOfLevels[] Datas;
	ObsForGeneration GenObs;
	SpriteRenderer GroundRenderer;

	public bool Right, GenerationActive = true;
	bool[] OnIsland = new bool[50];

	GameObject[] Island = new GameObject[15];
	GameObject Obs;

	Vector3 Coordinate, ObjectCoordinate, LeftCoord, RightCoord, MaxCoord;

	float RanZ, RanX, RanY, YBeforeDownSet;
	int  RanObs, RanUpDown, LevelStage, RanList, RanParts, UpDownRanInit;
	int GroundSet , DownSet, AmountSet;
	int XLvl=1;


	void Start () {
		GenObs = GetComponent<ObsForGeneration> ();
		GroundRenderer = GenObs.Ground.GetComponent<SpriteRenderer> ();
		if (GenerationActive == true) {
			for (LevelStage = Datas [0].Parts.Length; LevelStage != 0; LevelStage--) {	//считываем список частей
				
				RanParts = Random.Range (0, Datas [0].Parts.Length);		//выбираем случайную часть
				RanList = Random.Range (0, Datas [0].Parts [RanParts].ObsList.Length);	//Выбираем случайный лист с объектами	

				Coordinate = new Vector3 (Coordinate.x, Coordinate.y, -5); // сдвигаем вперед
				Coordinate -= new Vector3 (0, 15, 0);

				LeftCoord = Coordinate;
				RightCoord = Coordinate;

				LeftCoord -= new Vector3 (Random.Range (0, 14), 0, 0);
				RightCoord += new Vector3 (Random.Range (0, 14), 0, 0);

				Coordinate = LeftCoord;
				XLvl = -1;
				IslandInstantiate ();
				Coordinate = RightCoord;
				XLvl = 1;
				IslandInstantiate ();
			}
			GenerationActive = false;
		}
	}
		

	void IslandInstantiate()
	{
		Island [0] = Instantiate (GenObs.Island, Coordinate, Quaternion.identity) as GameObject;

		/*if (XLvl == 1)
			InstantiateObs (GenObs.LeftChecker, Coordinate);
		else
			InstantiateObs (GenObs.RightChecker, Coordinate);*/

		for (AmountSet = Random.Range (3, Datas [0].Parts [RanParts].AmountSet); AmountSet >= 0; AmountSet--) {
			InstantiateUpDown ();
			FullGroundInstantiate (1 + Datas [0].Parts [RanParts].ObsList [RanList].SetOfGround, 2);
		}

		/*if (XLvl == 1)
			InstantiateObs (GenObs.RightChecker, MaxCoord);
		else
			InstantiateObs (GenObs.LeftChecker, MaxCoord);*/

		for (int i = OnIsland.Length - 1; i >= 0; i--)
			OnIsland [i] = false;
	}


	void FullGroundInstantiate (int SetOfGround, int ChanceOfPanel)
	{
		int Chance = Random.Range (0, ChanceOfPanel * 3);
		if (ChanceOfPanel != 0)
			RanY = GroundRenderer.sprite.bounds.size.y * Random.Range (2, 5);

		for (GroundSet = Random.Range (1, SetOfGround); GroundSet != 0; GroundSet--) {
			
			RanX = XLvl * GroundRenderer.sprite.bounds.size.x;
			Coordinate += new Vector3 (RanX, 0, 0);

			if ((Chance > ChanceOfPanel - (ChanceOfPanel / 2)) && ChanceOfPanel != 0) {
				if (Chance == ChanceOfPanel * 3 - 3)
					GroundSet = 1;
				else 
					InstaniatePlatformSet ();
			} else {
				IfMax ();
				CreateObject (1);
				DownGround ();
			}
		}
	}

	void InstaniatePlatformSet(){
		Coordinate += new Vector3 (RanX, 2 * RanY, 7);
		IfMax ();
		CreateObject (0);
		InstantiateObs (GenObs.Ground, Coordinate);
		Coordinate -= new Vector3 (RanX, 2 * RanY, 7);
		CreateObject (1);
		DownGround ();
	}

	void InstantiateUpDown(){

		UpDownRanInit = Datas [0].Parts [RanParts].ObsList [RanList].UpDownRandom;
		RanUpDown = Random.Range (-UpDownRanInit, UpDownRanInit + 1);		//берем сдвиг высот
		RanY = GroundRenderer.sprite.bounds.size.y * RanUpDown;		//превращаем в Y

		if (RanUpDown > 1) {
			for (; RanUpDown != 0; RanUpDown--) {
				Coordinate += new Vector3 (0, GroundRenderer.sprite.bounds.size.y, 0);
				FullGroundInstantiate (2, 0);
			}
		} else if (RanUpDown < -1) {
			for (; RanUpDown != 0; RanUpDown++) {
				Coordinate -= new Vector3 (0, GroundRenderer.sprite.bounds.size.y, 0);
				FullGroundInstantiate (2, 0);
			}
		} else 
			Coordinate += new Vector3 (0, RanY, 0);				//сдвигаем координаты
	}

	void DownGround()
	{
		YBeforeDownSet = Coordinate.y;
		
		for (DownSet = 1+Random.Range (1, Datas [0].Parts [RanParts].ObsList [RanList].DownSet)
			; DownSet != 0; DownSet--) {
			
			Coordinate -= new Vector3 (0, GroundRenderer.sprite.bounds.size.y, 0);
			InstantiateObs (GenObs.Ground, Coordinate);
		}
		Coordinate = new Vector3 (Coordinate.x, YBeforeDownSet, -5);
	}

	void CreateObject(int up)
	{
		if (Random.Range (0, 20) < 9) {

			RanObs = Random.Range (0, Datas [0].Parts [RanParts].ObsList [RanList].Obs.Length);
			RanZ = Random.Range ( 0,  4);
			RanX = Random.Range (0.4f,  GroundRenderer.sprite.bounds.size.x - 0.4f);

			if (up == 1) {
				ObjectCoordinate = new Vector3 (Coordinate.x + RanX, Coordinate.y - (1.1f * GroundRenderer.sprite.bounds.size.y), RanZ);
				if (Datas [0].Parts [RanParts].ObsList [RanList].Obs [RanObs].OneOnIsland) {
					if (!OnIsland [RanObs]) {
						InstantiateObs (Datas [0].Parts [RanParts].ObsList [RanList].Obs [RanObs].Obs, ObjectCoordinate);
						OnIsland [RanObs] = true;
					}
				} else
					InstantiateObs (Datas [0].Parts [RanParts].ObsList [RanList].Obs [RanObs].Obs, ObjectCoordinate);
			} else if( up == 0 ) { 
				if (!Datas [0].Parts [RanParts].ObsList [RanList].Obs [RanObs].OneOnIsland) {
					ObjectCoordinate = new Vector3 (Coordinate.x + (0.5f * GroundRenderer.sprite.bounds.size.x), 
						Coordinate.y - (0.3f * GroundRenderer.sprite.bounds.size.y), Coordinate.z);
					InstantiateObs (Datas [0].Parts [RanParts].ObsList [RanList].Obs [RanObs].Obs, ObjectCoordinate);
					Coordinate = new Vector3 (Coordinate.x, Coordinate.y, 2);
				}
			}
			RanX = XLvl * GroundRenderer.sprite.bounds.size.x;
		}
	}




	void IfMax()
	{
		if (MaxCoord.y < Coordinate.y)
			MaxCoord = Coordinate;
	}

	void InstantiateObs(GameObject path, Vector3 coord){
		Obs = Instantiate (path, coord, Quaternion.identity) as GameObject;
		Obs.transform.SetParent (Island [0].transform);
	}
}





