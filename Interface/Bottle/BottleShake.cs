using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleShake : MonoBehaviour {

	public GameObject Water, Cover;
	public float rotate = 0, speed = 0;
	bool left = false, right = true;
	void FixedUpdate()
	{
		if (Mathf.Abs (Water.transform.position.y - Cover.transform.position.y) > 0.05f &&
		    Mathf.Abs (Water.transform.position.x - Cover.transform.position.x) < 1f) {
		
			if (left) {
				transform.localRotation = Quaternion.AngleAxis (rotate, Vector3.back);
				rotate += speed;
				if (rotate >= 1) { 
					left = false;
					right = true;
				}
			}
			if (right) {
				transform.localRotation = Quaternion.AngleAxis (rotate, Vector3.back);
				rotate -= speed;
				if (rotate <= -1) { 
					left = true;
					right = false;
				}
			}
			transform.localScale = new Vector3 (transform.localScale.x + 0.002f, transform.localScale.y - 0.0007f, transform.localScale.z);
		} else {
			if(transform.localScale.x>1)
				transform.localScale = new Vector3 (transform.localScale.x - 0.022f, transform.localScale.y + 0.001f, transform.localScale.z);
		}

	}

}
