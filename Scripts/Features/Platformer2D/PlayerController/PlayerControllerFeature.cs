namespace BartekNizio.Unity.Template.Entitas.Platformer2D
{
    public class PlayerControllerFeature : InjectableFeature
    {
        public PlayerControllerFeature(Contexts contexts)
        {
            Add(new InitializePlayerControllerSystem(contexts));
            Add(new PlayerControllerInputSystem(contexts));
        }
    }
}