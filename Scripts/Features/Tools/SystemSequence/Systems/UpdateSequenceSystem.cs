using System.Collections.Generic;
using Entitas;

namespace BartekNizio.Unity.Template.Entitas
{
	public class UpdateSequenceSystem : IExecuteSystem
	{
		private readonly Contexts _contexts;
		private readonly List<MetaEntity> _sequenceCache;
		private readonly IGroup<MetaEntity> _sequenceGroup;

		public UpdateSequenceSystem(Contexts contexts) {
			_contexts = contexts;

			_sequenceGroup = contexts.meta.GetGroup(MetaMatcher.SystemSequence);
			_sequenceCache = new List<MetaEntity>();
		}

		public void Execute() {
			foreach (var sequenceEntity in _sequenceGroup.GetEntities(_sequenceCache)) {
				var isRunning = sequenceEntity.systemSequence.Instance.Update();
				if (!isRunning) {
					sequenceEntity.Destroy();
				}
			}
		}
	}
}