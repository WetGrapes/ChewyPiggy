using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Sprites;

public class LeafAnimator : MonoBehaviour {

	/*Vector3 nowRotation, newRotation, differenceRotation;
	float speedOfRotation, randomSpeed;
	int signX, signY, signZ;


	void Start () {
		nowRotation = transform.rotation.eulerAngles;
		newRotation = new Vector3 (Random.Range (0f, 360f), Random.Range (0f, 360f), Random.Range (0f, 360f));
	}
	

	void Update () {
		differenceRotation = new Vector3 (
			Mathf.Abs ((nowRotation - newRotation).x), 
			Mathf.Abs ((nowRotation - newRotation).y),
			Mathf.Abs ((nowRotation - newRotation).z));
		signX = Mathf.Sign ((nowRotation - newRotation).x);
		signY = Mathf.Sign ((nowRotation - newRotation).y);
		signZ = Mathf.Sign ((nowRotation - newRotation).z);
		if (differenceRotation > 0.5f) {

		}




		differenceRotation = new Vector3 (
			Mathf.Abs ((nowRotation - newRotation).x)* Time.deltaTime, 
			Mathf.Abs ((nowRotation - newRotation).y)* Time.deltaTime,
			Mathf.Abs ((nowRotation - newRotation).z)* Time.deltaTime);
		transform.localRotation = Quaternion.Euler (differenceRotation.x, differenceRotation.y, differenceRotation.z);
	}
	void LateUpdate(){
		
		nowRotation = transform.rotation.eulerAngles;
		newRotation = new Vector3 (Random.Range (0f, 360f), Random.Range (0f, 360f), Random.Range (0f, 360f));
	}*/
}
