using System.Collections.Generic;
using Entitas;

namespace BartekNizio.Unity.Template.Entitas
{
    public class DetectCurrentLevelSystem : ReactiveSystem<MetaEntity>
    {
        private readonly Contexts _contexts;
        
        public DetectCurrentLevelSystem(Contexts contexts) : base(contexts.meta)
        {
            _contexts = contexts;
        }

        protected override ICollector<MetaEntity> GetTrigger(IContext<MetaEntity> context)
        {
            return context.CreateCollector(MetaMatcher.GameState);
        }

        protected override bool Filter(MetaEntity entity)
        {
            return entity.hasGameState;
        }

        protected override void Execute(List<MetaEntity> entities)
        {
            if(_contexts.meta.gameState.Current != GameState.Level) return;
            //load game from save
            //...
            
            //...or
            //start from begining
            var levelEntity = _contexts.meta.levelMap.LevelGraph.StartNode.Value;
            levelEntity.isCurrentLevel = true;
        }
    }
}