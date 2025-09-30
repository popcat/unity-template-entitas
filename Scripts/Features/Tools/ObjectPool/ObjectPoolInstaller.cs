using Zenject;
using UnityEngine;

namespace BartekNizio.Unity.Template.Entitas
{
	public class ObjectPoolInstaller : MonoInstaller
	{
		public Transform objectPoolRoot;

		public override void InstallBindings()
		{
			Container.Bind<GameObjectPoolService>().To<GameObjectPoolService>().AsSingle().NonLazy();
			Container.BindInstance( objectPoolRoot ).WhenInjectedInto<GameObjectPoolService>();
		}
	}
}
