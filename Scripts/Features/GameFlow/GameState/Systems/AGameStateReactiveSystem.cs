using System.Collections.Generic;
using Entitas;

namespace BartekNizio.Unity.Template.Entitas
{
	public abstract class AGameStateReactiveSystem : ReactiveSystem<MetaEntity>
	{
		protected readonly Contexts _contexts;

		public AGameStateReactiveSystem(Contexts contexts) : base(contexts.meta)
		{
			_contexts = contexts;
		}

		protected override ICollector<MetaEntity> GetTrigger(IContext<MetaEntity> context)
		{
			return context.CreateCollector(MetaMatcher.GameState);
		}

		protected override bool Filter(MetaEntity entity)
		{
			return entity.hasGameState;
		}

		protected override void Execute(List<MetaEntity> entities)
		{
			OnGameState(_contexts.meta.gameState.Current, _contexts.meta.gameState.Previous);
		}

		protected abstract void OnGameState(GameState current, GameState previous);
	}
}