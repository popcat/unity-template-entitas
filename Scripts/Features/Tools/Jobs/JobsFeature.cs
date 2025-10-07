namespace BartekNizio.Unity.Template.Entitas
{
	public class JobsFeature : InjectableFeature
	{
		public JobsFeature(Contexts contexts) {
			Add(new DetectJobHandleCompletionSystem(contexts));
		}
	}
}