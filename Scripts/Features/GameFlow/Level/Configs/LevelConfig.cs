using RoboRyanTron.SceneReference;
using UnityEngine;

namespace BartekNizio.Unity.Template.Entitas
{
	[CreateAssetMenu(fileName = "X_LevelConfig", menuName = "Config/Level/Level")]
	public class LevelConfig : ScriptableObject
	{
		public SceneReference Scene;
	}
}