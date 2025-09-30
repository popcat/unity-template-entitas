using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

namespace BartekNizio.Unity.Template.Entitas
{
	[Input, Unique, Cleanup(CleanupMode.DestroyEntity)]
	public class SelectInputComponent : IComponent
	{
		public Vector2 screenPosition;
	}
}