using System;
using Entitas;

namespace BartekNizio.Unity.Template.Entitas
{
	public class SystemSequencePart
	{
		private readonly string _name;
		private readonly Action<Contexts> _startSequence;
		private readonly Func<Contexts, Entity ,bool> _endSequence;
		private readonly Entity _entity;
		private readonly Contexts _contexts;

		public SystemSequencePart(Contexts contexts, Action<Contexts> start, Func<Contexts, Entity ,bool> end, string name = "", Entity entity = null)
		{
			_name = name;
			_entity = entity;
			_startSequence = start;
			_endSequence = end;
			_contexts = contexts;
		}

		public void Invoke()
		{
			_startSequence?.Invoke(_contexts);
		}

		public bool IsCompleted()
		{
			if (_endSequence == null) return false;
			return (_endSequence?.Invoke(_contexts, _entity)).Value;
		}

		public string Name()
		{
			return _name;
		}
	}
}