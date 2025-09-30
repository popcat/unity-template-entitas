namespace BartekNizio.Unity.Template.Entitas
{
    public class ObjectPoolFeature : InjectableFeature
    {
        public ObjectPoolFeature(Contexts contexts)
        {
            Add(new ObjectPoolInitializationSystem(contexts));
        }
    }
}