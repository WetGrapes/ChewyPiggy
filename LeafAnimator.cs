using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Sprites;

public class LeafAnimator : MonoBehaviour {

	Vector3 nowRotation, newRotation;
	Quaternion NowRot, NewRot;
	[SerializeField] float speedOfRotation = 2f;
	float randomSpeed, timer , colortimer = 0.5f;
	SpriteRenderer ren;


	void Start () {
		ren = GetComponent<SpriteRenderer> ();
	}
	

	void Update () {
		randomSpeed = Time.deltaTime * Random.Range (0.15f, 2f) * 0.5f;

		if (timer > 0) {
			
			transform.rotation = Quaternion.Slerp (NowRot, NewRot, speedOfRotation * randomSpeed);
			NowRot = transform.rotation;
			nowRotation = NowRot.eulerAngles;
			timer -= Time.deltaTime;

		} else {
			timer = .15f * speedOfRotation;
			newRotation = new Vector3 (Random.Range (-360f, 360f)/360f, Random.Range (-360f, 360f)/360f, Random.Range (-360f, 360f)/360f);
			NewRot = Quaternion.AngleAxis (180f, newRotation );
		}

		transform.position = new Vector2 (transform.position.x, transform.position.y - randomSpeed);
		if (colortimer > 0)
			colortimer -= Time.deltaTime;
		else {
			ren.color = new Color (ren.color.r, ren.color.g, ren.color.b, ren.color.a - randomSpeed);
			Destroy (gameObject, 1f);
		}

	}

}
