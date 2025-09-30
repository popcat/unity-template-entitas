using System.Collections.Generic;
using Entitas;
using UnityEngine.SceneManagement;
using Zenject;

namespace BartekNizio.Unity.Template.Entitas
{
	public class UnloadSceneSystem : ReactiveSystem<MetaEntity>
	{
		[Inject] private readonly ContextService _contextService;
		private readonly Contexts _contexts;

		public UnloadSceneSystem(Contexts contexts) : base(contexts.meta)
		{
			_contexts = contexts;
		}

		protected override ICollector<MetaEntity> GetTrigger(IContext<MetaEntity> context)
		{
			return context.CreateCollector(MetaMatcher.UnloadSceneRequest);
		}

		protected override bool Filter(MetaEntity entity)
		{
			return entity.hasUnloadSceneRequest;
		}

		protected override void Execute(List<MetaEntity> entities)
		{
			_contextService.StartContextReset(_contexts.game);
			var sceneIndex = _contexts.meta.unloadSceneRequest.sceneIndex;
			var op = SceneManager.UnloadSceneAsync(SceneManager.GetSceneByBuildIndex(sceneIndex));
			op.completed += _ => {
				_contextService.EndContextReset(_contexts.game);
			};
			
			_contexts.meta.CreateEntity().AddSceneUnloading(sceneIndex, op);
			_contexts.meta.unloadSceneRequestEntity.Destroy();
		}
	}
}