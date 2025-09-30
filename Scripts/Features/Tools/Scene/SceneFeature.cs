namespace BartekNizio.Unity.Template.Entitas
{
	public class SceneFeature : InjectableFeature
	{
		public SceneFeature(Contexts contexts)
		{
			Add(new UnloadSceneSystem(contexts));
			Add(new LoadSceneSystem(contexts));
			Add(new WaitForSceneUnloadCompletedSystem(contexts));
			Add(new WaitForSceneLoadCompletedSystem(contexts));
		}
		
	}
}