using System.IO;
using UnityEngine;

namespace BartekNizio.Unity.Template.Entitas
{
	public static class SaveToJson
	{
		public static void Save<T>(T file, string fileName, string path) {
			var json = JsonUtility.ToJson(file);
			var savePath = Application.dataPath + $"{path}/{fileName}.json";
			File.WriteAllText(savePath, json);
			Debug.Log($"Successfully saved file to {savePath}");
		}

		public static T Load<T>(string fileName, string path) {
			var json = File.ReadAllText(Application.dataPath + $"{path}/{fileName}.json");
			var file = JsonUtility.FromJson<T>(json);
			return file;
		}
	}
}