using UnityEngine;
using UnityEngine.InputSystem;

namespace BartekNizio.Unity.Template.Entitas
{
	[CreateAssetMenu(fileName = "Input Config", menuName = "Config/Input Config")]
	public class InputConfig : ScriptableObject
	{
		public InputActionAsset inputActionAsset;

		[Space]
		public float dragThreshold;
		[Space]
		public InputAction selectInputAction;
		[Space]
		public InputAction interactInputAction;
		[Space]
		public InputAction cursorPositionInputAction;
		[Space]
		public InputAction dragInputAction;
		[Space]
		public InputAction moveCameraInputAction;
		[Space]
		public InputAction rotateCameraInputAction;
		[Space]
		public InputAction finishTurnInputAction;
		
		[Space]
		public InputAction playerMovementInputAction;
	}
}