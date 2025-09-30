using System.Collections.Generic;
using Entitas;

namespace BartekNizio.Unity.Template.Entitas
{
    public class PreviousVelocitySystem : IExecuteSystem
    {
        private readonly Contexts _contexts;
        private readonly IGroup<GameEntity> _rbGroup;
        private readonly List<GameEntity> _rbCache;

        public PreviousVelocitySystem(Contexts contexts)
        {
            _contexts = contexts;
            _rbGroup = _contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Rigidbody)); 
            _rbCache = new List<GameEntity>();
        }
        
        public void Execute()
        {
            foreach (var rbEntity in _rbGroup.GetEntities(_rbCache))
            {
                rbEntity.ReplacePreviousVelocity(rbEntity.rigidbody.Instance.linearVelocity);
            }
        }
    }
}