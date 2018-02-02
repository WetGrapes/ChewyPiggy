using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FenceLog : MonoBehaviour {

	public GameObject FenceParent; 
	public int numberOfFence;
	public int parentNumber;

	void Start () {
		parentNumber = gameObject.GetComponentInParent<Fence> ().number;
	}
	
	// Update is called once per frame
	void Update () {
		numberOfFence = FenceParent.GetComponentInParent<FenceView> ().NumberOfFence;
		switch (parentNumber) {
		case 0:
			if (numberOfFence > 2)
				gameObject.SetActive (false);
			break;
		case 1: 
			if (numberOfFence < 4)
				gameObject.SetActive (false);
			else
				gameObject.GetComponent<Transform> ().localScale = new Vector2 (2, 1);
			break;
		case 2: 
			if (numberOfFence != 3)
				gameObject.SetActive (false);
			else 
				gameObject.GetComponent<Transform> ().localScale = new Vector2 (1.75f, 1f);
			break;
		}
	}
}
