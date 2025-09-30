using Entitas;
using UnityEngine;
using Zenject;

namespace BartekNizio.Unity.Template.Entitas
{
    public class CameraRotationSystem : IExecuteSystem
    {
        [Inject] private readonly CameraConfig _cameraConfig;
        private readonly Contexts _contexts;
        
        public CameraRotationSystem(Contexts contexts)
        {
            _contexts = contexts;
        }
        public void Execute()
        {
            if (_contexts.game.hasMainCamera == false) {
                return;
            }
            
            var camera = _contexts.game.mainCameraEntity;
            var cameraHandle = camera.cameraHandle;
            var cameraOrientation = camera.cameraOrientation.orientationIndex;
            var targetRotation = Quaternion.AngleAxis(_cameraConfig.cameraAngles[cameraOrientation], Vector3.up);
            cameraHandle.transform.rotation = Quaternion.Slerp(cameraHandle.transform.rotation, targetRotation, _cameraConfig.cameraRotationInterpolation);
        }
    }
}