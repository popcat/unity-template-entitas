using Zenject;

namespace BartekNizio.Unity.Template.Entitas
{
	public class JobInstaller : Installer<JobInstaller>
	{
		public override void InstallBindings()
		{
			Container.Bind<JobService>().AsSingle();
		}
	}
}