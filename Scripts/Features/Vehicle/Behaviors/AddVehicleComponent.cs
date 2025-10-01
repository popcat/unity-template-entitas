using UnityEngine;

namespace BartekNizio.Unity.Template.Entitas
{
    public class AddVehicleComponent : MonoBehaviour, IObjectEntityComponent
    {
        public Transform dirPivot;
        public Transform accPivot;

        public void AddComponent(GameObjectEntity objectEntity)
        {
            objectEntity.Entity.AddVehicle(null, dirPivot, accPivot);
        }

        public void AddComponent(MetaObjectEntity objectEntity)
        {
            throw new System.NotImplementedException();
        }
    }
}