using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace BartekNizio.Unity.Template.Entitas
{
	[Game, Meta, Cleanup(CleanupMode.RemoveComponent)]
	public class StateBroadcastComponent : IComponent
	{ }
}