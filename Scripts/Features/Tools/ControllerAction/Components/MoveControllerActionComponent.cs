using Entitas;
using UnityEngine;

namespace BartekNizio.Unity.Template.Entitas
{
	[Game]
	public class MoveControllerActionComponent : IComponent
	{
		public InputActionStatus Status;
		public Vector2 Value;
	}
}