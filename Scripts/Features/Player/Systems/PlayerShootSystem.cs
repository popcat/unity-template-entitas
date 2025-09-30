using Entitas;
using UnityEngine;
using Zenject;

namespace BartekNizio.Unity.Template.Entitas
{
    public class PlayerShootSystem : IExecuteSystem
    {
        [Inject]
        private readonly InputConfig _inputConfig;
        private readonly Contexts _contexts;

        public PlayerShootSystem(Contexts contexts)
        {
            _contexts = contexts;
        }
        
        public void Execute()
        {
            if(_contexts.game.isPlayerU == false) return;
            if(_inputConfig.interactInputAction.IsPressed() == false) return;
            
            
            var player = _contexts.game.playerUEntity;
        
          
        }
    }
}