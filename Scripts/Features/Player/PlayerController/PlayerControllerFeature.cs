namespace BartekNizio.Unity.Template.Entitas
{
	public class PlayerControllerFeature : InjectableFeature
	{
		public PlayerControllerFeature(Contexts contexts) {
			Add(new InitializePlayerControllerSystem(contexts));
			Add(new PlayerControllerInputSystem(contexts));
		}
	}
}