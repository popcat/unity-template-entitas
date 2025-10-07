using Zenject;

namespace BartekNizio.Unity.Template.Entitas
{
	public class FeatureInstaller : MonoInstaller
	{
		public override void InstallBindings() {
			InstallFeatures();
		}

		private void InstallFeatures() {
			FeatureInstallers.Install(Container);
		}
	}
}