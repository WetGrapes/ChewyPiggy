using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class ListOfParts  
{
	public string PartName;
	[Range (1, 10)] public int AmountSet;
	public ListOfObjects[] ObsList;
}
