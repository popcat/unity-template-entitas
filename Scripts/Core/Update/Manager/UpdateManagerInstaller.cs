using Zenject;

namespace BartekNizio.Unity.Template.Entitas
{
	public class UpdateManagerInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			var updateManager = FindFirstObjectByType<UpdateManager>();
			Container.BindInstance( updateManager );
			Container.Bind<UpdateSystem>().AsSingle();
			Container.Bind<FixedUpdateSystem>().AsSingle();
		}
	}
}