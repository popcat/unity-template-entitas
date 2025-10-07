using Entitas;
using UnityEngine;
using Zenject;

namespace BartekNizio.Unity.Template.Entitas
{
	public class CursorInputSystem : IExecuteSystem
	{
		private readonly Contexts _contexts;

		[Inject]
		private InputConfig _inputConfig;

		public CursorInputSystem(Contexts contexts) {
			_contexts = contexts;
		}

		public void Execute() {
			var cursorInputAction = _inputConfig.cursorPositionInputAction;

			if (_contexts.input.hasCursorInput == false) {
				_contexts.input.CreateEntity().AddCursorInput(cursorInputAction.ReadValue<Vector2>());
			}
			else {
				_contexts.input.ReplaceCursorInput(cursorInputAction.ReadValue<Vector2>());
			}
		}
	}
}