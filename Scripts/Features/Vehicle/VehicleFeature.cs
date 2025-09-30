namespace BartekNizio.Unity.Template.Entitas
{
    public class VehicleFeature : InjectableFeature
    {
        public VehicleFeature(Contexts contexts)
        {
            Add(new VehicleMovementSystem(contexts));
            Add(new VehicleRotationSystem(contexts));
            Add(new VehicleWobbleSystem(contexts));
        }
    }
}