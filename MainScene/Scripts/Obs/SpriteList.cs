using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Sprites;


public class SpriteList : MonoBehaviour {
	
	[System.NonSerialized] public int number;
	[SerializeField] Sprite[] sprites = new Sprite[0]; 
	SpriteRenderer sp; 

	void Start(){
		number = Random.Range (0, sprites.Length);
	}

	void Update() {
		sp = GetComponent<SpriteRenderer> ();
		sp.sprite = sprites [number];	
	}
}

