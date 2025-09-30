using Entitas;
using UnityEngine.SceneManagement;

namespace BartekNizio.Unity.Template.Entitas
{
	public class WaitForSceneLoadCompletedSystem : IExecuteSystem
	{
		private readonly Contexts _contexts;

		public WaitForSceneLoadCompletedSystem(Contexts contexts)
		{
			_contexts = contexts;
		}
		public void Execute()
		{
			if(_contexts.meta.hasSceneLoading == false) return;
			if(_contexts.meta.sceneLoading.loadOperation.isDone == false) return;
			_contexts.meta.sceneLoadingEntity.Destroy();
			var s = SceneManager.GetActiveScene();
		}
	}
}