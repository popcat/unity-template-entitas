namespace BartekNizio.Unity.Template.Entitas.Platformer2D
{
    public class CharacterControllerFeature : InjectableFeature
    {
        public CharacterControllerFeature(Contexts contexts)
        {
            Add(new CharacterControllerSystem(contexts));
        }
    }
}