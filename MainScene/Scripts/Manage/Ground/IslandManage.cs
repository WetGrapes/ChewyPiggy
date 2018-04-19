using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandManage : MonoBehaviour {

	public Transform LeftChecker, RightChecker;
	public bool ThisIslandActivate, ReadyForSleep;
	public float TimeToDie;
	float timer = 1f;
	int sum;
	GenerationController Generator;

	void Start()
	{
		Generator = GameObject.FindGameObjectWithTag ("GenerationManager").GetComponent<GenerationController> ();
	}
	void FixedUpdate()
	{

		if (!ReadyForSleep) {
			if (timer >= 0)
				timer -= Time.fixedDeltaTime;
			else {
				for (int i = Generator.Island.Count - 1; i >= 0; i--)
					sum += transform.gameObject == Generator.Island [i] ? 1 : 0;
				if (sum == 0)
					ReadyForSleep = true;
				sum = 0;
			}
			
		} else {
			if (TimeToDie >= 0)
				TimeToDie -= Time.fixedDeltaTime;
			else {
				gameObject.SetActive (false);

				if (gameObject != null ) {
					Destroy (gameObject, 1);
					Destroy (this);
				}
			}
		}
	}
}
