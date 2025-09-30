using System;
using Entitas;
using Unity.Jobs;

namespace BartekNizio.Unity.Template.Entitas
{
	[Game]
	public class JobDependencyHandleComponent : IComponent
	{
		public JobHandle instance;
		public Action onCompleted;
	}
}