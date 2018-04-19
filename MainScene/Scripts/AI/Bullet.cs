using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
	HunterMain Parent;
	PigTransformManagerScript Trans;
	Vector2 start;


	void Start () {
		Parent = GetComponentInParent<HunterMain> ();
		Trans = GameObject.FindGameObjectWithTag ("PigTransformManager").GetComponent<PigTransformManagerScript> ();
		start = transform.localPosition;
	}


	void Update () {
		if (Parent.shotTime > 0.1f ) {
			transform.Translate (Vector3.right * Parent.bulletSpeed * Time.deltaTime);
			if (Mathf.Abs (Trans.PigPos.x - transform.position.x) < 0.3f && Mathf.Abs (Trans.PigPos.y - transform.position.y) < 0.3f) {
				Trans.Dead = true;
				TotalCounterManage.MyScoreCount -= 20;
				TotalCounterManage.MyDeadCount++;
				StPos ();
			}
		} else {
			StPos ();
		}
	}

	void StPos(){
		transform.localPosition = start;//new Vector2 (0.81f, 0.15f);
		gameObject.SetActive (false);
	}

}
