using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace BartekNizio.Unity.Template.Entitas
{
	[Meta, Unique]
	public class UnloadSceneRequestComponent : IComponent
	{
		public int sceneIndex;
	}
}