namespace BartekNizio.Unity.Template.Entitas
{
	public class StateManagerFeature : InjectableFeature
	{
		public StateManagerFeature(Contexts contexts) {
			Add(new UpdateStateManagerMetaSystem(contexts));
			Add(new UpdateStateManagerGameSystem(contexts));
		}
	}
}