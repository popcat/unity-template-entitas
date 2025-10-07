using Entitas;
using Zenject;

namespace BartekNizio.Unity.Template.Entitas
{
	public class ObjectPoolInitializationSystem : IInitializeSystem
	{
		private readonly Contexts _contexts;

		[Inject]
		private readonly GameObjectPoolConfig _gameObjectPoolConfig;

		[Inject]
		private readonly GameObjectPoolService _gameObjectPoolService;

		public ObjectPoolInitializationSystem(Contexts contexts) {
			_contexts = contexts;
		}

		public void Initialize() {
			foreach (var prewarm in _gameObjectPoolConfig.objectsToPrewarm) {
				_gameObjectPoolService.Prewarm(prewarm.prefab, prewarm.count);
			}
		}
	}
}