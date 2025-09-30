using Entitas;
using Zenject;

namespace BartekNizio.Unity.Template.Entitas
{
    public class CameraRotationInputSystem : IExecuteSystem
    {
        [Inject] public InputConfig _inputConfig;
        [Inject] public CameraConfig _cameraConfig;
        private readonly Contexts _contexts;

        public CameraRotationInputSystem(Contexts contexts)
        {
            _contexts = contexts;
        }
        
        public void Execute()
        {
            if (_contexts.game.hasMainCamera == false) {
                return;
            }
            
            var inputAction = _inputConfig.rotateCameraInputAction;
            if (inputAction.WasPressedThisFrame())
            {
                var axis = inputAction.ReadValue<float>();
                var camera = _contexts.game.mainCameraEntity;
                var cameraOrientation = (camera.cameraOrientation.orientationIndex + (int)axis);
                cameraOrientation = cameraOrientation < 0 ? _cameraConfig.cameraAngles.Length - 1 : cameraOrientation;
                cameraOrientation %= _cameraConfig.cameraAngles.Length;
                camera.ReplaceCameraOrientation(cameraOrientation);
            }
        }
    }
}