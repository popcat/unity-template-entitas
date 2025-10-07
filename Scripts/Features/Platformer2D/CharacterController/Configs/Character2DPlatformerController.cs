using UnityEngine;

namespace BartekNizio.Unity.Template.Entitas.Platformer2D
{
	[CreateAssetMenu(fileName = "Character2DPlatformerController", menuName = "Config/Platformer2D/CharacterController")]
	public class Character2DPlatformerController : ScriptableObject
	{
		public CharacterControllerSpecs Specifications;
	}
}