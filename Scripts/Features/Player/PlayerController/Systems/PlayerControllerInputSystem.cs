using Entitas;
using UnityEngine;

namespace BartekNizio.Unity.Template.Entitas
{
	public class PlayerControllerInputSystem : IExecuteSystem
	{
		private readonly Contexts _contexts;

		public PlayerControllerInputSystem(Contexts contexts) {
			_contexts = contexts;
		}

		public void Execute() {
			if (_contexts.input.isPlayerControllerU == false) {
				return;
			}

			if (_contexts.game.isPlayerU == false) {
				return;
			}

			var playerEntity = _contexts.game.playerUEntity;
			if (playerEntity.hasControllerAction == false) {
				Debug.LogError("Player doesn't have ControllerActionComponent");
				return;
			}

			var playerControllerEntity = _contexts.input.playerControllerUEntity;
			var controllerActionEntity = playerEntity.controllerAction.Entity;

			controllerActionEntity.ReplaceMoveControllerAction(
				new InputActionStatus {
					isActivatedThisFrame = playerControllerEntity.moveInputAction.Value.WasPressedThisFrame(),
					isActive = playerControllerEntity.moveInputAction.Value.IsPressed(),
					isDeactivatedThisFrame = playerControllerEntity.moveInputAction.Value.WasReleasedThisFrame()
				},
				playerControllerEntity.moveInputAction.Value.ReadValue<Vector2>());

			controllerActionEntity.ReplaceJumpControllerAction(
				new InputActionStatus {
					isActivatedThisFrame = playerControllerEntity.jumpInputAction.Value.WasPressedThisFrame(),
					isActive = playerControllerEntity.jumpInputAction.Value.IsPressed(),
					isDeactivatedThisFrame = playerControllerEntity.jumpInputAction.Value.WasReleasedThisFrame()
				});

			controllerActionEntity.ReplaceRunControllerAction(
				new InputActionStatus {
					isActivatedThisFrame = playerControllerEntity.runInputAction.Value.WasPressedThisFrame(),
					isActive = playerControllerEntity.runInputAction.Value.IsPressed(),
					isDeactivatedThisFrame = playerControllerEntity.runInputAction.Value.WasReleasedThisFrame()
				});
		}
	}
}