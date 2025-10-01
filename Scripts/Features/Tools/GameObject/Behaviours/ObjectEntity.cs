using System;
using System.Collections.Generic;
using Entitas;
using UnityEngine;
using Zenject;

namespace BartekNizio.Unity.Template.Entitas
{
	public abstract class ObjectEntity : MonoBehaviour
	{
		public Entity Entity => _entityWrapper.Entity;

		//[Dropdown("GetAutoComponents")]
		[SerializeField]
		private List<string> simpleComponents;

		protected EntityWrapper _entityWrapper;
		protected AddUnityComponents _addUnityComponents;
		protected Contexts _contexts;
		protected ObjectEntityService ObjectEntityService;
		
		protected bool _initialized;
		protected List<IObjectEntityComponent> _interfaces;

		[Inject]
		private void Initialize(Contexts contexts, ObjectEntityService objectEntityService)
		{
			_contexts = contexts;
			ObjectEntityService = objectEntityService;
			_addUnityComponents = new AddUnityComponents(gameObject);
		}

		private void Awake()
		{
			enabled = false;
		}

		private void Start()
		{
			CreateDefaultEntity();
		}

		protected abstract Entity CreatEntity();

		protected abstract void AddComponent(IObjectEntityComponent component);

		protected Entity InitializeEntity()
		{
			if (_initialized && Entity is { isEnabled: true })
			{
				Debug.LogError("Overriding existing entity for GOE");
			}
			
			_entityWrapper = new EntityWrapper(CreatEntity());
			AddUnityComponents();
			GetInterfaces();
			
			foreach ( var i in _interfaces )
				AddComponent(i);
			
			_initialized = true;
			return Entity;
		}

		private void CreateDefaultEntity()
		{
			if (gameObject.activeInHierarchy == false) {
				return;
			}
			
			if (_initialized || _contexts == null) {
				return;
			}
			
			InitializeEntity();
		}

		private void GetInterfaces()
		{
			if ( _interfaces == null )
				_interfaces = new List<IObjectEntityComponent>();
			else
				_interfaces.Clear();
			GetSimpleInterfaces();
			GetMonoInterfaces();
		}

		private void AddUnityComponents()
		{
			_addUnityComponents.AddComponents(Entity);
		}
		
		private void GetSimpleInterfaces()
		{
			foreach ( var name in simpleComponents ) {
				_interfaces.Add( ObjectEntityService.GetComponentByName( name ) );
			}
		}

		private void GetMonoInterfaces()
		{
			foreach (var component in GetComponents<IObjectEntityComponent>()) {
				if (_interfaces.Contains(component)) {
					continue;
				}
				_interfaces.Add(component);
			}
		}

		/*public List<string> GetAutoComponents()
		{
			return GameObjectEntityComponentService.GetAutoComponents().Select( t => t.Name ).ToList();
		}*/
	}
}