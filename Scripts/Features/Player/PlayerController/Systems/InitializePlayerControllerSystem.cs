using Entitas;
using Zenject;

namespace BartekNizio.Unity.Template.Entitas
{
	public class InitializePlayerControllerSystem : IInitializeSystem
	{
		private readonly Contexts _contexts;

		[Inject]
		private PlayerControllerConfig _playerControllerConfig;

		public InitializePlayerControllerSystem(Contexts contexts) {
			_contexts = contexts;
		}

		public void Initialize() {
			var inputEntity = _contexts.input.CreateEntity();
			inputEntity.isPlayerControllerU = true;
			var map = _playerControllerConfig.Input;

			var move = map.FindAction("Move").Clone();
			move.Enable();
			inputEntity.AddMoveInputAction(move);

			var jump = map.FindAction("Jump").Clone();
			jump.Enable();
			inputEntity.AddJumpInputAction(jump);

			var run = map.FindAction("Run").Clone();
			run.Enable();
			inputEntity.AddRunInputAction(run);
		}
	}
}