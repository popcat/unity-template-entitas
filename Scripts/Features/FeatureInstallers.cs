using Zenject;

namespace BartekNizio.Unity.Template.Entitas
{
	public class FeatureInstallers : Installer<FeatureInstallers>
	{
		public override void InstallBindings() {
			GameObjectInstaller.Install(Container);
			JobsInstaller.Install(Container);
			SceneInstaller.Install(Container);
		}
	}
}