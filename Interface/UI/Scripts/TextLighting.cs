using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextLighting : MonoBehaviour {

	[Header("Свечение сзади")]
	[SerializeField] Outline ligh = null;
	[SerializeField] [Range(1,10)] int speed = 2;
	[Space]
	[Header("Темная обводка буквы")]
	[SerializeField] Outline ligh2 = null;
	[SerializeField] [Range(1,10)] int speed2 = 5;
	float timer = 2f;
	bool act = false;

	void Start () {
		
	}
	

	void FixedUpdate () {
		if (timer >= 0) {
			timer -= Time.fixedDeltaTime;
			if (act) {
				ligh.effectDistance = new Vector2 
					(ligh.effectDistance.x + Time.fixedDeltaTime / speed * 1.2f, ligh.effectDistance.y + Time.deltaTime / speed * 1.2f);
				
				ligh.effectColor = new Color (ligh.effectColor.r, ligh.effectColor.g, ligh.effectColor.b, 
					ligh.effectColor.a + Time.fixedDeltaTime / speed / 10 );
				
				ligh2.effectColor = new Color (ligh2.effectColor.r, ligh2.effectColor.g, ligh2.effectColor.b, 
					ligh2.effectColor.a + Time.fixedDeltaTime / speed2 );
				
			} else {
				ligh.effectDistance = new Vector2 
					(ligh.effectDistance.x - Time.fixedDeltaTime / speed * 1.2f, ligh.effectDistance.y - Time.deltaTime / speed * 1.2f);
				
				ligh.effectColor = new Color (ligh.effectColor.r, ligh.effectColor.g, ligh.effectColor.b, 
					ligh.effectColor.a - Time.fixedDeltaTime /  speed / 10 );
				
				ligh2.effectColor = new Color (ligh2.effectColor.r, ligh2.effectColor.g, ligh2.effectColor.b, 
					ligh2.effectColor.a - Time.fixedDeltaTime / speed2 );
			}
		} else {
			timer = 2f;
			act = !act;
		}
	}

}
