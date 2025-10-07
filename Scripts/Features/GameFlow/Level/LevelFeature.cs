namespace BartekNizio.Unity.Template.Entitas
{
	public class LevelFeature : InjectableFeature
	{
		public LevelFeature(Contexts contexts) {
			Add(new DetectCurrentLevelSystem(contexts));
			Add(new LevelGenerationSystem(contexts));
		}
	}
}