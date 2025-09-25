namespace BartekNizio.Unity.Template.Entitas
{
	public class UpdateSystem : InjectableFeature
	{
		public UpdateSystem(Contexts contexts)
		{
			//System Features goes there...
			
			
			//Event System...
			Add(new InputEventSystems(contexts));
			Add(new UiEventSystems(contexts));
			Add(new GameEventSystems(contexts));
			Add(new MetaEventSystems(contexts));
		}
	}
}