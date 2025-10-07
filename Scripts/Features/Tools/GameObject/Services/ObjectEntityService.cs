using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace BartekNizio.Unity.Template.Entitas
{
	public class ObjectEntityService
	{
		private readonly Dictionary<string, IObjectEntityComponent> _dict;

		public ObjectEntityService(List<IObjectEntityComponent> components) {
			Components = components;
			_dict = new Dictionary<string, IObjectEntityComponent>();
			foreach (var c in Components) {
				_dict[c.GetType().Name] = c;
			}
		}

		public List<IObjectEntityComponent> Components { get; }

		public IObjectEntityComponent GetComponentByName(string name) {
			return _dict[name];
		}

		public static IEnumerable<Type> GetAutoComponents() {
			return Assembly.GetAssembly(typeof(IObjectEntityComponent))
				.GetTypes()
				.Where(t => t.IsClass && t.GetInterfaces().Contains(typeof(IObjectEntityComponent)) &&
				            !t.IsSubclassOf(typeof(MonoBehaviour)));
		}
	}
}