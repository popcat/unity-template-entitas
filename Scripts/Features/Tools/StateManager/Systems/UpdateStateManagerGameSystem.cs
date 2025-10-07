using System.Collections.Generic;
using Entitas;

namespace BartekNizio.Unity.Template.Entitas
{
	public class UpdateStateManagerGameSystem : ReactiveSystem<GameEntity>
	{
		private readonly Contexts _contexts;

		public UpdateStateManagerGameSystem(Contexts contexts) : base(contexts.game) {
			_contexts = contexts;
		}

		protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) {
			return context.CreateCollector(GameMatcher.NextStateRequest);
		}

		protected override bool Filter(GameEntity entity) {
			return entity.hasNextStateRequest;
		}

		protected override void Execute(List<GameEntity> entities) {
			foreach (var stateManagerEntity in entities) {
				stateManagerEntity.stateManager.instance.SetState(stateManagerEntity.nextStateRequest.state);
				stateManagerEntity.RemoveNextStateRequest();
			}
		}
	}
}