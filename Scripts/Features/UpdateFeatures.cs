namespace BartekNizio.Unity.Template.Entitas
{
	public class UpdateFeatures : InjectableFeature
	{
		public UpdateFeatures(Contexts contexts) {
			//System Features goes there...

			Add(new JobsFeature(contexts));
			Add(new StateManagerFeature(contexts));
			Add(new SceneFeature(contexts));
			Add(new ObjectPoolFeature(contexts));
			Add(new SystemSequenceFeature(contexts));

			Add(new GameFlowFeature(contexts));
			Add(new InputFeature(contexts));
			Add(new PlayerFeature(contexts));
			Add(new CameraFeature(contexts));
		}
	}
}