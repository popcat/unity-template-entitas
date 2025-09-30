namespace BartekNizio.Unity.Template.Entitas
{
    public class PhysicsFeature : InjectableFeature
    {
        public PhysicsFeature(Contexts contexts)
        {
            Add(new PreviousVelocitySystem(contexts));
        }
    }
}