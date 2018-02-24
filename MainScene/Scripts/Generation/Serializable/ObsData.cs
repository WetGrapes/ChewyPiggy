using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class ObsData 
{
	[Range(0, 3)] public int Obs;
	[Range (1, 8)] public int Size;
	public bool OneOnIsland;
}
