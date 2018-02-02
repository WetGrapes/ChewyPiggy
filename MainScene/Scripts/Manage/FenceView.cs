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
		NumberOfFence = Random.Range (2, 5);
		isOn ();
		withBird = new bool[NumberOfFence];
		broken = new bool[NumberOfFence];
		withFlower = new bool[NumberOfFence];
		autochange ();
	}

	void isOn() {
		if (NumberOfFence == 3) {
			childs [3].SetActive (false);
		} else if (NumberOfFence == 2) {
			childs [3].SetActive (false);
			childs [2].SetActive (false);
		}
	}
	void autochange()   {
		int a;
		int b;

		if (NumberOfFence < 4)
		{
			a = Random.Range (0, NumberOfFence-1);
			typeSwitch (a);
		} 
		else {
			switch(Random.Range(1, 4)){
			case 1:
				a = Random.Range (0, 4);
				broken [a] = true; 
				b = Random.Range (0, 4);
				changeCon (a, b);
				break;
			case 2:
				a = Random.Range (0, 4);
				withBird [a] = true; 
				b = Random.Range (0, 4);
				changeCon (a, b);
				break;
			case 3: 
				a = Random.Range (0, 4);
				withFlower [a] = true; 
				b = Random.Range (0, 4);
				changeCon (a, b);
				break;
			}}
	    }
	void typeSwitch(int a) {
		 switch (Random.Range (1, 4)) {
		case 1:
			broken [a] = true; 
			break;
		case 2:
			withBird [a] = true; 
			break;
		case 3: 
			withFlower [a] = true; 
			break;
		}
	}
	void changeCon(int a, int b) {
		if (b == a && b == 0) {
			typeSwitch (2);
		} else if (b == a && b == 3) {
			typeSwitch (1);
		} else if (b == a && b == 1) {
			typeSwitch (3);
		} else if (b == a && b == 2) {
			typeSwitch (0);
		} else typeSwitch (b);
	}
}
 