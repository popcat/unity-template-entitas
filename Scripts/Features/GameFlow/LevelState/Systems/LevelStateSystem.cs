using System.Collections.Generic;
using Entitas;
using Zenject;

namespace BartekNizio.Unity.Template.Entitas
{
	public class LevelStateSystem : ReactiveSystem<MetaEntity>
	{
		[Inject] private readonly SceneService _sceneService;
		private readonly Contexts _contexts;

		public LevelStateSystem(Contexts contexts) : base(contexts.meta)
		{
			_contexts = contexts;
		}

		protected override ICollector<MetaEntity> GetTrigger(IContext<MetaEntity> context)
		{
			return context.CreateCollector(MetaMatcher.LevelState);
		}

		protected override bool Filter(MetaEntity entity)
		{
			return entity.hasLevelState;
		}

		protected override void Execute(List<MetaEntity> entities)
		{
			switch (_contexts.meta.levelState.value) {
				case LevelState.Generation:
					LevelGenerationSequence();
					break;
				case LevelState.Gameplay:
					break;
				case LevelState.Finished:
					break;
			}
		}

		private void LevelGenerationSequence()
		{
			var generationSequence = new SystemSequence(_contexts);
			generationSequence.Add(_sceneService.ReloadGameplaySceneSequence());
			generationSequence.Add((c) => c.meta.levelStateEntity.stateManager.instance.RequestState(LevelState.Gameplay),
				(c,e) => c.meta.levelState.value ==  LevelState.Gameplay);
			
			generationSequence.Start();
		}
		
	}
}