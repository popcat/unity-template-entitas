using System.Collections.Generic;
using Entitas;

namespace BartekNizio.Unity.Template.Entitas
{
	public class DetectJobHandleCompletionSystem : IExecuteSystem
	{
		private readonly Contexts _contexts;
		private readonly IGroup<GameEntity> _jobGroup;
		private readonly List<GameEntity> _jobGroupCache = new();

		public DetectJobHandleCompletionSystem(Contexts contexts) {
			_contexts = contexts;
			_jobGroup = _contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.JobDependencyHandle)
				.NoneOf(GameMatcher.JobDependencyCompleted));
		}

		public void Execute() {
			foreach (var jobEntity in _jobGroup.GetEntities(_jobGroupCache)) {
				if (jobEntity.jobDependencyHandle.instance.IsCompleted) {
					jobEntity.jobDependencyHandle.instance.Complete();
					jobEntity.isJobDependencyCompleted = true;
					jobEntity.jobDependencyHandle.onCompleted?.Invoke();
				}
			}
		}
	}
}