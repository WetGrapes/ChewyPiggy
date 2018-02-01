using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Sprites;

public class Fence : MonoBehaviour {

	int numOfChanges, numberOfFence ;
	float timer=0.5f;
	GameObject Child;
	public Sprite[] sprites = new Sprite[3]; 
	public SpriteRenderer sp; 

	void Start () {
		numberOfFence = Random.Range(1,4);
		sp = transform.GetChild (4).GetComponent<SpriteRenderer> ();
		sp.sprite = sprites [numberOfFence-1];
		float ad = numberOfFence / 2;
		for (int Count = numberOfFence; Count >= 0; Count--)
		{
			Child = transform.GetChild (Count).gameObject;
			Child.SetActive (true);
			if (Random.Range (0, 2) == 1)
			if (numOfChanges <= ad)
				changeSprite ();
		}}

	void Update() {
		timer-=Time.deltaTime;
		if (timer<=0)
			Destroy(this);
	}

	void changeSprite() {
		Child.GetComponent<SpriteFence> ().number = Random.Range(1,6);
		numOfChanges++;
	}//первый спрайт это целый простой кол, остальные неважно
}
