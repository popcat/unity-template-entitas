namespace BartekNizio.Unity.Template.Entitas
{
    public class PlayerFeature : InjectableFeature
    {
        public PlayerFeature(Contexts contexts)
        {
            Add(new PlayerSpawnSystem(contexts));
            Add(new PlayerControllerSystem(contexts));
            Add(new PlayerShootSystem(contexts));
        }
    }
}