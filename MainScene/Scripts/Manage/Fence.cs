using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Sprites;

public class Fence : MonoBehaviour {
	
	public int number;
	private  bool broken, withFlower,withBird;
	private SpriteList list;
	private Sprite sprite;
	private FenceView obj;

	void Start () {
		obj = gameObject.GetComponentInParent<FenceView> ();

	}

	void Update() {
		broken = obj.broken[number];
		withFlower = obj.withFlower[number];
		withBird = obj.withBird[number];
		list = gameObject.GetComponent<SpriteList> ();
		sprite = gameObject.GetComponent<SpriteRenderer> ().sprite;
		changeSprite ();
	}

	void changeSprite() {
		switch (broken) {
		case true:
			if (withBird) {
				list.number = 4;
				break;
			} else if (withFlower) {
				list.number = 5;
				break;
			} else if (!withBird && !withFlower) {
				list.number = 1; break;
			}
			break;
		case false:
			if (withBird) {
				list.number = 3;
				break;
			} else if (withFlower) {
				list.number = 2;
				break;
			} else if (!withBird && !withFlower) {
				list.number = 0;
				break;
			}
			break;
		}
	}

}
