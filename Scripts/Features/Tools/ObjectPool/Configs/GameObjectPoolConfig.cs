using System;
using System.Collections.Generic;
using UnityEngine;

namespace BartekNizio.Unity.Template.Entitas
{
	[CreateAssetMenu(fileName = "GameObjectPoolConfig", menuName = "Config/GameObjectPool", order = 0)]
	public class GameObjectPoolConfig : ScriptableObject
	{
		public List<PrewarmGameObject> objectsToPrewarm;
	}
	
	[Serializable]
	public class PrewarmGameObject
	{
		public GameObject prefab;
		public int count;
	}
}