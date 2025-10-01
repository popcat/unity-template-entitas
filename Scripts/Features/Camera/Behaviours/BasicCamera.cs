using UnityEngine;

namespace BartekNizio.Unity.Template.Entitas.Behaviours
{
    public class BasicCamera : ObjectEntityComponent
    {
        public bool isMainCamera;

        public override void AddComponent(GameObjectEntity objectEntity)
        {
            objectEntity.Entity.AddCamera(GetComponent<Camera>());
            objectEntity.Entity.isMainCamera = isMainCamera;
        }

        public override void AddComponent(MetaObjectEntity objectEntity)
        {
            objectEntity.Entity.AddCamera(GetComponent<Camera>());
            objectEntity.Entity.isMainCamera = isMainCamera;
        }
    }
}