using Zenject;

namespace BartekNizio.Unity.Template.Entitas
{
	public class UpdateManagerInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			Container.Bind<UpdateSystem>().AsSingle();
			Container.Bind<FixedUpdateSystem>().AsSingle();
			Container.BindInstance( FindFirstObjectByType<UpdateManager>() );
		}
	}
}