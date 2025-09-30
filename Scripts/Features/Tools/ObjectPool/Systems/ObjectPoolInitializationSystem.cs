using Entitas;
using Zenject;

namespace BartekNizio.Unity.Template.Entitas
{
    public class ObjectPoolInitializationSystem : IInitializeSystem
    {
        [Inject] private readonly GameObjectPoolConfig _gameObjectPoolConfig;
        [Inject] private readonly GameObjectPoolService _gameObjectPoolService;
        private readonly Contexts _contexts;
        
        public ObjectPoolInitializationSystem(Contexts contexts)
        {
            _contexts = contexts;
        }
        
        public void Initialize()
        {
            foreach (var prewarm in _gameObjectPoolConfig.objectsToPrewarm)
            {
                _gameObjectPoolService.Prewarm(prewarm.prefab, prewarm.count);
            }
        }
    }
}