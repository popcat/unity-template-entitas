namespace BartekNizio.Unity.Template.Entitas
{
	public class GameFlowFeature : InjectableFeature
	{
		public GameFlowFeature(Contexts contexts)
		{
			Add(new GameStateFeature(contexts));
			Add(new LevelStateFeature(contexts));
			Add(new LevelMapFeature(contexts));
		}
	}
}