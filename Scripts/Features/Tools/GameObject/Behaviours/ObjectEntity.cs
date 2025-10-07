using System.Collections.Generic;
using Entitas;
using UnityEngine;
using Zenject;

namespace BartekNizio.Unity.Template.Entitas
{
	public abstract class ObjectEntity : MonoBehaviour
	{
		protected AddUnityComponents _addUnityComponents;
		protected EntityWrapper _entityWrapper;

		protected bool _initialized;
		protected List<IObjectEntityComponent> _objectEntityComponents;
		public Entity Entity => _entityWrapper.Entity;
		public Contexts Contexts { get; private set; }

		private void Awake() {
			CreateDefaultEntity();
			enabled = false;
		}

		[Inject]
		private void Initialize(Contexts contexts, ObjectEntityService objectEntityService) {
			Contexts = contexts;
			_addUnityComponents = new AddUnityComponents(gameObject);
			GetGameObjectEntityComponents();
		}

		protected abstract Entity CreatEntity();

		protected abstract void AddComponent(IObjectEntityComponent component);

		protected Entity InitializeEntity() {
			if (_initialized && Entity is { isEnabled: true }) {
				Debug.LogError("Overriding existing entity for GOE");
			}

			_entityWrapper = new EntityWrapper(CreatEntity());
			AddUnityComponents();
			foreach (var i in _objectEntityComponents) {
				AddComponent(i);
			}

			_initialized = true;
			return Entity;
		}

		private void CreateDefaultEntity() {
			if (gameObject.activeInHierarchy == false) {
				return;
			}

			if (_initialized || Contexts == null) {
				return;
			}

			InitializeEntity();
		}

		private void GetGameObjectEntityComponents() {
			if (_objectEntityComponents == null) {
				_objectEntityComponents = new List<IObjectEntityComponent>();
			}
			else {
				_objectEntityComponents.Clear();
			}

			GetComponents(_objectEntityComponents);
		}

		private void AddUnityComponents() {
			_addUnityComponents.AddComponents(Entity);
		}
	}
}