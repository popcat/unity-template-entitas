using Entitas;
using UnityEngine;
using Zenject;

namespace BartekNizio.Unity.Template.Entitas.Platformer2D
{
    public class CharacterControllerSystem : IExecuteSystem
    {
        [Inject]
        private readonly InputConfig _inputConfig;
        private readonly Contexts _contexts;

        public CharacterControllerSystem(Contexts contexts)
        {
            _contexts = contexts;
        }
        
        public void Execute()
        {
            if(_contexts.game.hasPlatformer2DCharacterController == false) return;

            var controllerEntity = _contexts.game.platformer2DCharacterControllerEntity;
            var controller = controllerEntity.characterController.Instance;
            var inputDir = _inputConfig.playerMovementInputAction.ReadValue<Vector2>();
            controller.SimpleMove(new Vector3(inputDir.x * controllerEntity.speed.Value * Time.deltaTime, -8.9f * Time.deltaTime, 0));
        }
    }
}