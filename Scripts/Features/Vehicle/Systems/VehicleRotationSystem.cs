using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace BartekNizio.Unity.Template.Entitas
{
    public class VehicleRotationSystem : IExecuteSystem
    {
        private readonly Contexts _contexts;
        private readonly IGroup<GameEntity> _vehicleGroup;
        private readonly List<GameEntity> _vehicleCache;

        public VehicleRotationSystem(Contexts contexts)
        {
            _contexts = contexts;
            _vehicleGroup = _contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Vehicle)); 
            _vehicleCache = new List<GameEntity>();
        }
        
        public void Execute()
        {
            foreach (var vehicleEntity in _vehicleGroup.GetEntities(_vehicleCache))
            {
                if(vehicleEntity.hasVehicleLookRotation == false) continue;
                
                var rotationSpeed = vehicleEntity.vehicle.config.rotationSpeed * Time.fixedDeltaTime;
                vehicleEntity.vehicle.dirPivot.rotation = Quaternion.Slerp(vehicleEntity.vehicle.dirPivot.rotation, vehicleEntity.vehicleLookRotation.value, rotationSpeed);
            }
        }
    }
}