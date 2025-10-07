using Entitas;
using Zenject;

namespace BartekNizio.Unity.Template.Entitas
{
	public class EnableInputSystem : IInitializeSystem
	{
		private readonly Contexts _contexts;

		[Inject]
		private readonly InputConfig _inputConfig;

		public EnableInputSystem(Contexts contexts) {
			_contexts = contexts;
		}

		public void Initialize() {
			_inputConfig.selectInputAction.Enable();
			_inputConfig.interactInputAction.Enable();
			_inputConfig.dragInputAction.Enable();
			_inputConfig.cursorPositionInputAction.Enable();
			_inputConfig.moveCameraInputAction.Enable();
			_inputConfig.rotateCameraInputAction.Enable();
			_inputConfig.finishTurnInputAction.Enable();
			_inputConfig.playerMovementInputAction.Enable();
		}
	}
}