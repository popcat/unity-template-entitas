using UnityEngine;
using Zenject;

namespace BartekNizio.Unity.Template.Entitas
{
    public class GameObjectEntityInitializer : MonoBehaviour
    {
        [Inject]
        private void InitializeGameObjectEntities(Contexts contexts, GameConfiguration gameConfiguration, GameObjectEntityComponentService gameObjectEntityComponentService)
        {
            var GOEs = FindObjectsByType<GameObjectEntity>(FindObjectsInactive.Exclude, FindObjectsSortMode.None);
            foreach (var goe in GOEs)
            {
                goe.Initialize(contexts, gameConfiguration, gameObjectEntityComponentService);
            }
        }
    }
}