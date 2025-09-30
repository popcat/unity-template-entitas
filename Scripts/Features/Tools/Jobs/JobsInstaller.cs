using Zenject;

namespace BartekNizio.Unity.Template.Entitas
{
	public class JobsInstaller : Installer<JobsInstaller>
	{
		public override void InstallBindings()
		{
			Container.Bind<JobService>().AsSingle();
		}
	}
}