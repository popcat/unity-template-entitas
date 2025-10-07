using UnityEngine;
using UnityEngine.InputSystem;

namespace BartekNizio.Unity.Template.Entitas
{
	[CreateAssetMenu(fileName = "PlayerController_Config",
		menuName = "Config/Player/Controller")]
	public class PlayerControllerConfig : ScriptableObject
	{
		public InputActionMap Input;
	}
}