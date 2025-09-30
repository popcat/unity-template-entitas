using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

namespace BartekNizio.Unity.Template.Entitas
{
	[Input, Unique]
	public class DragInputComponent : IComponent
	{
		public Vector2 value;
		public DragState state;
	}
}