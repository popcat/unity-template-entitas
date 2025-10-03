namespace BartekNizio.Unity.Template.Entitas
{
    public class FixedUpdateFeatures : InjectableFeature
    {
        public FixedUpdateFeatures(Contexts contexts)
        {
            Add(new PhysicsFeature(contexts));
        }
    }
}