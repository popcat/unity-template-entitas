using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

namespace BartekNizio.Unity.Template.Entitas
{
	[Meta, Unique]
	public class SceneLoadingComponent : IComponent
	{
		public AsyncOperation loadOperation;
	}
}