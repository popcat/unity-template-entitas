using Entitas;
using UnityEngine;

namespace BartekNizio.Unity.Template.Entitas
{
    [Game]
    public class CameraOrientationComponent : IComponent, IGameObjectEntityComponent
    {
        public int orientationIndex;

        public void AddComponent(Contexts contexts, GameConfiguration gameConfig, GameObjectEntity goe)
        {
            goe.Entity.AddCameraOrientation(0);
        }
    }
}