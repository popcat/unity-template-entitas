using Zenject;

namespace BartekNizio.Unity.Template.Entitas
{
    public class FeatureInstallers : Installer<FeatureInstallers>
    {
        public override void InstallBindings()
        {
            Container.Bind<GameObjectInstaller>().AsSingle().NonLazy();
            Container.Bind<JobsInstaller>().AsSingle().NonLazy();
            Container.Bind<SceneInstaller>().AsSingle().NonLazy();
        }
    }
}