namespace BartekNizio.Unity.Template.Entitas
{
    public class LevelStateFeature : InjectableFeature
    {
        public LevelStateFeature(Contexts contexts)
        {
            Add(new LevelStateInitializationSystem(contexts));
        }
    }
}