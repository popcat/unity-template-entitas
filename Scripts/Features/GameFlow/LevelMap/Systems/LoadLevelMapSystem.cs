using Zenject;

namespace BartekNizio.Unity.Template.Entitas
{
	public class LoadLevelMapSystem : AGameStateReactiveSystem
	{
		[Inject] private readonly LevelMapConfig _levelMapConfig;
		
		public LoadLevelMapSystem(Contexts contexts) : base(contexts)
		{ }

		protected override void OnGameState(GameState current, GameState previous)
		{
			if(current != GameState.MainMenu) return;
			if(_contexts.meta.hasLevelMap) return;

			var rodeMapGraph = new Graph<LevelMapNode>();
			GraphNode<LevelMapNode> prevNode = null;
			foreach (var levelConfig in _levelMapConfig.Levels) {
				var roadMapNode = new LevelMapNode {
					Scene = levelConfig.Scene.SceneName
				};
				prevNode = rodeMapGraph.AddNode(roadMapNode, prevNode);
			}
			
			_contexts.meta.CreateEntity().AddLevelMap(rodeMapGraph);
		}
	}
}