using System.Collections.Generic;
using Entitas;
using Zenject;

namespace BartekNizio.Unity.Template.Entitas
{
	public class LevelStateInitializationSystem : ReactiveSystem<MetaEntity>
	{
		[Inject] private readonly LevelMapConfig _levelMapConfig;
		private readonly Contexts _contexts;

		public LevelStateInitializationSystem(Contexts contexts) : base(contexts.meta)
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
			if (_contexts.meta.hasLevelState == false) {
				var gameplayStateEntity = _contexts.meta.CreateEntity();
				gameplayStateEntity.AddLevelState(LevelState.None);
				gameplayStateEntity.AddStateManager(new StateManager(gameplayStateEntity,
					(entity, state) => ((MetaEntity)entity).ReplaceLevelState((LevelState)state)));
			}

			switch (_contexts.meta.gameState.Current) {
				case GameState.MainMenu:
					_contexts.meta.levelStateEntity.stateManager.instance.RequestState(LevelState.None);
					break;
				case GameState.Level:
					_contexts.meta.levelStateEntity.stateManager.instance.RequestState(LevelState.Generation);
					break;
			}
		}
	}
}