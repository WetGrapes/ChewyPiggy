using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeChecker : MonoBehaviour {
	PigTransformManagerScript Trans;
	GenerationController Generator;
	Vector2 PigPos;
	public int XLvl;
	public bool Right = false;
	float timer;
	bool act;

	void Start () {
		Trans = GameObject.FindGameObjectWithTag ("PigTransformManager").GetComponent<PigTransformManagerScript> ();
		Generator = GameObject.FindGameObjectWithTag ("GenerationManager").GetComponent<GenerationController> ();
	}
	

	void FixedUpdate () {
		if (act && Mathf.Abs (PigPos.y - transform.position.y) > 10f)
			timer -= Time.deltaTime;
		PigPos = Trans.GetComponent<PigTransformManagerScript> ().PigPos;
		if (transform.parent.gameObject == Generator.Island [2]) 
		if ((Mathf.Abs (PigPos.x - transform.position.x) < 1f) 
			|| (Mathf.Abs (PigPos.x - transform.position.x) < 4f) && PigPos.y - transform.position.y < -5f) {
				timer = 2f;
				act = true;
				Generator.Right = Right;
				TotalCounterManage.MyVisitedIslandCount++;
				NewMainIsland ();
			}
		if (timer<0){
			Destroy (transform.gameObject, 1);
		}
	}

	void NewMainIsland(){
		Generator.Island [3] = Generator.Island [2];

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

}
