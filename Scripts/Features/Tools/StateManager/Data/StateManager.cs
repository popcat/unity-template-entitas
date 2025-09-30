using System;
using Entitas;

namespace BartekNizio.Unity.Template.Entitas
{
	public class StateManager
	{
		private readonly Action<Entity, object> _setStateAction;
		public Entity Entity { get; private set; }

		public StateManager(Entity entity,  Action<Entity, object> setState)
		{
			Entity = entity;
			_setStateAction = setState;
		}

		public void SetState<T>(T state)
		{
			_setStateAction.Invoke(Entity, state);
			DebugLogger.Log($"New state: {state}");
		}

		public void RequestState<T>(T state)
		{
			if (Entity is GameEntity) {
				((GameEntity)Entity).AddNextStateRequest(state);
			}
			else if (Entity is MetaEntity) {
				((MetaEntity)Entity).AddNextStateRequest(state);
			}
			else {
				throw new Exception();
			}
		}
	}
}