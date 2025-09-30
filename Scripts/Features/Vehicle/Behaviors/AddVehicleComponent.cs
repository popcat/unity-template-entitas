using UnityEngine;

namespace BartekNizio.Unity.Template.Entitas
{
    public class AddVehicleComponent : MonoBehaviour, IGameObjectEntityComponent
    {
        public Transform dirPivot;
        public Transform accPivot;
        
        public void AddComponent(Contexts contexts, GameConfiguration gameConfig, GameObjectEntity goe)
        {
            goe.Entity.AddVehicle(null, dirPivot, accPivot);
        }
    }
}