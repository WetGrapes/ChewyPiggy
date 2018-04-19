using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoverUp : MonoBehaviour {
	public GameObject Water;
	float rotate = 0, timer = 0;
	bool Kalabanga = false, boom = false, Banga = false;
	void FixedUpdate () {
		if ((transform.position.y - Water.transform.position.y) < 0.2f && (transform.position.x - Water.transform.position.x) < 0.8f && timer == 0) {
			timer = 1f;
			Water.GetComponent<CreateWater> ().speed = 0;
		}
		
		if (timer > 0)
			timer -= Time.deltaTime;
		else {
			if (timer < 0) {
				timer = 0;
				Kalabanga = true;
				boom = true;
				Water.GetComponent<CreateWater> ().speed = 0.042f;
			}
		}
			
		if (Kalabanga) {
			transform.Translate (Vector3.right * 10 * Time.deltaTime);
			if (rotate <= 20) {
				transform.localRotation = Quaternion.AngleAxis (rotate * 4, Vector3.back);
			}
			if (rotate >= 65) {
				rotate = 20;
				Kalabanga = false;
				Banga = true;
			}
			rotate +=2;
		}
		if (boom) {
			transform.Translate (Vector3.up *2);
			boom = false;
		}
		if (Banga) {
			rotate-=2;
			if (rotate <= 20) 
				transform.localRotation = Quaternion.AngleAxis (rotate * 4, Vector3.back);
			if (rotate <= 0)
				Banga = false;
			transform.Translate (Vector3.down * 2 * Time.deltaTime);
		}


			
		
	}
}
