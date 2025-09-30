using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace BartekNizio.Unity.Template.Entitas
{
	[Meta, Unique, Event(EventTarget.Any)]
	public class LevelStateComponent : IComponent
	{
		public LevelState value;
	}
}