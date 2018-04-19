using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Sprites;

public class Not_GenerationController : MonoBehaviour {
	
	public bool Right = true ; 
	public bool Precipices;
	[Range (0, 100)] public int ChanceOfObject = 45;
	[System.NonSerialized] public int XLvl=1;

	int RanParts, IslandNum, ThisSet, ToEnd;
	bool[] OnIslandEnemies = new bool[8];
	bool[] OnIslandObs = new bool[8];
	bool OnIslandBurger = false;

	Vector3 Coordinate;
	ToolsForGeneration GenObs;
	SpriteRenderer GroundRenderer;
	ListOfLevels[] Datas ;
	GameObject[] EnemiesGen, ObsGen, TreesGen;

	public List<GameObject> Island = new List<GameObject> ();

	void Start () {
		Island [2] = GameObject.Find ("Island");
		GenObs = GetComponent<ToolsForGeneration> ();
		Datas = GetComponent<ObsForGeneration> ().Datas;
		EnemiesGen = GetComponent<LoadFromPath> ().EnemiesAd;
		ObsGen = GetComponent<LoadFromPath> ().ObsAd;
		TreesGen = GetComponent<LoadFromPath> ().TreesAd;
		GroundRenderer = GenObs.Ground.GetComponent<SpriteRenderer> ();
	}


	void FixedUpdate()
	{
		if (Island [2].GetComponent<IslandManage> ().ThisIslandActivate == true) {
			if (Right == true) 
			{
				CreateInTime (Island [2].GetComponent<IslandManage> ().RightChecker.position, 1, 1); 	//правый остров
				CreateInTime (Island [2].GetComponent<IslandManage> ().LeftChecker.position, 0, -1);	//левый остров
			} 
			else 
			{
				CreateInTime (Island [2].GetComponent<IslandManage> ().LeftChecker.position, 0, 1);	//левый остров
				CreateInTime (Island [2].GetComponent<IslandManage> ().RightChecker.position, 1, -1); 	//правый остров
			}
			Island [2].GetComponent<IslandManage> ().ThisIslandActivate = false;
		}
	}


	void IslandInstantiate() ///функция генерации острова
	{
		Island.RemoveAt (IslandNum);
		Island.Insert (IslandNum, Instantiate (GenObs.Island, Coordinate, Quaternion.identity) as GameObject); // родитель остров

		CheckerInstantiate (1); //чекер
		for (int i = 0; i < GenObs.IslandObs.Length; i++)
			IslandInfro (GenObs.IslandObs [i], Coordinate);
		// генерация нескольких сетов с перепадами высот
		for (int AmountSet = Random.Range (3, Datas [0].Parts [RanParts].AmountSet); AmountSet >= 0; AmountSet--) {
			InstantiateUpDown (); // перепад высот
			FullGroundInstantiate (1 + Datas [0].Parts [RanParts].SetOfGround, 2, GroundRenderer.sprite.bounds.size.y * Random.Range (2, 5));
		}
		CheckerInstantiate (2); //чекер

		for (var i = OnIslandEnemies.Length - 1; i >= 0; i--)  //зануление использованных данных после создания острова
			OnIslandEnemies [i] = false;
		for (var i = OnIslandObs.Length - 1; i >= 0; i--)  //зануление использованных данных после создания острова
			OnIslandObs [i] = false;
		OnIslandBurger = false;
	}
		

	void FullGroundInstantiate (int SetOfGround, int ChanceOfPanel, float RanY) ///функция генерации одного сета от острова
	{
		int Chance = Random.Range (0, ChanceOfPanel * 3);

		ThisSet = Random.Range (SetOfGround-3, SetOfGround);

		for (int GroundSet = ThisSet; GroundSet != 0; GroundSet--) 
		{
			float RanX = XLvl * GroundRenderer.sprite.bounds.size.x;

			Coordinate += new Vector3 (RanX, 0, 0);
			ToEnd = GroundSet;

			if ((Chance > ChanceOfPanel - (ChanceOfPanel / 2)) && ChanceOfPanel != 0) 
			{
				if (Precipices) 
				{
					if (Chance == ChanceOfPanel * 3 - 3)
						GroundSet = 1;
					else
						InstaniatePlatformSet (RanY);
				} 
				else
					InstaniatePlatformSet (RanY);
			} 
			else 
			{
				CreateObject (1); 
				DownGround ();
			}
		}
	}
		

	void InstaniatePlatformSet(float RanY){     ///функция генерации летающих платформ
		float RanX = XLvl * GroundRenderer.sprite.bounds.size.x;

		Coordinate += new Vector3 (RanX, 2 * RanY, 4);
		CreateObject (0);
		InstantiateObs ( GenObs.Ground, 3, Coordinate);

		ToEnd--;
		Coordinate -= new Vector3 (RanX, 2 * RanY, 4);

		CreateObject (1);
		DownGround ();
	}
		

	void InstantiateUpDown(){   ///функция генерации перепада высот

		int UpDownRanInit = Datas [0].Parts [RanParts].UpDownRandom;
		int RanUpDown = Random.Range (-UpDownRanInit, UpDownRanInit + 1);		//берем сдвиг высот
		float RanY = GroundRenderer.sprite.bounds.size.y * RanUpDown;		//превращаем в Y

		if (RanUpDown > 1) 
		{
			for (; RanUpDown != 0; RanUpDown++) {
				Coordinate += new Vector3 (0, GroundRenderer.sprite.bounds.size.y, 0);
				FullGroundInstantiate (2, 0, 0);
			}
		} 
		else if (RanUpDown < -1) 
		{
			for (; RanUpDown != 0; RanUpDown++) {
				Coordinate -= new Vector3 (0, GroundRenderer.sprite.bounds.size.y, 0);
				FullGroundInstantiate (2, 0, 0);
			}
		} 
		else 
			Coordinate += new Vector3 (0, RanY, 0);				//сдвигаем координаты
	}
		

	void DownGround()     ///функция генерации нижнего слоя земли
	{
		float YBeforeDownSet = Coordinate.y;

		for (int DownSet = 1 + Random.Range (Datas [0].Parts [RanParts].DownSet-3, Datas [0].Parts [RanParts].DownSet); DownSet != 0; DownSet--) 
		{
			Coordinate -= new Vector3 (0, GroundRenderer.sprite.bounds.size.y, 0);
			InstantiateObs ( GenObs.Ground, 3, Coordinate);
		}

		Coordinate = new Vector3 (Coordinate.x, YBeforeDownSet, 0);
	}
		

	void CreateObject(int up)    ///функция генерации объектов
	{
		if (Random.Range (0, 100) < ChanceOfObject) {
			
			int RanList = Random.Range (0, Datas [0].Parts [RanParts].ObsList.Length);
			int RanObject = Random.Range (0, 3);



			Vector3 ObjectCoordinate;
			int RanPick;
			if (up == 1) {
				
				float RanZ = Random.Range ( 1f,  8f);
				float RanX = Random.Range (0.4f,  GroundRenderer.sprite.bounds.size.x - 0.4f);
				ObjectCoordinate = new Vector3 (Coordinate.x + RanX, Coordinate.y - (1.1f * GroundRenderer.sprite.bounds.size.y), RanZ);

				switch (RanObject) {
				case 0: //Enemies
					RanPick = Random.Range (0, Datas [0].Parts [RanParts].ObsList [RanList].Enemies.Length);
					if (!OnIslandEnemies [RanPick] && ThisSet > 4 && Random.Range ( 0,  5) == 3) {
						InstantiateObs (EnemiesGen [Datas [0].Parts [RanParts].ObsList [RanList].Enemies [RanPick].Obs], 2, ObjectCoordinate);
						OnIslandEnemies [RanPick] = Datas [0].Parts [RanParts].ObsList [RanList].Enemies [RanPick].OneOnIsland;
					} 
					break;
				case 1: //Obs
					RanPick = Random.Range (0, Datas [0].Parts [RanParts].ObsList [RanList].Obs.Length);

					int anotherSet;
					anotherSet = Datas [0].Parts [RanParts].ObsList [RanList].Obs [RanPick].Size;

					if (!OnIslandObs [RanPick] && ThisSet > anotherSet && 
						ToEnd > Datas [0].Parts [RanParts].ObsList [RanList].Obs [RanPick].Size
						&& Random.Range ( 0,  4) == 3) 
					{
						InstantiateObs (ObsGen[Datas [0].Parts [RanParts].ObsList [RanList].Obs [RanPick].Obs], 4, ObjectCoordinate);
						OnIslandObs [RanPick] = Datas [0].Parts [RanParts].ObsList [RanList].Obs [RanPick].OneOnIsland;
					}
					break;
				case 2: //Trees
					RanPick = Random.Range (0, Datas [0].Parts [RanParts].ObsList [RanList].Trees.Length);
					InstantiateObs (TreesGen[Datas [0].Parts [RanParts].ObsList [RanList].Trees[RanPick].Obs], 5, ObjectCoordinate);
					break;
				}

				int rand = Random.Range (0, 1000);
				if (OnIslandBurger == false && rand >=  650  && rand <= 670) {
					ObjectCoordinate = new Vector3 (Coordinate.x + RanX, Coordinate.y - (1.1f * GroundRenderer.sprite.bounds.size.y), RanZ);
					InstantiateObs (GenObs.Burger, 1, ObjectCoordinate);
					OnIslandBurger = true;
				}



				if (Random.Range (0, 100) > 75) {
					ObjectCoordinate = new Vector3 (Coordinate.x + RanX, Coordinate.y - (1.1f * GroundRenderer.sprite.bounds.size.y), RanZ);
					InstantiateObs (GenObs.Grass, 4, ObjectCoordinate);
				}


			} else { 
				if (RanObject == 2) 
				{
					ObjectCoordinate = new Vector3 (Coordinate.x + (0.5f * GroundRenderer.sprite.bounds.size.x), 
						Coordinate.y - (0.3f * GroundRenderer.sprite.bounds.size.y), Coordinate.z+0.01f);
					RanPick = Random.Range (0, Datas [0].Parts [RanParts].ObsList [RanList].Trees.Length);
					InstantiateObs (TreesGen[Datas [0].Parts [RanParts].ObsList [RanList].Trees [RanPick].Obs], 5, ObjectCoordinate);
				}
			}
		}
	}



	void InstantiateObs(GameObject path, int numOfChild, Vector3 coord){    ///функция создания и присваивания родителя


		GameObject Obs = Instantiate (path, coord, Quaternion.identity) as GameObject;
		Obs.transform.SetParent (Island [IslandNum].transform.GetChild(numOfChild).transform);

		if(Obs.GetComponent<EdgeChecker>())
			Obs.GetComponent<EdgeChecker> ().XLvl = XLvl;
	}



	void CheckerInstantiate(int num){ // функция создания чекера
		
		GameObject Obs;

		if (num == 1) 
		{
			if (XLvl == 1) Obs = Instantiate (GenObs.LeftChecker, new Vector3 (Coordinate.x - 1.5f * XLvl, 
				Coordinate.y, Coordinate.z), Quaternion.identity) as GameObject;
			
			else Obs = Instantiate (GenObs.RightChecker, new Vector3 (Coordinate.x - 1.5f * XLvl, 
				Coordinate.y, Coordinate.z), Quaternion.identity) as GameObject;
			
		} 
		else 
		{
			if (XLvl == 1) Obs = Instantiate (GenObs.RightChecker, new Vector3 (Coordinate.x + 1.5f * XLvl, 
				Coordinate.y, Coordinate.z), Quaternion.identity) as GameObject;
			
			else Obs = Instantiate (GenObs.LeftChecker, new Vector3 (Coordinate.x + 1.5f * XLvl, 
				Coordinate.y, Coordinate.z), Quaternion.identity) as GameObject;
			
		}

		Obs.transform.SetParent (Island [IslandNum].gameObject.transform);

		if(Obs.GetComponent<EdgeChecker>())
			Obs.GetComponent<EdgeChecker> ().XLvl = XLvl;

	}
		
	void CreateInTime(Vector3 Vect, int INum, int Rotate){
		
		RanParts = Random.Range (0, Datas [0].Parts.Length);		//выбираем случайную часть

		Coordinate = Vect;
		Coordinate -= new Vector3 (5 * Rotate, 20, 0);

		XLvl = Rotate;
		IslandNum = INum;
		IslandInstantiate ();
	}







	void IslandInfro(GameObject path, Vector3 coord)
	{
		GameObject Obs = Instantiate (path, coord, Quaternion.identity) as GameObject;

		Obs.transform.SetParent (Island [IslandNum].transform);

		if(Obs.GetComponent<EdgeChecker>())
			Obs.GetComponent<EdgeChecker> ().XLvl = XLvl;
	}



}