using System.Collections.Generic;
using Entitas;

namespace BartekNizio.Unity.Template.Entitas
{
	public class UpdateStateManagerMetaSystem : ReactiveSystem<MetaEntity>
	{
		private readonly Contexts _contexts;

		public UpdateStateManagerMetaSystem(Contexts contexts) : base(contexts.meta)
		{
			_contexts = contexts;
		}

		protected override ICollector<MetaEntity> GetTrigger(IContext<MetaEntity> context)
		{
			return context.CreateCollector(MetaMatcher.NextStateRequest);
		}

		protected override bool Filter(MetaEntity entity)
		{
			return entity.hasNextStateRequest;
		}

		protected override void Execute(List<MetaEntity> entities)
		{
			foreach (var stateManagerEntity in entities) {
				stateManagerEntity.stateManager.instance.SetState(stateManagerEntity.nextStateRequest.state);
				stateManagerEntity.RemoveNextStateRequest();
			}
		}
	}
}