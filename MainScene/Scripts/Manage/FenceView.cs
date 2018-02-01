using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FenceView : MonoBehaviour {

	public int NumberOfFence;
	public bool[] broken;
	public bool[] withFlower;
	public bool[] withBird;
	public GameObject[] childs = new GameObject[4];

	void Start () {
		isOn ();
		withBird = new bool[NumberOfFence];
		broken = new bool[NumberOfFence];
		withFlower = new bool[NumberOfFence];
	}

	void isOn() {
		if (NumberOfFence == 3) {
			childs [3].SetActive (false);
		} else if (NumberOfFence == 2) {
			childs [3].SetActive (false);
			childs [2].SetActive (false);
		}
	}

	void autochange() {
		NumberOfFence = Random.Range (2, 5);
		if (NumberOfFence < 4) {
			switch (Random.Range(1,3)) {
			case 1:
				broken [Random.Range (1, 4)] = false; 

				break;
			case 2:
				break;
			}

		}

	}
}
