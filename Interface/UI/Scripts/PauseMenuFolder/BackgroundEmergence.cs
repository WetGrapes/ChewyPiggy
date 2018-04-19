using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundEmergence : MonoBehaviour {
	
	Color Col;
	Material BackShader;
	float timer, vect=1;
	Renderer rend;
	void Start () {
		

		Col = transform.GetComponent<SpriteRenderer> ().material.color;
	}
	

	void Update () {
		if (timer < 0) {
			vect *= -1;
			timer = 1f;
		} else {
			Col = transform.GetComponent<SpriteRenderer> ().material.color;
			Col.r += vect / -10 * Time.deltaTime * Random.Range(0f, 4f);
			Col.g += vect / 10 * Time.deltaTime * Random.Range(0f, 2f);
			Col.b += vect / 10 * Time.deltaTime * Random.Range(0f, 2f);
			//transform.GetComponent<SpriteRenderer> ().material;
			timer -= Time.deltaTime;
			transform.GetComponent<SpriteRenderer> ().material.color = Col;
			//Debug.Log (transform.GetComponent<SpriteRenderer> ().material.shader.maximumLOD);
		}

	}
}
