using UnityEngine;

namespace BartekNizio.Unity.Template.Entitas
{
	public abstract class ObjectEntityComponent : MonoBehaviour, IObjectEntityComponent
	{
		private void Awake() {
			enabled = false;
		}

		public abstract void AddComponent(GameObjectEntity objectEntity);
		public abstract void AddComponent(MetaObjectEntity objectEntity);
	}
}