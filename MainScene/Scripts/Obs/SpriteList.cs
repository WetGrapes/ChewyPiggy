using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Sprites;


public class SpriteList : MonoBehaviour {


	public int number;
	public static int size;
	public Sprite[] sprites = new Sprite[size];
	public SpriteRenderer sp; 

	void Update() {
		sp = GetComponent<SpriteRenderer> ();
		sp.sprite = sprites [number];	
	}
}

