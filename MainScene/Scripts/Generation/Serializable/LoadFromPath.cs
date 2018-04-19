using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using UnityEngine;
using UnityEditor;

public class LoadFromPath : MonoBehaviour {
	[Header("Папки для загрузки")]
	[Space]
	public string[] paths = new string[3];
	[Space]
	[Header("Перечисление имен")]
	[Space]
	public Enemies Enemies;
	public Obs Obs;
	public Trees Trees;
	[Space]
	[Header("Объекты")]
	[Space]
	public GameObject[] EnemiesAd;
	[Space]
	public GameObject[] ObsAd;
	[Space]
	public GameObject[] TreesAd;


	[ContextMenu("Fill")]
	public void Fill()
	{
		var e1 = new AutoLoad.LoadClass ("Enemies");
		var e2 = new AutoLoad.LoadClass ("Obs");
		var e3 = new AutoLoad.LoadClass ("Trees");
		AutoLoad.LoadNameInFile (paths, e1, e2, e3);

	}


	[ContextMenu("Load")]
	public void Load()
	{
		EnemiesAd = new GameObject [ LenghtOfArray (paths [0])];
		for (int i = 0; i < EnemiesAd.Length; i++) {
			Enemies name = (Enemies)i;
			EnemiesAd [i] = GameObject.Find (name.ToString ());
		}

		ObsAd = new GameObject [ LenghtOfArray (paths [1])];
		for (int i = 0; i < ObsAd.Length; i++) {
			Obs name = (Obs)i;
			ObsAd [i] = GameObject.Find (name.ToString ());
		}

		TreesAd = new GameObject [ LenghtOfArray (paths [2])];
		for (int i = 0; i < TreesAd.Length; i++) {
			Trees name = (Trees)i;
			TreesAd [i] = GameObject.Find (name.ToString ());
		}
	}
		
	int LenghtOfArray (string path)
	{
		var di = new DirectoryInfo (Application.dataPath + "/ChewyPiggy/MainScene/Prefabs/Obs/" + path);
		FileInfo[] files = di.GetFiles ("*.prefab");
		return files.Length;
	}
}
