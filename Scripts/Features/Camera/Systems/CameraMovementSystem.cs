using Entitas;
using UnityEngine;
using Zenject;

namespace BartekNizio.Unity.Template.Entitas
{
    public class CameraMovementSystem : IExecuteSystem
    {
        [Inject] private readonly CameraConfig _cameraConfig;
        private readonly Contexts _contexts;

        public CameraMovementSystem(Contexts contexts)
        {
            _contexts = contexts;
        }
        
        public void Execute()
        {
            if (_contexts.game.hasMainCamera == false) {
                return;
            }
            
            var camera = _contexts.game.mainCameraEntity;
            var cameraHandle = camera.cameraHandle.transform;
            
            if (_contexts.game.hasMoveCameraRequest)
            {
                var targetPosition = _contexts.game.moveCameraRequest.targetPosition;
                camera.cameraMovement.targetPosition = targetPosition;
            }

            cameraHandle.position = Vector3.Lerp(cameraHandle.position, camera.cameraMovement.targetPosition,
                _cameraConfig.cameraMovementInterpolation);
        }
    }
}