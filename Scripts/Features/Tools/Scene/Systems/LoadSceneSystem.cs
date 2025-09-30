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
			return context.CreateCollector(MetaMatcher.SceneLoadRequest);
		}

		protected override bool Filter(MetaEntity entity)
		{
			return entity.isSceneLoadRequest;
		}

		protected override void Execute(List<MetaEntity> entities)
		{
			var loadSceneEntity = _contexts.meta.sceneLoadRequestEntity;
			var sceneIndex = loadSceneEntity.index.Value;
			var loadOperation = SceneManager.LoadSceneAsync(sceneIndex, LoadSceneMode.Additive);
			loadOperation.completed += _ => {
				SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(sceneIndex));
			};
			loadSceneEntity.AddSceneLoading(loadOperation);
			loadSceneEntity.isSceneLoadRequest = false;
		}
	}
}