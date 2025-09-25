using UnityEngine;
using Zenject;

namespace BartekNizio.Unity.Template.Entitas
{
	[CreateAssetMenu(menuName = "Config/Installer/Game Configuration Installer")]
	public class GameConfigurationInstaller : ScriptableObjectInstaller<GameConfigurationInstaller>
	{
		public GameConfiguration gameConfig;
		
		public override void InstallBindings()
		{
			Container.BindInstance( gameConfig );
			foreach ( var cfg in gameConfig.configs ) {
				Container.Bind( cfg.GetType() ).FromInstance( cfg );
				Container.QueueForInject( cfg );
			}
		}
	}
}