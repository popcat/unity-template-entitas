using System.Collections.Generic;
using Entitas;

namespace BartekNizio.Unity.Template.Entitas
{
	public class GameStateInitializationSystem : ReactiveSystem<MetaEntity>
	{
		private readonly Contexts _contexts;

		public GameStateInitializationSystem(Contexts contexts) : base(contexts.meta)
		{
			_contexts = contexts;
		}

		protected override ICollector<MetaEntity> GetTrigger(IContext<MetaEntity> context)
		{
			return context.CreateCollector(MetaMatcher.BootFinished);
		}

		protected override bool Filter(MetaEntity entity)
		{
			return entity.isBootFinished;
		}

		protected override void Execute(List<MetaEntity> entities)
		{
			var entity = _contexts.meta.CreateEntity();
			entity.AddGameState(GameState.None, GameState.None);
			entity.AddStateManager(new StateManager(
				entity, (e, st) => { ((MetaEntity)e).ReplaceGameState(
					(GameState)st, ((MetaEntity)e).gameState.Current); }));
		}
	}
}