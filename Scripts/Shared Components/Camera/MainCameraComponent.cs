using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace BartekNizio.Unity.Template.Entitas
{
	[Unique, Game, Meta, Input, Ui, Event(EventTarget.Self), Event(EventTarget.Any)]
	public class MainCameraComponent : IComponent
	{ }
}