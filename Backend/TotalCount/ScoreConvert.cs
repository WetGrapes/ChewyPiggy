using System.Collections;
using System.Collections.Generic;
using UnityEngine;

partial class TotalCounterManage : MonoBehaviour{


	public static bool score;
	public static int Upgrade;

	void FixedUpdate(){
		if (score)
			MyScoreCount += Convert (Upgrade);
		if (MyScoreCount > 10000000000000000000)
			MyScoreCount = 0;
	}


	ulong Convert(int Upgrade){
		ulong x = 0;
		float up = 0, down = 0, onePlus = 0;
		onePlus = 1 + ((float)Upgrade / 100);
		up = (float)MyPlayingTimeSecondsCount * onePlus;
		down = (float)MyPlayingTimeSecondsCount / onePlus;
		x = (ulong)(up / down);
		score = false;
		return x;
	}

}
