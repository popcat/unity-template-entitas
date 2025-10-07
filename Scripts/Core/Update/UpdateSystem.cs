namespace BartekNizio.Unity.Template.Entitas
{
	public class UpdateSystem : InjectableFeature
	{
		public UpdateSystem(Contexts contexts) {
			Add(new UpdateFeatures(contexts));

			//Event System...
			Add(new InputEventSystems(contexts));
			Add(new UiEventSystems(contexts));
			Add(new GameEventSystems(contexts));
			Add(new MetaEventSystems(contexts));

			//Cleanup
			Add(new GameCleanupSystems(contexts));
			Add(new MetaCleanupSystems(contexts));
			Add(new InputCleanupSystems(contexts));
		}
	}
}