using Zenject;

namespace BartekNizio.Unity.Template.Entitas
{
	public class ContextInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			Container.BindInstance( Contexts.sharedInstance );
			Container.Bind<ContextService>().AsSingle();
		}
	}
}