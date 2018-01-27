using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Sprites;

public class GenerationController : MonoBehaviour {
	public bool GenerationActive = true, Right, Precipices;
	bool[] OnIsland = new bool[50];

	Vector3 Coordinate, ObjectCoordinate, LeftCoord, RightCoord;

	float RanX, RanY;
	int RanList, RanParts;
	int GroundSet , DownSet, AmountSet;
	int XLvl=1;

	ToolsForGeneration GenObs;
	SpriteRenderer GroundRenderer;
	ListOfLevels[] Datas ;
	GameObject[] Island = new GameObject[15];

	void Start () {
		GenObs = GetComponent<ToolsForGeneration> ();
		Datas = GetComponent<ObsForGeneration> ().Datas;
		GroundRenderer = GenObs.Ground.GetComponent<SpriteRenderer> ();
		if (GenerationActive == true) {
			for (int LevelStage = Datas [0].Parts.Length; LevelStage != 0; LevelStage--) {	//считываем список частей

				RanParts = Random.Range (0, Datas [0].Parts.Length);		//выбираем случайную часть
				RanList = Random.Range (0, Datas [0].Parts [RanParts].ObsList.Length);	//Выбираем случайный лист с объектами	

				Coordinate = new Vector3 (Coordinate.x, Coordinate.y, -5); // сдвигаем вперед
				Coordinate -= new Vector3 (0, 20, 0);

				LeftCoord = Coordinate;		//левый остров
				RightCoord = Coordinate;	//правый остров

				LeftCoord -= new Vector3 (Random.Range (0, 14), 0, 0);
				RightCoord += new Vector3 (Random.Range (0, 14), 0, 0);

				Coordinate = LeftCoord;
				XLvl = -1;
				IslandInstantiate ();	//левый остров
				Coordinate = RightCoord;
				XLvl = 1;
				IslandInstantiate ();	//правый остров
			}
			GenerationActive = false;
		}
	}



	void IslandInstantiate() ///функция генерации острова
	{
		Island [0] = Instantiate (GenObs.Island, Coordinate, Quaternion.identity) as GameObject; // родитель остров

		if (XLvl == 1)  //чекер
			InstantiateObs (GenObs.LeftChecker, Coordinate);
		else
			InstantiateObs (GenObs.RightChecker, Coordinate);
		// генерация нескольких сетов с перепадами высот
		for (AmountSet = Random.Range (3, Datas [0].Parts [RanParts].AmountSet); AmountSet >= 0; AmountSet--) {
			InstantiateUpDown (); // перепад высот
			FullGroundInstantiate (1 + Datas [0].Parts [RanParts].ObsList [RanList].SetOfGround, 2);
		}

		if (XLvl == 1) //чекер
			InstantiateObs (GenObs.RightChecker, Coordinate);
		else
			InstantiateObs (GenObs.LeftChecker, Coordinate);

		for (var i = OnIsland.Length - 1; i >= 0; i--)  //зануление использованных данных после создания острова
			OnIsland [i] = false;
	}


	void FullGroundInstantiate (int SetOfGround, int ChanceOfPanel) ///функция генерации одного сета от острова
	{
		int Chance = Random.Range (0, ChanceOfPanel * 3);
		if (ChanceOfPanel != 0)
			RanY = GroundRenderer.sprite.bounds.size.y * Random.Range (2, 5);

		for (GroundSet = Random.Range (1, SetOfGround); GroundSet != 0; GroundSet--) {

			RanX = XLvl * GroundRenderer.sprite.bounds.size.x;
			Coordinate += new Vector3 (RanX, 0, 0);

			if ((Chance > ChanceOfPanel - (ChanceOfPanel / 2)) && ChanceOfPanel != 0) {
				if (Precipices) {
					if (Chance == ChanceOfPanel * 3 - 3)
						GroundSet = 1;
					else
						InstaniatePlatformSet (); 
				} else {
					InstaniatePlatformSet (); 
				}
			} else {
				CreateObject (1); 
				DownGround ();
			}
		}
	}


	void InstaniatePlatformSet(){     ///функция генерации летающих платформ
		Coordinate += new Vector3 (RanX, 2 * RanY, 7);
		CreateObject (0);
		InstantiateObs (GenObs.Ground, Coordinate);
		Coordinate -= new Vector3 (RanX, 2 * RanY, 7);
		CreateObject (1);
		DownGround ();
	}


	void InstantiateUpDown(){   ///функция генерации перепада высот

		int UpDownRanInit = Datas [0].Parts [RanParts].ObsList [RanList].UpDownRandom;
		int RanUpDown = Random.Range (-UpDownRanInit, UpDownRanInit + 1);		//берем сдвиг высот
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


	void DownGround()     ///функция генерации нижнего слоя земли
	{
		float YBeforeDownSet = Coordinate.y;

		for (DownSet = 1+Random.Range (1, Datas [0].Parts [RanParts].ObsList [RanList].DownSet)
			; DownSet != 0; DownSet--) {

			Coordinate -= new Vector3 (0, GroundRenderer.sprite.bounds.size.y, 0);
			InstantiateObs (GenObs.Ground, Coordinate);
		}
		Coordinate = new Vector3 (Coordinate.x, YBeforeDownSet, -5);
	}



	void CreateObject(int up)    ///функция генерации объектов
	{
		if (Random.Range (0, 20) < 9) {

			int RanObs = Random.Range (0, Datas [0].Parts [RanParts].ObsList [RanList].Obs.Length);
			float RanZ = Random.Range ( 0,  4);
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


	void InstantiateObs(GameObject path, Vector3 coord){    ///функция создания и присваивания родителя
		GameObject Obs = Instantiate (path, coord, Quaternion.identity) as GameObject;
		Obs.transform.SetParent (Island [0].transform);
	}
}