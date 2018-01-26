using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class ListOfObjects 
{
	public string ListName;
	//[Range (1, 7)] public int NumOfObs;
	[Range (1, 5)] public int UpDownRandom; 
	[Range (4, 10)] public int SetOfGround;
	[Range (1, 8)] public int DownSet;
	public ObjectData[] Obs;

}
