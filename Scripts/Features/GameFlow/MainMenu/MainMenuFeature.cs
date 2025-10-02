namespace BartekNizio.Unity.Template.Entitas
{
    public class MainMenuFeature : InjectableFeature
    {
        public MainMenuFeature(Contexts contexts)
        {
            Add(new MainMenuInitializationSystem(contexts));
        }
    }
}