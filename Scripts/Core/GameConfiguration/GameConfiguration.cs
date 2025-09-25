using System.Collections.Generic;
using UnityEngine;

namespace BartekNizio.Unity.Template.Entitas
{
	[CreateAssetMenu(fileName = "Game Configuration", menuName = "Config/Game Configuration")]
	public class GameConfiguration : ScriptableObject
	{
		public List<ScriptableObject> configs;
		
		public T GetConfig<T>() where T : class
		{
			foreach ( var c in configs ) {
				if ( c is T ) {
					return c as T;
				}
			}
			return null;
		}

		public void SetConfig<T>( T config ) where T : ScriptableObject
		{
			for ( int i = 0; i < configs.Count; i++ ) {
				if ( configs[i] is T ) {
					configs[i] = config;
					return;
				}
			}
			configs.Add( config );
		}

#if UNITY_EDITOR
		public static GameConfiguration FindDefaultGameConfiguration()
		{
			var guids = UnityEditor.AssetDatabase.FindAssets("Game Config");
			return UnityEditor.AssetDatabase.LoadAssetAtPath<GameConfiguration>(
				UnityEditor.AssetDatabase.GUIDToAssetPath(guids[0]));
		}
#endif
	}
}