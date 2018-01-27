using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigTransform : MonoBehaviour {
	PigTransformManagerScript Trans;
	Rigidbody2D Body;
	float Xsize, Xvect;
	Ray2D ray;
	[SerializeField] private GameObject Checker;
	[SerializeField] private LayerMask isGround;
	void Start () {
		Trans = GameObject.FindGameObjectWithTag ("PigTransformManager").GetComponent<PigTransformManagerScript> ();
		Body = GetComponent<Rigidbody2D> ();

		Xsize = 1;//GetComponent<SpriteRenderer> ().sprite.bounds.size.x;
	//	Ysize = 1;//GetComponent<SpriteRenderer> ().sprite.bounds.size.y;
	}
	void Update () {
		if (Trans != null) {
			
			transform.localRotation = Quaternion.AngleAxis (Trans.rotate, Vector3.up);
		
			transform.Translate (Vector3.right * Trans.speed * Time.deltaTime);
			if (Trans.left == true || Trans.right == true) {
				if (Trans.speed <= 8)
					Trans.speed += Time.deltaTime * 5;
			} else {
				if (Trans.speed >= 0.4f)
					Trans.speed -= Time.deltaTime * 8;
				else
					Trans.speed = -0.001f;	
			}


			if (Trans.right)
				Xvect = 1;
			else if (Trans.left)
				Xvect = -1;

			if (Physics2D.OverlapCircle (Checker.transform.position, 0.2f, isGround)) {
				ray = new Ray2D (new Vector2 (transform.position.x + Xsize * Xvect, transform.position.y - 0.3f), new Vector2 (Xvect, 0f));
				//Debug.DrawRay (ray.origin, ray.direction);
				RaycastHit2D hit = Physics2D.Raycast (ray.origin, ray.direction, 1.5f);
				if (hit.collider != null) {
					if (Trans.speed > 2f) {
						if (hit.collider.tag == "Ground")
							Body.AddRelativeForce (transform.up * 7 * Trans.force);
						if (hit.collider.tag == "Enemies") {
							Body.AddRelativeForce (transform.up * 18 * Trans.force);
							Body.AddRelativeForce (transform.right * 6/Trans.speed *   Trans.force);
						}
					}
				}
				

				///место для прыжков
				//Trans.forceTrue = false;
			}


		} else
			Debug.Log ("PigTransform Transform Manager not found");
	}



	void FixedUpdate(){
		if (Trans != null) {
			if (Trans.speed <= 0.5f) {
				if (Trans.speed >= 0.1f)
					GetComponent<Animator> ().speed = Trans.speed;
				else
					GetComponent<Animator> ().speed = 0;
			} else {
				if (Trans.speed <= 1f)
					GetComponent<Animator> ().speed = Trans.speed;
				else
					GetComponent<Animator> ().speed = 1;
			}
		}
	}


	void OnMouseDown(){
		

	}
}
