using UnityEngine;
using Zenject;

namespace BartekNizio.Unity.Template.Entitas
{
    public class PlayerSpawnSystem : ALevelStateReactiveSystem
    {
        [Inject] private readonly VehicleFactory _vehicleFactory;
        [Inject] private readonly PlayerConfig _playerConfig;
        
        public PlayerSpawnSystem(Contexts contexts) : base(contexts)
        { }

        protected override void OnLevelState(LevelState state)
        {
            if(state != LevelState.Gameplay) return;
            
            var vehicle = _vehicleFactory.Build(_playerConfig.spawnPosition, Quaternion.identity, _playerConfig.vehicleConfig);
            var goe = vehicle.GetComponent<GameObjectEntity>();
            goe.Entity.isPlayer = true;
        }
    }
}