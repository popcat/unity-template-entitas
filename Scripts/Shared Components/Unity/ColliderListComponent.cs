using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

namespace BartekNizio.Unity.Template.Entitas
{
	[Game, Meta, Input, Ui, Event(EventTarget.Self), Event(EventTarget.Any)]
	public class ColliderListComponent : IComponent
	{
		public List<Collider> Instances;
	}
}