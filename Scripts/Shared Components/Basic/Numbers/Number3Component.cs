using Entitas;
using Entitas.CodeGeneration.Attributes;
using Unity.Mathematics;

namespace BartekNizio.Unity.Template.Entitas
{
	[Game, Meta, Input, Ui, Event(EventTarget.Self), Event(EventTarget.Any)]
	public class Number3Component : IComponent
	{
		public int3 Value;
	}
}