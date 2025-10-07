using Entitas;
using Zenject;

namespace BartekNizio.Unity.Template.Entitas
{
	public class LevelMapInitializationSystem : IInitializeSystem
	{
		private readonly Contexts _contexts;

		[Inject]
		private readonly LevelMapConfig _levelMapConfig;

		public LevelMapInitializationSystem(Contexts contexts) {
			_contexts = contexts;
		}

		public void Initialize() {
			var rodeMapGraph = new Graph<MetaEntity>();
			GraphNode<MetaEntity> prevNode = null;
			var counter = 0;
			foreach (var levelConfig in _levelMapConfig.Levels) {
				var levelEntity = _contexts.meta.CreateEntity();
				levelEntity.isLevel = true;
				levelEntity.AddIndex(counter);
				if (levelConfig.Scene != null) {
					levelEntity.AddSceneName(levelConfig.Scene.SceneName);
				}
				else {
					levelEntity.AddSceneName(_levelMapConfig.DefaultScene.SceneName);
				}

				prevNode = rodeMapGraph.AddNode(levelEntity, counter, prevNode);
				counter++;
			}

			_contexts.meta.CreateEntity().AddLevelMap(rodeMapGraph);
		}
	}
}