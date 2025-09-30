using Entitas;
using ExtensionMethods;
using UnityEngine;
using Zenject;

namespace BartekNizio.Unity.Template.Entitas
{
    public class CameraMovementInputSystem : IExecuteSystem
    {
        [Inject] private InputConfig _inputConfig;
        [Inject] private CameraConfig _cameraConfig;
        private readonly Contexts _contexts;
        
        public CameraMovementInputSystem(Contexts contexts)
        {
            _contexts = contexts;
        }
        
        public void Execute()
        {
            if (_contexts.game.hasMainCamera == false) {
                return;
            }
            
            var moveCameraInputAction = _inputConfig.moveCameraInputAction;
            var axis = moveCameraInputAction.ReadValue<Vector2>();
            if (axis == Vector2.zero)
            {
                return;
            }
            
          
            var camera = _contexts.game.mainCameraEntity;
            var orientationHandle = camera.orientationHandle.transform;
            
            var moveDirection = orientationHandle.TransformDirection(axis.MapTo3D());
            var targetPosition = camera.cameraMovement.targetPosition;
            targetPosition += moveDirection * _cameraConfig.cameraSpeed * Time.deltaTime;
            _contexts.game.CreateEntity().AddMoveCameraRequest(targetPosition);
        }
    }
}