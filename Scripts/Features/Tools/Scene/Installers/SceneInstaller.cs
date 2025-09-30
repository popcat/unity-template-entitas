using Zenject;

namespace BartekNizio.Unity.Template.Entitas
{
	public class SceneInstaller : Installer<SceneInstaller>
	{
		public override void InstallBindings()
		{
			Container.Bind<SceneService>().AsSingle();
		}
	}
}