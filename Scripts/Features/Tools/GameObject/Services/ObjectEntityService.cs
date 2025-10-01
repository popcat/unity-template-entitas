using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BartekNizio.Unity.Template.Entitas
{
	public class ObjectEntityService
	{
		private Dictionary<string, IObjectEntityComponent> _dict;
		public List<IObjectEntityComponent> Components { get; private set; }
		
		public ObjectEntityService(List<IObjectEntityComponent> components)
		{
			Components = components;
			_dict = new Dictionary<string, IObjectEntityComponent>();
			foreach ( IObjectEntityComponent c in Components ) {
				_dict[c.GetType().Name] = c;
			}
		}

		public IObjectEntityComponent GetComponentByName( string name )
		{
			return _dict[name];
		}

		public static IEnumerable<System.Type>  GetAutoComponents()
		{
			return System.Reflection.Assembly.GetAssembly( typeof( IObjectEntityComponent ) )
					.GetTypes()
					.Where( t => t.IsClass && t.GetInterfaces().Contains( typeof( IObjectEntityComponent ) ) && !t.IsSubclassOf( typeof( MonoBehaviour ) ) );
		}
	}
}
