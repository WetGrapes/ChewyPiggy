using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Sprites;


public class SpriteList : MonoBehaviour {
	
	public int number;
	public Sprite[] sprites; 
	public SpriteRenderer sp; 

	void Start(){
		number = Random.Range (0, sprites.Length);
	}

	void Update() {
		sp = GetComponent<SpriteRenderer> ();
		sp.sprite = sprites [number];	
	}
}

