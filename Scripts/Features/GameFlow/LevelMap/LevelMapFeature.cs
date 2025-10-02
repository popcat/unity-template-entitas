namespace BartekNizio.Unity.Template.Entitas
{
	public class LevelMapFeature : InjectableFeature
	{
		public LevelMapFeature(Contexts contexts)
		{
			Add(new LevelMapInitializationSystem(contexts));
		}
	}
}