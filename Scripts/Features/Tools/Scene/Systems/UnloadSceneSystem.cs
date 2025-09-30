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
			return context.CreateCollector(MetaMatcher.SceneUnloadRequest);
		}

		protected override bool Filter(MetaEntity entity)
		{
			return entity.isSceneUnloadRequest;
		}

		protected override void Execute(List<MetaEntity> entities)
		{
			_contextService.StartContextReset(_contexts.game);
			var unloadEntity = _contexts.meta.sceneUnloadRequestEntity;
			var sceneIndex = unloadEntity.index.Value;
			var op = SceneManager.UnloadSceneAsync(SceneManager.GetSceneByBuildIndex(sceneIndex));
			op.completed += _ => {
				_contextService.EndContextReset(_contexts.game);
			};
			
			unloadEntity.AddSceneUnloading(op);
			unloadEntity.isSceneUnloadRequest = false;
		}
	}
}