using Zenject;

namespace BartekNizio.Unity.Template.Entitas
{
	public class GameObjectInstaller : Installer<GameObjectInstaller>
	{
		public override void InstallBindings()
		{
			BindGameObjectEntityComponents();
			Container.Bind<ObjectEntityService>().AsSingle();
		}

		private void BindGameObjectEntityComponents()
		{
			foreach ( var type in ObjectEntityService.GetAutoComponents() )  {
				Container.Bind<IObjectEntityComponent>().To( type ).AsSingle();
			}
		}
	}
}