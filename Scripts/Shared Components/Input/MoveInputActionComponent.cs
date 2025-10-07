using Entitas;
using UnityEngine.InputSystem;

namespace BartekNizio.Unity.Template.Entitas
{
	[Input]
	public class MoveInputActionComponent : IComponent
	{
		public InputAction Value;
	}
}