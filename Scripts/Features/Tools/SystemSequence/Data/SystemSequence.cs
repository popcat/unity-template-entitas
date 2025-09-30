using System;
using System.Collections.Generic;
using Entitas;

namespace BartekNizio.Unity.Template.Entitas
{
	public class SystemSequence
	{
		public SystemSequenceState State { get; private set; } = SystemSequenceState.Pending;
		public int SequenceIndex { get; private set; } = 0;
		public readonly List<SystemSequencePart> Sequence;

		private readonly Contexts _contexts;
		private readonly MetaEntity _systemEntity;
		private event Action<Contexts> OnCompleted;

		public SystemSequence(Contexts contexts)
		{
			_contexts = contexts;
			Sequence = new List<SystemSequencePart>();
			_systemEntity = _contexts.meta.CreateEntity();
			_systemEntity.AddSystemSequence(this);
		}

		public void Start()
		{
			State = SystemSequenceState.Running;
			SequenceIndex = 0;
			PlaySequencePart();
		}

		public void Add(int componentIndex, IComponent component, Entity broadcastEntity, string name = "")
		{
			Sequence.Add(new SystemSequencePart(
				_contexts,
				(c) => {broadcastEntity.AddComponent(componentIndex, component);},
				(c,e) => !e.HasComponent(componentIndex), 
				name, 
				broadcastEntity));
		}

		public void Add(Action<Contexts> start, Func<Contexts, Entity, bool> end, string name = "")
		{
			Sequence.Add(new SystemSequencePart(_contexts, start, end, name));
		}

		public void Add(SystemSequence systemSequence)
		{
			if (systemSequence.State != SystemSequenceState.Pending) {
				return;
			}
			
			Sequence.AddRange(systemSequence.Sequence);
			systemSequence.Abort();
		}

		public void AddOnCompleted(Action<Contexts> action)
		{
			OnCompleted += action;
		}

		public bool Update()
		{
			if(State == SystemSequenceState.Completed) return false;
			
			if(Sequence[SequenceIndex].IsCompleted() == false) return true;
			SequenceIndex++;

			if (SequenceIndex >= Sequence.Count) {
				Complete();
				return false;
			}

			PlaySequencePart();
			return true;
		}

		public void Abort()
		{
			_systemEntity.Destroy();
			OnCompleted = null;
		}

		private void PlaySequencePart()
		{
			Sequence[SequenceIndex].Invoke();
		}

		private void Complete()
		{
			OnCompleted?.Invoke(_contexts);
			State = SystemSequenceState.Completed;
		}
	}
}