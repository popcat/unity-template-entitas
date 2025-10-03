using UnityEngine;

namespace BartekNizio.Unity.Template.Entitas.Platformer2D
{
    public class AddPlatformer2DCharacterController : ObjectEntityComponent
    {
        public override void AddComponent(GameObjectEntity objectEntity)
        {
            objectEntity.Entity.isPlayerU = true;
            objectEntity.Entity.AddCharacterController(new CharacterController());
            objectEntity.Entity.AddControllerAction(objectEntity.Contexts.game.CreateEntity());

            var actionEntity = (GameEntity)objectEntity.Entity.controllerAction.Entity;
            actionEntity.AddMoveControllerAction(Vector2.zero, new ControllerActionInputStatus());
        }

        public override void AddComponent(MetaObjectEntity objectEntity)
        {
            objectEntity.Entity.isPlayerU = true;
            objectEntity.Entity.AddCharacterController(new CharacterController());
            objectEntity.Entity.AddControllerAction(objectEntity.Contexts.meta.CreateEntity());

            var actionEntity = (MetaEntity)objectEntity.Entity.controllerAction.Entity;
            actionEntity.AddMoveControllerAction(Vector2.zero, new ControllerActionInputStatus());
        }
    }
}