using Entitas;
using UnityEngine;

namespace BartekNizio.Unity.Template.Entitas
{
	[Game]
	public class VehicleMovementDirectionComponent : IComponent
	{
		public Vector2 localDirection;
		public Vector3 worldDirection;
	}
}