using Zenject;

namespace BartekNizio.Unity.Template.Entitas
{
	public class LevelGenerationSystem : ALevelStateReactiveSystem
	{
		[Inject] private readonly SceneService _sceneService;

		public LevelGenerationSystem(Contexts contexts) : base(contexts)
		{}
		
		protected override void OnLevelState(LevelState state)
		{
			if(state != LevelState.Generation) return;
			
			var generationSequence = new SystemSequence(_contexts);
			generationSequence.Add(_sceneService.ReloadSceneSequence(_contexts.meta.currentLevelEntity.sceneName.Value));
			generationSequence.Add((c) => c.meta.levelStateEntity.stateManager.instance.RequestState(LevelState.Gameplay),
				(c,e) => c.meta.levelState.value ==  LevelState.Gameplay);
			generationSequence.Start();
		}
	}
}