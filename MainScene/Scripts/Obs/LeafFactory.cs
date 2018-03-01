using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafFactory : MonoBehaviour {

	[SerializeField] GameObject Leaf = new GameObject();
	float xRand, timer = 0f;
	
	void Start(){
		timer += Random.Range (0.1f, 2f);
	}

	void Update () {
		if (timer > 0) 
			timer -= Time.deltaTime;
		 else {
			xRand = Random.Range (-1f, 1);
			Instantiate (Leaf, new Vector3 (transform.position.x + xRand, transform.position.y, transform.position.z), 
				Quaternion.identity);
			timer = 0f + Random.Range (0.1f, 2f);
		}


	}
}
