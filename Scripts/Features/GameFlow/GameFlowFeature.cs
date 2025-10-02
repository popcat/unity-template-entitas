namespace BartekNizio.Unity.Template.Entitas
{
	public class GameFlowFeature : InjectableFeature
	{
		public GameFlowFeature(Contexts contexts)
		{
			Add(new GameStateFeature(contexts));
			Add(new LevelStateFeature(contexts));
			Add(new MainMenuFeature(contexts));
			Add(new LevelMapFeature(contexts));
			Add(new LevelFeature(contexts));
		}
	}
}