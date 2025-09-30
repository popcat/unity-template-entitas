using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace BartekNizio.Unity.Template.Entitas
{
	[Meta, Event(EventTarget.Self), Event(EventTarget.Any)]
	public class SystemSequenceComponent : IComponent
	{
		public SystemSequence Instance;
	}
}