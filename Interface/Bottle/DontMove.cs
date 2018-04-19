using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontMove : MonoBehaviour {
	public float Timer = 0;
	IEnumerator Start () {
		gameObject.GetComponent<CircleCollider2D> ().radius = 12;
		yield return new WaitForSeconds (0.5f + (Timer/200));
		gameObject.GetComponent<CircleCollider2D> ().radius = 10;
		yield return new WaitForSeconds (0.5f + (Timer/200));
		gameObject.GetComponent<CircleCollider2D> ().radius = 9;
		//yield return new WaitForSeconds (0.5f + (Timer/200));
		//gameObject.GetComponent<CircleCollider2D> ().radius = 5;

	}
}
