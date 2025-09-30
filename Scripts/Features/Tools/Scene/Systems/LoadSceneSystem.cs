using System.Collections.Generic;
using Entitas;
using UnityEngine.SceneManagement;

namespace BartekNizio.Unity.Template.Entitas
{
	public class LoadSceneSystem : ReactiveSystem<MetaEntity>
	{
		private readonly Contexts _contexts;

		public LoadSceneSystem(Contexts contexts) : base(contexts.meta)
		{
			_contexts = contexts;
		}

		protected override ICollector<MetaEntity> GetTrigger(IContext<MetaEntity> context)
		{
			return context.CreateCollector(MetaMatcher.LoadSceneRequest);
		}

		protected override bool Filter(MetaEntity entity)
		{
			return entity.hasLoadSceneRequest;
		}

		protected override void Execute(List<MetaEntity> entities)
		{
			var sceneIndex = _contexts.meta.loadSceneRequest.sceneIndex;
			var loadOperation = SceneManager.LoadSceneAsync(sceneIndex, LoadSceneMode.Additive);
			loadOperation.completed += _ => {
				SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(sceneIndex));
			};
			_contexts.meta.CreateEntity().AddSceneLoading(sceneIndex,loadOperation);
			_contexts.meta.loadSceneRequestEntity.Destroy();
		}
	}
}