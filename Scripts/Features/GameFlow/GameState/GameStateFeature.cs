namespace BartekNizio.Unity.Template.Entitas
{
	public class GameStateFeature : InjectableFeature
	{
		public GameStateFeature(Contexts contexts) {
			Add(new GameStateInitializationSystem(contexts));
		}
	}
}