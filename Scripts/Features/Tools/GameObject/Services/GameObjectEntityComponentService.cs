using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BartekNizio.Unity.Template.Entitas
{
	public class GameObjectEntityComponentService
	{
		private Dictionary<string, IGameObjectEntityComponent> _dict;
		public List<IGameObjectEntityComponent> Components { get; private set; }
		
		public GameObjectEntityComponentService(List<IGameObjectEntityComponent> components)
		{
			Components = components;
			_dict = new Dictionary<string, IGameObjectEntityComponent>();
			foreach ( IGameObjectEntityComponent c in Components ) {
				_dict[c.GetType().Name] = c;
			}
		}

		public IGameObjectEntityComponent GetComponentByName( string name )
		{
			return _dict[name];
		}

		public static IEnumerable<System.Type>  GetAutoComponents()
		{
			return System.Reflection.Assembly.GetAssembly( typeof( IGameObjectEntityComponent ) )
					.GetTypes()
					.Where( t => t.IsClass && t.GetInterfaces().Contains( typeof( IGameObjectEntityComponent ) ) && !t.IsSubclassOf( typeof( MonoBehaviour ) ) );
		}
	}
}
