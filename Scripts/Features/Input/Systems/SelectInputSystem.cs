using Entitas;
using UnityEngine;
using Zenject;

namespace BartekNizio.Unity.Template.Entitas
{
	public class SelectInputSystem : IExecuteSystem
	{
		private readonly Contexts _contexts;

		[Inject]
		private InputConfig _inputConfig;

		public SelectInputSystem(Contexts contexts) {
			_contexts = contexts;
		}

		public void Execute() {
			var selectInputAction = _inputConfig.selectInputAction;
			if (selectInputAction.WasCompletedThisFrame() && !_contexts.input.hasDragInput) {
				var screenPosition = _inputConfig.cursorPositionInputAction.ReadValue<Vector2>();
				_contexts.input.CreateEntity().AddSelectInput(screenPosition);
				//Debug.Log($"SELECT");
			}
		}
	}
}