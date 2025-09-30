using Entitas;
using UnityEngine;
using Zenject;

namespace BartekNizio.Unity.Template.Entitas
{
    public class PlayerControllerSystem : IExecuteSystem
    {
        [Inject]
        private readonly InputConfig _inputConfig;
        private readonly Contexts _contexts;

        public PlayerControllerSystem(Contexts contexts)
        {
            _contexts = contexts;
        }
        
        public void Execute()
        {
            if(_contexts.game.isPlayerU == false) return;
            
            var player = _contexts.game.playerUEntity;
            var localDir = _inputConfig.playerMovementInputAction.ReadValue<Vector2>().normalized;
            var worldDir = new Vector3(localDir.x, 0, localDir.y);
            player.ReplaceVehicleMovementDirection(localDir, worldDir);
            player.ReplaceVehicleMovementPower(1);


            var playerPos = _contexts.game.mainCamera.instance.WorldToScreenPoint(player.transform.instance.position);
            var cursorPos = _inputConfig.cursorPositionInputAction.ReadValue<Vector2>();
            var lookDir = new Vector3(cursorPos.x, 0, cursorPos.y) - new Vector3(playerPos.x, 0, playerPos.y);
            var lookRotation = Quaternion.LookRotation(lookDir);
            player.ReplaceVehicleLookRotation(lookRotation);
        }
    }
}