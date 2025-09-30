using UnityEngine;

namespace BartekNizio.Unity.Template.Entitas
{
    public class VehicleFactory
    {
        public GameObject Build(Vector3 position, Quaternion rotation, VehicleConfig config)
        {
            var vehicle = GameObject.Instantiate(config.vehiclePrefab, position, rotation);
            vehicle.GetComponent<Rigidbody>().linearDamping = config.drag;

            var goe = vehicle.GetComponent<GameObjectEntity>();
            goe.Entity.vehicle.config = config;
            
            return vehicle;
        }
    }
}