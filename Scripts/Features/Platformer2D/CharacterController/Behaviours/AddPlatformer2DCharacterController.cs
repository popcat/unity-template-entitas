using UnityEngine;

namespace BartekNizio.Unity.Template.Entitas.Platformer2D
{
	public class AddPlatformer2DCharacterController : ObjectEntityComponent
	{
		[SerializeField]
		private Character2DPlatformerController _config;

		[SerializeField]
		private Collider2D _bodyCollider;

		[SerializeField]
		private Collider2D _feetCollider;

		public override void AddComponent(GameObjectEntity objectEntity) {
			objectEntity.Entity.isPlayerU = true;

			var controllerData = new CharacterControllerData {
				IsFacingRight = true
			};

			var controllerSpecs = _config.Specifications;
			controllerSpecs.BodyCollider = _bodyCollider;
			controllerSpecs.FeetCollider = _feetCollider;

			objectEntity.Entity.AddPlatformer2DCharacterController(controllerData, controllerSpecs);


			objectEntity.Entity.AddControllerAction(objectEntity.Contexts.game.CreateEntity());
			var actionEntity = objectEntity.Entity.controllerAction.Entity;
			actionEntity.AddMoveControllerAction(new InputActionStatus(), Vector2.zero);
			actionEntity.AddRunControllerAction(new InputActionStatus());
			actionEntity.AddJumpControllerAction(new InputActionStatus());
		}

		public override void AddComponent(MetaObjectEntity objectEntity) { }
	}
}