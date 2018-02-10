#if UNITY_EDITOR

using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEditor;

public class CreateEnum  {
	[System.Serializable]
	public class EnumClass
	{
		public EnumClass(List<GameObject> names, string name)
		{
			this.names = names;
			this.name = name;
		}

		public string name;
		public List<GameObject> names = new List<GameObject>();
	}

	public static void CreateEnumInFile(string filepath, params EnumClass[] enums)
	{
		using (StreamWriter streamWriter = new StreamWriter (filepath)) {
			foreach (var e in enums) {
				AddEnum (streamWriter, e.names, e.name);
			}
		}
		AssetDatabase.Refresh ();
	}

	public static void AddEnum(StreamWriter streamWriter, List<GameObject> list, string enumName)
	{
		streamWriter.WriteLine ("public enum " + enumName);
		streamWriter.WriteLine ("{");
		for (int i = 0; i < list.Count; i++) {
			streamWriter.WriteLine ("\t" + list[i] + "");
		}
		streamWriter.WriteLine ("}");
		streamWriter.WriteLine (" ");
	}

}
#endif

