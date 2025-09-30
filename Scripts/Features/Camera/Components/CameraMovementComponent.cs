using Entitas;
using UnityEngine;

namespace BartekNizio.Unity.Template.Entitas
{
    [Game]
    public class CameraMovementComponent : IComponent, IGameObjectEntityComponent
    {
        public Vector3 targetPosition;
        
        public void AddComponent(Contexts contexts, GameConfiguration gameConfig, GameObjectEntity goe)
        {
            goe.Entity.AddCameraMovement(goe.transform.parent.position);
        }
    }
}