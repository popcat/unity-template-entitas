using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace BartekNizio.Unity.Template.Entitas
{
	[Meta, Unique]
	public class LoadSceneRequestComponent : IComponent
	{
		public int sceneIndex;
	}
}