using System.Collections.Generic;
using Entitas;
using Unity.Mathematics;
using UnityEngine;

namespace BartekNizio.Unity.Template.Entitas
{
    public class VehicleMovementSystem : IExecuteSystem
    {
        private readonly Contexts _contexts; 
        private readonly IGroup<GameEntity> _vehicleGroup;
        private readonly List<GameEntity> _vehicleCache;

        public VehicleMovementSystem(Contexts contexts)
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
                
                var rb = vehicleEntity.rigidbody.Instance;
                var vehicleConfig = vehicleEntity.vehicle.config;

                var power = vehicleEntity.vehicleMovementPower.value * vehicleConfig.acceleration;
                var velocityToAdd = vehicleEntity.vehicleMovementDirection.worldDirection * power * Time.fixedDeltaTime;
               
                var linearVelocity= rb.linearVelocity;
                linearVelocity += velocityToAdd;
                
                var speed = linearVelocity.magnitude;
                speed = math.clamp(speed, -vehicleConfig.maxSpeed, vehicleConfig.maxSpeed);
                
                linearVelocity = linearVelocity.normalized * speed;
                rb.linearVelocity = linearVelocity; 
                
                rb.linearDamping = vehicleConfig.drag;
            }
        }
    }
}