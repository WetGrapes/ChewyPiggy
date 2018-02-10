using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigTransform : MonoBehaviour {
	PigTransformManagerScript Trans;
	Rigidbody2D Body;
	float  Xvect , MaximalSpeed = 8f;
	bool PreviousUpdateLeft = false, PreviousUpdateRight = false;

	[SerializeField] private GameObject Checker;
	[SerializeField] private LayerMask isGround;

	void Start () {
		Trans = GameObject.FindGameObjectWithTag ("PigTransformManager").GetComponent<PigTransformManagerScript> ();
		Body = GetComponent<Rigidbody2D> ();
		if(Trans == null)
			Debug.Log ("PigTransform - Transform Manager not found");
	}
	void Update () {
		if (Trans != null) {
			SpeedDinamic ();
			AllJump ();
		} 
	}


	void FixedUpdate(){
		AnimatorSwitch ();
	}


	void LateUpdate(){
		SpeedAfterPiggyRotate ();
	}





	void SpeedDinamic(){  //динамика набора скорости
		
		transform.Translate (Vector3.right * Trans.speed * Time.deltaTime);// Изменение координат

		if (Trans.left == true || Trans.right == true) {
			if (Trans.speed <= MaximalSpeed)
				Trans.speed += Time.deltaTime * (MaximalSpeed-Trans.speed);
		} else {
			if (Trans.speed >= 0.4f)
				Trans.speed -= Time.deltaTime * (MaximalSpeed-Trans.speed/3);
			else
				Trans.speed = -0.001f;	
		}

	}





	void AllJump(){  //прыжки
		if (Physics2D.OverlapCircle (Checker.transform.position, 0.1f, isGround)) 
		{
			AutoJump ();
			StandartJump ();
		}
	}

	void AutoJump(){  // прыжок при приближение к высоте
		
		RotateRay ();
		Ray2D ray = new Ray2D (new Vector2 (transform.position.x + Xvect, transform.position.y - 0.3f), new Vector2 (Xvect, 0f));
		RaycastHit2D hit = Physics2D.Raycast (ray.origin, ray.direction, 0.5f);
	
		if (hit.collider != null)
		if (hit.collider.tag == "Ground") {
			if (Trans.speed < 0.5f) {
				transform.Translate (Vector3.right * -(Trans.speed+0.1f) * Time.deltaTime);
			}
			if (Trans.speed > 2.5f)
				Body.AddRelativeForce (transform.up * Trans.force);
			if (Trans.speed > 6f)
				Trans.speed -= Time.deltaTime * (MaximalSpeed-Trans.speed);

		}
	}


	void StandartJump(){
	}
	


	void AnimatorSwitch(){  //анимация, зависящая от скорости
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
		


	void RotateRay(){  //поворот луча
		transform.localRotation = Quaternion.AngleAxis (Trans.rotate, Vector3.up);
		if (Trans.right)
			Xvect = 1;
		else if (Trans.left) 
			Xvect = -1;
	}

	void SpeedAfterPiggyRotate(){
		if (PreviousUpdateLeft != Trans.left || PreviousUpdateRight != Trans.right) {
			PreviousUpdateLeft = Trans.left;
			PreviousUpdateRight = Trans.right;
			if (Trans.speed >= 4) {
				Trans.speed -= Trans.speed / (Trans.speed / 4);
			}
		}
	}

}
