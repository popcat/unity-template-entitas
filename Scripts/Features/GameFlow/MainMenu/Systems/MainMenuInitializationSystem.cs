namespace BartekNizio.Unity.Template.Entitas
{
	public class MainMenuInitializationSystem : AGameStateReactiveSystem
	{
		public MainMenuInitializationSystem(Contexts contexts) : base(contexts) { }

		protected override void OnGameState(GameState current, GameState previous) {
			if (current != GameState.None) {
				return;
			}

			_contexts.meta.gameStateEntity.stateManager.instance.RequestState(GameState.MainMenu);
		}
	}
}