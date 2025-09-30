using Entitas;
using UnityEngine;
using Zenject;

namespace BartekNizio.Unity.Template.Entitas
{
    public class CameraFollowPlayerSystem : IExecuteSystem
    {
        [Inject]
        private readonly CameraConfig _cameraConfig;
        private readonly Contexts _contexts;

        public CameraFollowPlayerSystem(Contexts contexts)
        {
            _contexts = contexts;
        }
        
        public void Execute()
        {
            if(_contexts.game.isPlayer == false) return;
            if(_contexts.game.hasMainCamera == false) return;
            
            var playerPos = _contexts.game.playerEntity.transform.instance.position;
            var cameraPos = _contexts.game.mainCameraEntity.cameraHandle.transform.position;
            
            var nextPos = Vector3.Lerp(cameraPos, playerPos, _cameraConfig.cameraSpeed * Time.deltaTime); ;
            _contexts.game.mainCameraEntity.cameraHandle.transform.position = nextPos;
        }
    }
}