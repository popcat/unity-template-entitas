using Entitas;
using Entitas.CodeGeneration.Attributes;
using Unity.Mathematics;

namespace BartekNizio.Unity.Template.Entitas
{
	[Input, Unique]
	public class CursorInputComponent : IComponent
	{
		public float2 screenPosition;
	}
}