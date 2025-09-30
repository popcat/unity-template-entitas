using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace BartekNizio.Unity.Template.Entitas
{
    public class VehicleWobbleSystem : IExecuteSystem
    {
        private readonly Contexts _contexts;
        private readonly IGroup<GameEntity> _vehicleGroup;
        private readonly List<GameEntity> _vehicleCache;

        public VehicleWobbleSystem(Contexts contexts)
        {
            _contexts = contexts;
            _vehicleGroup = _contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Vehicle)); 
            _vehicleCache = new List<GameEntity>();
        }
        
        public void Execute()
        {
            foreach (var vehicleEntity in _vehicleGroup.GetEntities(_vehicleCache))
            {
                if(vehicleEntity.hasVehicleMovementPower == false) continue;
                if(vehicleEntity.hasVehicleMovementDirection == false) continue;

                var vConfig = vehicleEntity.vehicle.config;
                var movementDir = vehicleEntity.vehicleMovementDirection.worldDirection;
                
                var cross = Vector3.Cross(Vector3.up, movementDir);
                var localCross = Quaternion.Inverse(vehicleEntity.vehicle.dirPivot.rotation) * cross;
                
                var angle = vConfig.wobbleRotationAngle;
                var targetRot = Quaternion.AngleAxis(angle, localCross);
                var rotationSpeed = vConfig.wobbleRotationSpeed * Time.fixedDeltaTime;
                vehicleEntity.vehicle.accPivot.localRotation = Quaternion.Slerp(vehicleEntity.vehicle.accPivot.localRotation, targetRot, rotationSpeed);
            }
        }
    }
}