using System.Collections.Generic;
using Entitas;
using UnityEngine;
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
			AsyncOperation unloadOperation = null;
			if (unloadEntity.hasIndex)
			{
				var sceneIndex = unloadEntity.index.Value;
				unloadOperation = SceneManager.UnloadSceneAsync(SceneManager.GetSceneByBuildIndex(sceneIndex));
			}
			else if(unloadEntity.hasSceneName)
			{
				var sceneName = unloadEntity.sceneName.Value;
				unloadOperation = SceneManager.UnloadSceneAsync(SceneManager.GetSceneByName(sceneName));
			}
			
			unloadOperation.completed += _ => {
				_contextService.EndContextReset(_contexts.game);
			};
			unloadEntity.AddSceneUnloading(unloadOperation);
			unloadEntity.isSceneUnloadRequest = false;
		}
	}
}