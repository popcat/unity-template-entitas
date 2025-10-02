using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace BartekNizio.Unity.Template.Entitas
{
	[Meta, Unique]
	public class LevelMapComponent : IComponent
	{
		public Graph<MetaEntity> LevelGraph;
	}
}