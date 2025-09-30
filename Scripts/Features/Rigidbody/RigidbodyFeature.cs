namespace BartekNizio.Unity.Template.Entitas
{
    public class RigidbodyFeature : InjectableFeature
    {
        public RigidbodyFeature(Contexts contexts)
        {
            Add(new PreviousVelocitySystem(contexts));
        }
    }
}