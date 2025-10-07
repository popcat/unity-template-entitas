using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

namespace BartekNizio.Unity.Template.Entitas
{
	[Game, Meta, Input, Ui, Event(EventTarget.Self), Event(EventTarget.Any)]
	public class Collider2DComponent : IComponent
	{
		public Collider2D Instance;
	}
}