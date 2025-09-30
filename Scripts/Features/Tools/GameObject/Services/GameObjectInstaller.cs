using Zenject;

namespace BartekNizio.Unity.Template.Entitas
{
	public class GameObjectInstaller : Installer<GameObjectInstaller>
	{
		public override void InstallBindings()
		{
			BindGameObjectEntityComponents();
			Container.Bind<GameObjectEntityComponentService>().AsSingle();
		}

		private void BindGameObjectEntityComponents()
		{
			foreach ( var type in GameObjectEntityComponentService.GetAutoComponents() )  {
				Container.Bind<IGameObjectEntityComponent>().To( type ).AsSingle();
			}
		}
	}
}