using Entitas;
using UnityEngine;
using Zenject;

namespace BartekNizio.Unity.Template.Entitas
{
	public class DragInputSystem : IExecuteSystem
	{
		private readonly Contexts _contexts;

		[Inject]
		private InputConfig _inputConfig;

		public DragInputSystem(Contexts contexts) {
			_contexts = contexts;
		}

		public void Execute() {
			var dragInputAction = _inputConfig.dragInputAction;
			var selectInputAction = _inputConfig.selectInputAction;

			if (selectInputAction.IsPressed() && dragInputAction.IsInProgress() && !_contexts.input.hasDragInput) {
				var drag = dragInputAction.ReadValue<Vector2>();
				if (drag.sqrMagnitude < _inputConfig.dragThreshold * _inputConfig.dragThreshold) {
					//Debug.Log($"NOT INITIALIZED");
					return;
				}

				_contexts.input.CreateEntity().AddDragInput(drag, DragState.Begin);
				//Debug.Log($"BEGIN {drag}");
			}
			else if (selectInputAction.IsPressed() && _contexts.input.hasDragInput) {
				var drag = dragInputAction.ReadValue<Vector2>();
				_contexts.input.ReplaceDragInput(drag, DragState.Continue);
				//Debug.Log($"CONT {drag}");
			}
			else if (selectInputAction.WasCompletedThisFrame() && _contexts.input.hasDragInput) {
				var drag = dragInputAction.ReadValue<Vector2>();
				_contexts.input.ReplaceDragInput(drag, DragState.End);
				//Debug.Log($"END {drag}");
			}
			else {
				if (_contexts.input.hasDragInput) {
					_contexts.input.RemoveDragInput();
					//Debug.Log($"REMOVE");
				}
			}
		}
	}
}