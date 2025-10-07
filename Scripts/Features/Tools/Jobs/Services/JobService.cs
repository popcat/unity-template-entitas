using System;
using Unity.Jobs;
using Zenject;

namespace BartekNizio.Unity.Template.Entitas
{
	public class JobService
	{
		[Inject]
		private readonly Contexts _contexts;

		public void ScheduleJob(JobHandle handle, Action onCompleted) {
			var e = _contexts.game.CreateEntity();
			e.AddJobDependencyHandle(handle, onCompleted);
		}
	}
}