using Entitas;

namespace BartekNizio.Unity.Template.Entitas
{
	public class WaitForSceneUnloadCompletedSystem : IExecuteSystem
	{
		private readonly Contexts _contexts;

		public WaitForSceneUnloadCompletedSystem(Contexts contexts) {
			_contexts = contexts;
		}

		public void Execute() {
			if (_contexts.meta.hasSceneUnloading == false) {
				return;
			}

			if (_contexts.meta.sceneUnloading.loadOperation.isDone == false) {
				return;
			}

			var unloadEntity = _contexts.meta.sceneUnloadRequestEntity;
			unloadEntity.RemoveSceneUnloading();
			unloadEntity.isSceneUnloadCompleted = true;
		}
	}
}