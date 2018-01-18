using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManage : MonoBehaviour {
	public Transform ThisCamTransform;
	public Transform target;
	PigTransformManagerScript Trans;
	public float damping = 1, lookAheadFactor = 3, lookAheadReturnSpeed = 0.5f, lookAheadMoveThreshold = 0.1f;
	float offsetZ;
	Vector3 lastTargetPosition;
	Vector3 currentVelocity;
	Vector3 lookAheadPos;
	void Start () {
		lastTargetPosition = target.position;
		offsetZ = (transform.position - target.position).z;
		transform.parent = null;
		Trans = GameObject.FindGameObjectWithTag ("PigTransformManager").GetComponent<PigTransformManagerScript> ();
	}
	
	// Update is called once per frame
	void Update () { 
		
		if (target != null) {
			if (Mathf.Abs ((transform.position - target.position).x) < 3 && Mathf.Abs ((transform.position - target.position).x) > 0.1f)
				damping = 0.5f / Mathf.Abs ((transform.position - target.position).x);
			if (Trans != null) {
				if (lookAheadFactor <= Trans.speed)
					lookAheadFactor += Time.deltaTime;
				else {
					if (lookAheadFactor >= 0.2f)
						lookAheadFactor -= Time.deltaTime * 2;
					else
						lookAheadFactor = 0;
				}
			} else 
				Debug.Log ("CameraManage Transform Manager not found");
			
		
			float xMoveDelta = (target.position - lastTargetPosition).x;
			bool updateLookAheadTarget = Mathf.Abs (xMoveDelta) > lookAheadMoveThreshold;

			if (updateLookAheadTarget)
				lookAheadPos = lookAheadFactor * Vector3.right * Mathf.Sign (xMoveDelta);
			else
				lookAheadPos = Vector3.MoveTowards (lookAheadPos, Vector3.zero, Time.deltaTime * lookAheadReturnSpeed);

			Vector3 aheadTargetPos = target.position + lookAheadPos + Vector3.forward * offsetZ;
			Vector3 newPos = Vector3.SmoothDamp (transform.position, aheadTargetPos, ref currentVelocity, damping);
			transform.position = newPos;
			lastTargetPosition = transform.position;
		} else 
			Debug.Log ("CameraManage Target not found");
		
	}

	void FixedUpdate()
	{
		ThisCamTransform = transform;
	}
}
