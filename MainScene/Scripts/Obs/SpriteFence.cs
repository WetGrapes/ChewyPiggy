using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteFence : MonoBehaviour {

	public int number;
	public Sprite[] sprites; 
	public SpriteRenderer sp; 

	void Update() {
		sp = GetComponent<SpriteRenderer> ();
		sp.sprite = sprites [number];	
	}
}
