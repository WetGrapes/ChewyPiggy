using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class ListOfObjects 
{
	[Header("Список из объектов")]
	[Space]
	public EnemiesData[] Enemies = new EnemiesData[2];
	[Space]
	public ObsData[] Obs = new ObsData[4];
	[Space]
	public TreesData[] Trees = new TreesData[5];

}
