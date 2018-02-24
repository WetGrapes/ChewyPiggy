#if UNITY_EDITOR

using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEditor;


public class AutoLoad {
	[System.Serializable]
	public class LoadClass 
	{
		public LoadClass( string name)
		{
			this.name = name;
		}

		public string name;
		public List<string> names = new List<string>();
	}

	public static void LoadNameInFile(string[] filepath, params LoadClass[] enums)
	{
		
		for (int j = 0; j < filepath.Length; j++) {
			
			List<string> nameList = new List<string>();
			var di = new DirectoryInfo (Application.dataPath + "/MainScene/Prefabs/Obs/" + filepath [j]);
			FileInfo[] files = di.GetFiles ("*.prefab");

			for (int i = 0; i < files.Length; i++) {
				nameList.Add (files [i].Name);
				nameList[i] = nameList[i].Remove (nameList [i].IndexOf ("."));
			}
			enums [j].names = nameList;
		}

		using (StreamWriter streamWriter = new StreamWriter (Application.dataPath+"/Backend/enum.cs")) {
			foreach (var e in enums) {
				AddName (streamWriter, e.names, e.name);
			}
		}
		AssetDatabase.Refresh ();
	}

	public static void AddName(StreamWriter streamWriter, List<string> list, string enumName)
	{
		streamWriter.WriteLine ("public enum " + enumName);
		streamWriter.WriteLine ("{");
		for (int i = 0; i < list.Count; i++) {
			streamWriter.WriteLine ("\t" + list[i] + ",");
		}
		streamWriter.WriteLine ("}");
		streamWriter.WriteLine (" ");
	}

}
#endif