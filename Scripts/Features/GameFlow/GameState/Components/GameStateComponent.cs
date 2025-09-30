using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace BartekNizio.Unity.Template.Entitas
{
	[Meta, Unique, Event(EventTarget.Any)]
	public class GameStateComponent : IComponent
	{
		public GameState Current;
		public GameState Previous;
	}
}