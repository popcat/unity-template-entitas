using Entitas;
using UnityEngine;
using Zenject;

namespace BartekNizio.Unity.Template.Entitas.Platformer2D
{
	public class CharacterControllerSystem : IExecuteSystem
	{
		private readonly Contexts _contexts;

		[Inject]
		private readonly InputConfig _inputConfig;

		public CharacterControllerSystem(Contexts contexts) {
			_contexts = contexts;
		}

		public void Execute() {
			if (_contexts.game.hasPlatformer2DCharacterController == false) {
				return;
			}

			var controllerEntity = _contexts.game.platformer2DCharacterControllerEntity;
			var controllerSpecs = controllerEntity.platformer2DCharacterController.ControllerSpecs;
			var controllerData = controllerEntity.platformer2DCharacterController.ControllerData;
			var actionsEntity = controllerEntity.controllerAction.Entity;
			var rb = controllerEntity.rigidbody2D.Instance;
			var transform = controllerEntity.transform.Instance;

			CollisionCheck();
			if (controllerData.IsGrounded) {
				Move(controllerSpecs.GroundAcceleration, controllerSpecs.GroundDeceleration, actionsEntity.moveControllerAction.Value);
			}
			else {
				Move(controllerSpecs.AirAcceleration, controllerSpecs.AirDeceleration, actionsEntity.moveControllerAction.Value);
			}

			controllerEntity.platformer2DCharacterController.ControllerData = controllerData;

			#region Movement

			void Move(float acceleration, float deceleration, Vector2 moveInput) {
				var moveVelocity = controllerData.MoveVelocity;
				if (moveInput != Vector2.zero) {
					var targetVelocity = new Vector2(moveInput.x, 0) * (actionsEntity.runControllerAction.Status.isActive
						? controllerSpecs.MaxRunSpeed
						: controllerSpecs.MaxWalkSpeed);
					moveVelocity = Vector2.Lerp(moveVelocity, targetVelocity, acceleration * Time.fixedDeltaTime);
					rb.linearVelocity = new Vector2(moveVelocity.x, rb.linearVelocity.y);
				}
				else {
					moveVelocity = Vector2.Lerp(moveVelocity, Vector2.zero, deceleration * Time.fixedDeltaTime);
					rb.linearVelocity = new Vector2(moveVelocity.x, rb.linearVelocity.y);
				}
			}

			void TurnCheck(Vector2 moveInput) {
				if (controllerData.IsFacingRight && moveInput.x < 0) {
					Turn(false);
				}
				else if (!controllerData.IsFacingRight && moveInput.x > 0) {
					Turn(true);
				}
			}

			void Turn(bool turnRight) {
				if (turnRight) {
					controllerData.IsFacingRight = true;
					transform.Rotate(0f, 180f, 0f);
				}
				else {
					controllerData.IsFacingRight = false;
					transform.Rotate(0f, -180f, 0f);
				}
			}

			#endregion

			#region Collision

			void IsGrounded() {
				var boxCastOrigin = new Vector2(controllerSpecs.FeetCollider.bounds.center.x, controllerSpecs.FeetCollider.bounds.min.y);
				var boxCastSize = new Vector2(controllerSpecs.FeetCollider.bounds.size.x, controllerSpecs.GroundCheckDistance);
				controllerData.GroundHit = Physics2D.BoxCast(boxCastOrigin, boxCastSize, 0f, Vector2.down,
					controllerSpecs.GroundCheckDistance, controllerSpecs.GroundLayer);
				controllerData.IsGrounded = controllerData.GroundHit.collider != null;
			}

			void CollisionCheck() {
				IsGrounded();
			}

			#endregion
		}
	}
}