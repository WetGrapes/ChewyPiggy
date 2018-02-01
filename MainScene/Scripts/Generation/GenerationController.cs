using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Sprites;

public class GenerationController : MonoBehaviour {
	
	public bool Right = true , Precipices;
	[Range (0, 100)] public int ChanceOfObject = 45;
	public int XLvl=1;


	float RanX, RanY, timer;
	int RanList, RanParts;
	int GroundSet , DownSet, AmountSet, IslandNum;
	bool[] OnIsland = new bool[50];


	Vector3 Coordinate, ObjectCoordinate;
	ToolsForGeneration GenObs;
	SpriteRenderer GroundRenderer;
	ListOfLevels[] Datas ;
	public GameObject[] Island = new GameObject[6];


	void Start () {
		Island [2] = GameObject.Find ("Island");
		GenObs = GetComponent<ToolsForGeneration> ();
		Datas = GetComponent<ObsForGeneration> ().Datas;
		GroundRenderer = GenObs.Ground.GetComponent<SpriteRenderer> ();
	}


	void FixedUpdate()
	{
		if (Island [2].GetComponent<IslandManage> ().ThisIslandActivate == true) {
			if (Right == true) {
				
				CreateInTime (Island [2].GetComponent<IslandManage> ().RightChecker.position, 1, 1); 	//правый остров
				CreateInTime (Island [2].GetComponent<IslandManage> ().LeftChecker.position, 0, -1);	//левый остров

			} else {
				
				CreateInTime (Island [2].GetComponent<IslandManage> ().LeftChecker.position, 0, 1);	//левый остров
				CreateInTime (Island [2].GetComponent<IslandManage> ().RightChecker.position, 1, -1); 	//правый остров

			}
			Island [2].GetComponent<IslandManage> ().ThisIslandActivate = false;
		}
	}


	void IslandInstantiate() ///функция генерации острова
	{
		Island [IslandNum] = Instantiate (GenObs.Island, Coordinate, Quaternion.identity) as GameObject; // родитель остров
		CheckerInstantiate (1); //чекер
		// генерация нескольких сетов с перепадами высот
		for (AmountSet = Random.Range (3, Datas [0].Parts [RanParts].AmountSet); AmountSet >= 0; AmountSet--) {
			InstantiateUpDown (); // перепад высот
			FullGroundInstantiate (1 + Datas [0].Parts [RanParts].SetOfGround, 2);
		}
		CheckerInstantiate (2); //чекер

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
		
		Coordinate += new Vector3 (RanX, 2 * RanY, 4);
		CreateObject (0);
		InstantiateObs (GenObs.Ground, Coordinate);
		Coordinate -= new Vector3 (RanX, 2 * RanY, 4);
		CreateObject (1);
		DownGround ();
	}
		

	void InstantiateUpDown(){   ///функция генерации перепада высот

		int UpDownRanInit = Datas [0].Parts [RanParts].UpDownRandom;
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
		for (DownSet = 1 + Random.Range (1, Datas [0].Parts [RanParts].DownSet); DownSet != 0; DownSet--) 
		{
			Coordinate -= new Vector3 (0, GroundRenderer.sprite.bounds.size.y, 0);
			InstantiateObs (GenObs.Ground, Coordinate);
		}
		Coordinate = new Vector3 (Coordinate.x, YBeforeDownSet, 0);
	}
		

	void CreateObject(int up)    ///функция генерации объектов
	{
		if (Random.Range (0, 100) < ChanceOfObject) {
			int RanObs = Random.Range (0, Datas [0].Parts [RanParts].ObsList [RanList].Obs.Length);

			if (up == 1) {
				float RanZ = Random.Range ( 1f,  Datas [0].Parts [RanParts].ObsList [RanList].Obs[RanObs].Z+1);

				RanX = Random.Range (0.4f,  GroundRenderer.sprite.bounds.size.x - 0.4f);

				ObjectCoordinate = new Vector3 (Coordinate.x + RanX, Coordinate.y - (1.1f * GroundRenderer.sprite.bounds.size.y), RanZ);

				if (Datas [0].Parts [RanParts].ObsList [RanList].Obs [RanObs].OneOnIsland) {
					if (!OnIsland [RanObs]) 
					{
						InstantiateObs (Datas [0].Parts [RanParts].ObsList [RanList].Obs [RanObs].Obs, ObjectCoordinate);
						OnIsland [RanObs] = true;
					}
				} else
					InstantiateObs (Datas [0].Parts [RanParts].ObsList [RanList].Obs [RanObs].Obs, ObjectCoordinate);
				
			} else { 
				if (!Datas [0].Parts [RanParts].ObsList [RanList].Obs [RanObs].OneOnIsland) 
				{
					ObjectCoordinate = new Vector3 (Coordinate.x + (0.5f * GroundRenderer.sprite.bounds.size.x), 
						Coordinate.y - (0.3f * GroundRenderer.sprite.bounds.size.y), Coordinate.z+0.01f);
					
					InstantiateObs (Datas [0].Parts [RanParts].ObsList [RanList].Obs [RanObs].Obs, ObjectCoordinate);
				}
			}
			RanX = XLvl * GroundRenderer.sprite.bounds.size.x;
		}
	}
		

	void InstantiateObs(GameObject path, Vector3 coord){    ///функция создания и присваивания родителя
		GameObject Obs = Instantiate (path, coord, Quaternion.identity) as GameObject;

		Obs.transform.SetParent (Island [IslandNum].transform);

		if(Obs.GetComponent<EdgeChecker>())
			Obs.GetComponent<EdgeChecker> ().XLvl = XLvl;
	}


	void CheckerInstantiate(int num){ // функция создания чекера
		GameObject Obs;

		if (num == 1) {
			if (XLvl == 1) Obs = Instantiate (GenObs.LeftChecker, new Vector3 (Coordinate.x - 3 * XLvl, 
				Coordinate.y, Coordinate.z), Quaternion.identity) as GameObject;
			
			else Obs = Instantiate (GenObs.RightChecker, new Vector3 (Coordinate.x - 3 * XLvl, 
				Coordinate.y, Coordinate.z), Quaternion.identity) as GameObject;
			
		} else {
			if (XLvl == 1) Obs = Instantiate (GenObs.RightChecker, new Vector3 (Coordinate.x + 3 * XLvl, 
				Coordinate.y, Coordinate.z), Quaternion.identity) as GameObject;
			
			else Obs = Instantiate (GenObs.LeftChecker, new Vector3 (Coordinate.x + 3 * XLvl, 
				Coordinate.y, Coordinate.z), Quaternion.identity) as GameObject;
			
		}
		Obs.transform.SetParent (Island [IslandNum].transform);

		if(Obs.GetComponent<EdgeChecker>())
			Obs.GetComponent<EdgeChecker> ().XLvl = XLvl;

	}


	void CreateInTime(Vector3 Vect, int INum, int Rotate){
		RanParts = Random.Range (0, Datas [0].Parts.Length);		//выбираем случайную часть
		RanList = Random.Range (0, Datas [0].Parts [RanParts].ObsList.Length);	//Выбираем случайный лист с объектами

		Coordinate = Vect;
		Coordinate -= new Vector3 (5 * Rotate, 15, 0);

		XLvl = Rotate;
		IslandNum = INum;
		IslandInstantiate ();
	}
}