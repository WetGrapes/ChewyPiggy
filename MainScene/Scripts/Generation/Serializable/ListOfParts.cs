using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class ListOfParts  
{
	public string PartName = "Part No. ";
	[Range (5, 10)] public int AmountSet = 7;
	[Range (6, 12)] public int SetOfGround = 8;
	[Range (1, 5)] public int UpDownRandom = 3; 
	[Range (1, 8)] public int DownSet = 5;
	[Range (5, 9)] public int SizeOfCamp = 5;
	[Range (4, 8)] public int SizeOfBigObjects = 5;
	public ListOfObjects[] ObsList = new ListOfObjects[3];
}
