namespace BartekNizio.Unity.Template.Entitas
{
    public class CameraFeature : InjectableFeature
    {
        public CameraFeature(Contexts contexts)
        {
            Add(new InitializeMainCameraSystem(contexts));
        }
    }
}