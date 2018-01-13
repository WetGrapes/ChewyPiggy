using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Founder : MonoBehaviour {
	public bool coal;
	public int[] foundGround = new int[4];
	float timer = 0.5f;

	void Start () {

	}

	void Update () {
		if (timer >= 0) {
			float Xsize, Ysize;
			Xsize = GetComponent<SpriteRenderer> ().sprite.bounds.size.x;
			Ysize = GetComponent<SpriteRenderer> ().sprite.bounds.size.y;
			Ray2D ray = new Ray2D (new Vector2 (transform.position.x + 0.5f * Xsize, transform.position.y + 0.1f * Ysize), new Vector2 (0, 0.1f));
			RaycastHit2D hit010 = Physics2D.Raycast (ray.origin, ray.direction, 0.5f);
			ray = new Ray2D (new Vector2 (transform.position.x - 0.1f * Xsize, transform.position.y - 0.5f * Ysize), new Vector2 (-0.1f, 0));
			RaycastHit2D hit200 = Physics2D.Raycast (ray.origin, ray.direction, 0.5f);
			ray = new Ray2D (new Vector2 (transform.position.x + 1.1f * Xsize, transform.position.y - 0.5f * Ysize), new Vector2 (0.1f, 0));
			RaycastHit2D hit002 = Physics2D.Raycast (ray.origin, ray.direction, 0.5f);
			ray = new Ray2D (new Vector2 (transform.position.x + 0.5f * Xsize, transform.position.y - 1.1f * Ysize), new Vector2 (0, -0.1f));
			RaycastHit2D hit030 = Physics2D.Raycast (ray.origin, ray.direction, 0.5f);

			if (hit010.collider != null) {
				//Debug.Log ("hit010.collider.tag " + hit010.collider.name);

				if (hit010.collider.tag == "Ground") {
					foundGround [0] = 1;
				} else
					foundGround [0] = 0;
			} else
				foundGround [0] = 0;
		
			if (hit200.collider != null) {
				//Debug.Log ("hit200.collider.tag " + hit200.collider.name);
				if (hit200.collider.tag == "Ground")
					foundGround [1] = 1;
				else
					foundGround [1] = 0;
			} else
				foundGround [1] = 0;
		
			if (hit002.collider != null) {
				//Debug.Log ("hit002.collider.tag " + hit002.collider.name);
				if (hit002.collider.tag == "Ground")
					foundGround [2] = 1;
				else
					foundGround [2] = 0;
			} else
				foundGround [2] = 0;
		
			if (hit030.collider != null) {
				//Debug.Log ("hit030.collider.tag " + hit030.collider.name);
				if (hit030.collider.tag == "Ground")
					foundGround [3] = 1;
				else
					foundGround [3] = 0;
			} else
				foundGround [3] = 0;

			timer -= Time.deltaTime;
		} else
			Destroy (this);
	}

}
