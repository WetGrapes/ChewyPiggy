using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeChecker : MonoBehaviour {
	PigTransformManagerScript Trans;
	GenerationController Generator;
	Vector2 PigPos;
	public int XLvl;
	[SerializeField] private bool Right;
	float timer;
	bool act;

	void Start () {
		Trans = GameObject.FindGameObjectWithTag ("PigTransformManager").GetComponent<PigTransformManagerScript> ();
		Generator = GameObject.FindGameObjectWithTag ("GenerationManager").GetComponent<GenerationController> ();
	}
	

	void FixedUpdate () {
		if (act)
			timer -= Time.deltaTime;
		PigPos = Trans.GetComponent<PigTransformManagerScript> ().PigPos;
		if (transform.parent.gameObject == Generator.Island [2]) {
			if (Mathf.Abs (PigPos.x - transform.position.x) < .5f) {
				timer = 2f;
				act = true;
			}
			if (timer<0){
				Generator.Right = Right;
				NewMainIsland ();
				UnActIslands ();
				Destroy (transform.gameObject);
			}
		}
	}

	void NewMainIsland(){
		Generator.Island [5] = Generator.Island [2];
		Generator.Island [4] = Generator.Island [1];
		Generator.Island [3] = Generator.Island [0];

		if (XLvl == 1) {
			if (Right == true)
				Generator.Island [2] = Generator.Island [1];
			else
				Generator.Island [2] = Generator.Island [0];
		} else {
			Generator.XLvl = 1;
			if (Right == true)
				Generator.Island [2] = Generator.Island [0];
			else
				Generator.Island [2] = Generator.Island [1];	
		}
	}

	void UnActIslands()
	{
		GameObject[] delete = new GameObject[3];

		if (Generator.Island [2] != Generator.Island [3]) {
			delete [0] = Generator.Island [3];
			Generator.Island [3] = GameObject.FindGameObjectWithTag ("GenerationManager");
			delete [0].SetActive (false);
		} else
			Generator.Island [3] = GameObject.FindGameObjectWithTag ("GenerationManager");
		if (Generator.Island [2] != Generator.Island [4]) {
			delete [1] = Generator.Island [4];
			Generator.Island [4] = GameObject.FindGameObjectWithTag ("GenerationManager");
			delete [1].SetActive (false);
		} else
			Generator.Island [4] = GameObject.FindGameObjectWithTag ("GenerationManager");

		delete [2] = Generator.Island [5];
		Generator.Island [5] = GameObject.FindGameObjectWithTag ("GenerationManager");
		delete [2].SetActive (false);
	}
}
