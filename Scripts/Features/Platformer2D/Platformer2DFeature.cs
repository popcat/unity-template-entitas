namespace BartekNizio.Unity.Template.Entitas.Platformer2D
{
    public class Platformer2DFeature : InjectableFeature
    {
        public Platformer2DFeature(Contexts contexts)
        {
            Add(new PlayerControllerFeature(contexts));
            Add(new CharacterControllerFeature(contexts));
        }
    }
}