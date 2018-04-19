using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateWater : MonoBehaviour {

	public float Quan = 100;
	public GameObject Buble;
	public float speed = 0.042f;

	IEnumerator Start () {
		Quan = Quan*3.8f;
		yield return new WaitForSeconds (2f);
		for (float i = 0; i <= Quan; i+=4f) {
			yield return new WaitForSeconds (0.005f);
			Vector2 pos = new Vector2 (transform.position.x + Random.Range (-0.001f, 0.001f), transform.position.y);
			GameObject bub = Instantiate (Buble, pos, Quaternion.identity) as GameObject;
			bub.GetComponent<DontMove> ().Timer -= i*2;
			pos = new Vector2 (transform.position.x + Random.Range (-0.001f, 0.001f), transform.position.y);
			bub = Instantiate (Buble, pos, Quaternion.identity) as GameObject;
			bub.GetComponent<DontMove> ().Timer -= i*2;
			Vector3 GenPos = new Vector3 (transform.position.x, transform.position.y + speed, transform.position.z);
			transform.position = GenPos;
		}
	}

}
