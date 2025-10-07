/*using Entitas;

namespace BartekNizio.Unity.Template.Entitas
{
	public class StateManagerService<T>
	{
		public StateManager CreateStateManager(GameEntity entity, T state)
		{
			var sm = new StateManager(entity, state);
			entity.AddStateManager(sm);
			return sm;
		}

		public StateManager CreateStateManager(MetaEntity entity, T state)
		{
			var sm = new StateManager(entity, state);
			entity.AddStateManager(sm);
			return sm;
		}

		public void SetState(GameEntity entity, T state)
		{
			entity.stateManager.instance.SetState(state);
		}

		public void SetState(MetaEntity entity, T state)
		{
			entity.stateManager.instance.SetState(state);
		}
	}
}*/

