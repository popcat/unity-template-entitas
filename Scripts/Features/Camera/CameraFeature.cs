namespace BartekNizio.Unity.Template.Entitas
{
    public class CameraFeature : InjectableFeature
    {
        public CameraFeature(Contexts contexts)
        {
            Add(new CameraFollowPlayerSystem(contexts));
            
            /*Add(new CameraSpawnSystem(contexts));
            Add(new CameraRotationInputSystem(contexts));
            Add(new CameraMovementInputSystem(contexts));
            Add(new CameraRotationSystem(contexts));
            Add(new CameraMovementSystem(contexts));*/
        }
    }
}