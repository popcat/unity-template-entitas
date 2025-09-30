using System.Collections.Generic;
using Entitas;

namespace BartekNizio.Unity.Template.Entitas
{
    public abstract class ALevelStateReactiveSystem : ReactiveSystem<MetaEntity>
    {
        protected readonly Contexts _contexts;

        public ALevelStateReactiveSystem(Contexts contexts) : base(contexts.meta)
        {
            _contexts = contexts;
        }

        protected override ICollector<MetaEntity> GetTrigger(IContext<MetaEntity> context)
        {
            return context.CreateCollector(MetaMatcher.LevelState);
        }

        protected override bool Filter(MetaEntity entity)
        {
            return entity.hasLevelState;
        }

        protected override void Execute(List<MetaEntity> entities)
        {
            OnLevelState(_contexts.meta.levelState.value);
        }

        protected abstract void OnLevelState(LevelState state);
    }
}