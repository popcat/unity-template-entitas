namespace BartekNizio.Unity.Template.Entitas
{
	public class InputFeature : InjectableFeature
	{
		public InputFeature(Contexts contexts) {
			Add(new CursorInputSystem(contexts));
			Add(new EnableInputSystem(contexts));
			Add(new SelectInputSystem(contexts));
			Add(new InteractionInputSystem(contexts));
			Add(new DragInputSystem(contexts));
		}
	}
}