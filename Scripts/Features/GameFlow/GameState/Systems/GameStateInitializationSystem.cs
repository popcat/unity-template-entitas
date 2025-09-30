using Entitas;
using Zenject;

namespace BartekNizio.Unity.Template.Entitas
{
	public class GameStateInitializationSystem : IInitializeSystem
	{
		private readonly Contexts _contexts;

		public GameStateInitializationSystem(Contexts contexts)
		{
			_contexts = contexts;
		}

		public void Initialize()
		{
			var entity = _contexts.meta.CreateEntity();
			entity.AddGameState(GameState.None, GameState.None);
			entity.AddStateManager(new StateManager(
				entity, (e, st) => { ((MetaEntity)e).ReplaceGameState((GameState)st, ((MetaEntity)e).gameState.Current); }));
		}
	}
}