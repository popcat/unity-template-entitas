using System.Collections.Generic;
using UnityEngine;

namespace BartekNizio.Unity.Template.Entitas
{
	[CreateAssetMenu(fileName = "LevelMap Config", menuName = "Config/Level/Map", order = 0)]
	public class LevelMapConfig : ScriptableObject
	{
		public List<LevelConfig> Levels;
	}
}