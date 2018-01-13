using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Sprites;

public class GroundList : MonoBehaviour {
	public int number;
	public static int size;
	public Sprite[] sprites = new Sprite[size];
	public SpriteRenderer sp; 
	int[] founderGround = new int[4];
	int a, finishGroundSet;
	float Timer = 0.5f;
	void Update() {
		if (Timer > 0) {
			for (int i = 0; i < 4; i++) {
				founderGround [i] = GetComponent<Founder> ().foundGround [i];

			}
			if (founderGround [0] == 1 || founderGround [1] == 1 || founderGround [2] == 1 || founderGround [3] == 1) {
				if (founderGround [0] == 1 && founderGround [1] == 1 && founderGround [2] == 1 && founderGround [3] == 1)
					number = 4;
				else if (founderGround [0] == 1 && founderGround [3] == 1) {
					if (founderGround [1] == 1 || founderGround [2] == 1) {
						if (founderGround [1] == 1)
							number = 5;
						else
							number = 3;
					} else
						number = 13;
				} else if (founderGround [1] == 1 && founderGround [2] == 1) {
					if (founderGround [0] == 1 || founderGround [3] == 1) {
						if (founderGround [0] == 1)
							number = 7;
						else
							number = 1;
					} else
						number = 1;
				} else {
					if (founderGround [1] == 1 || founderGround [2] == 1) {
						if (founderGround [1] == 1) {
							if (founderGround [0] == 1)
								number = 8;
							else
								number = 2;
						} else {
							if (founderGround [0] == 1)
								number = 6;
							else
								number = 0;
						}
					} else {
						if (founderGround [0] == 1)
							number = 14;
						else
							number = 12;
					}
				}
			} else
				number = 15;

			sp = GetComponent<SpriteRenderer> ();
			sp.sprite = sprites [number];	
			Timer -= Time.deltaTime;
		} else
			Destroy (this);
	}
}
