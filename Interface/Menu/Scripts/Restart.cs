using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restart : MonoBehaviour {
	GenerationController Generator;
	PigTransformManagerScript Trans;
	InterfaceManagerScript Interface;
	GameObject Island;
	Transform CamTransform;


	public GameObject mainIsland;
	bool act = false;
	int XLvl;


	void Start () {
		Generator = GameObject.FindGameObjectWithTag ("GenerationManager").GetComponent<GenerationController> ();
		Trans = GameObject.FindGameObjectWithTag ("PigTransformManager").GetComponent<PigTransformManagerScript> ();
		Interface = GameObject.FindGameObjectWithTag ("InterfaceManager").GetComponent<InterfaceManagerScript> ();
		CamTransform = GameObject.FindGameObjectWithTag ("Camera").transform;

		StartCoroutine(InstIsland (1));
	}

	void Update () {
		if (Trans.Dead && Interface.RestartActivated) {
			if (!act)
				StartCoroutine (Rest (0.1f));
			Trans.Dead = false;
		}
	}


	IEnumerator InstIsland(int timer){
		yield return new WaitForSeconds (timer);
		Island = Generator.Island [2];
		mainIsland = Instantiate (Island, new Vector3 (0, 200, 0), Quaternion.identity) as GameObject;	
		mainIsland.SetActive (false);
	}



	IEnumerator Rest(float timer){
		act = true;
		yield return new WaitForSeconds (timer);
		for (int i = 0; i < Generator.Island.Count; Generator.Island [i++] = null)
			Destroy(Generator.Island [i], 0.1f);
		Generator.Island [2] = Instantiate (mainIsland, new Vector3 (0, 0, 0), Quaternion.identity) as GameObject;
		Generator.Right = true;
		Generator.Island [2].SetActive (true);
		Trans.MainPersonTransform.position = new Vector2 (3, 7);
		CamTransform.position = new Vector3 (3, 7, CamTransform.position.z);
		Generator.Island [2].GetComponent<IslandManage> ().ThisIslandActivate = true;
		act = false;
		Interface.RestartActivated = false;
		Interface.StartGameTrue = true;
	}
}
