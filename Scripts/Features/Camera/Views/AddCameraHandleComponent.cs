using UnityEngine;

namespace BartekNizio.Unity.Template.Entitas
{
    public class AddCameraHandleComponent : MonoBehaviour, IGameObjectEntityComponent
    {
        public Transform cameraHandle;
        public Transform orientationHandle;

        public void AddComponent(Contexts contexts, GameConfiguration gameConfig, GameObjectEntity goe)
        {
            goe.Entity.AddCameraHandle(cameraHandle);
            goe.Entity.AddOrientationHandle(orientationHandle);
        }
    }
}