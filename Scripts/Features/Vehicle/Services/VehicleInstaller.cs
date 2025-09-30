using Zenject;

namespace BartekNizio.Unity.Template.Entitas
{
    public class VehicleInstaller : Installer<VehicleInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<VehicleFactory>().AsSingle();
        }
    }
}