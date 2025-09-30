using System.Collections.Generic;

namespace BartekNizio.Unity.Template.Entitas
{
	public static class CollectionsUtility
	{
		public static Dictionary<T, int> ListToDictionary<T>(List<T> list)
		{
			var dictionary = new Dictionary<T, int>(list.Count);
			for (int i = 0; i < list.Count; i++) {
				dictionary.Add(list[i], i);
			}

			return dictionary;
		}
	}
}