using Entitas;
using UnityEngine;

namespace BartekNizio.Unity.Template.Entitas.Platformer2D
{
    public class PlayerControllerInputSystem : IExecuteSystem
    {
        private readonly Contexts _contexts;

        public PlayerControllerInputSystem(Contexts contexts)
        {
            _contexts = contexts;
        }

        public void Execute()
        {
            if (_contexts.input.isPlatformer2DPlayerControllerU == false) return;

            var playerEntity = _contexts.game.playerUEntity;
            if (playerEntity.hasControllerAction == false)
            {
                Debug.LogError("Player doesn't have ControllerActionComponent");
                return;
            }

            var playerControllerEntity = _contexts.input.platformer2DPlayerControllerUEntity;
            var controllerActionEntity = (GameEntity)playerEntity.controllerAction.Entity;

            controllerActionEntity.ReplaceMoveControllerAction(
                playerControllerEntity.moveInputAction.Value.ReadValue<Vector2>(),
                new ControllerActionInputStatus
                {
                    isPressedThisFrame = playerControllerEntity.moveInputAction.Value.WasPressedThisFrame(),
                    isHold = playerControllerEntity.moveInputAction.Value.IsPressed(),
                    isReleasedThisFrame = playerControllerEntity.moveInputAction.Value.WasReleasedThisFrame()
                });
            
            controllerActionEntity.ReplaceJumpControllerAction(
                new ControllerActionInputStatus
                {
                    isPressedThisFrame = playerControllerEntity.jumpInputAction.Value.WasPressedThisFrame(),
                    isHold = playerControllerEntity.jumpInputAction.Value.IsPressed(),
                    isReleasedThisFrame = playerControllerEntity.jumpInputAction.Value.WasReleasedThisFrame()
                });
            
            controllerActionEntity.ReplaceRunControllerAction(
                new ControllerActionInputStatus
                {
                    isPressedThisFrame = playerControllerEntity.runInputAction.Value.WasPressedThisFrame(),
                    isHold = playerControllerEntity.runInputAction.Value.IsPressed(),
                    isReleasedThisFrame = playerControllerEntity.runInputAction.Value.WasReleasedThisFrame()
                });
        }
    }
}