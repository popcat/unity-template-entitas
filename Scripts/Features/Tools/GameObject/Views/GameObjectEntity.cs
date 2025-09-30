using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace BartekNizio.Unity.Template.Entitas
{
	public class GameObjectEntity : MonoBehaviour
	{
		//[Dropdown("GetAutoComponents")]
		public List<string> simpleComponents;
		public GameEntity Entity { get; private set; }

		private AddUnityComponents _addUnityComponents;
		private Contexts _contexts;
		private GameConfiguration _gameConfig;
		private GameObjectEntityComponentService _gameObjectEntityComponentService;
		
		private bool _initialized;
		private List<IGameObjectEntityComponent> _interfaces;

		[Inject]
		public void Initialize(Contexts contexts, GameConfiguration gameConfig, GameObjectEntityComponentService gameObjectEntityComponentService)
		{
			_contexts = contexts;
			_gameConfig = gameConfig;
			_gameObjectEntityComponentService = gameObjectEntityComponentService;
			_addUnityComponents = new AddUnityComponents();
			_addUnityComponents.Initialize(gameObject);
		}

		public GameEntity CreateEntity()
		{
			if (Entity != null || Entity.isEnabled)
			{
				Debug.LogError("Overriding existing entity for GOE");
			}
			
			Entity = _contexts.game.CreateEntity();
			AddDefaultComponents();
			AddUnityComponents();
			GetInterfaces();
			foreach ( var i in _interfaces )
				i.AddComponent(_contexts, _gameConfig, this);
			
			_initialized = true;
			return Entity;
		}
		
		private void Start()
		{
			CreateDefaultEntity();
		}

		private void CreateDefaultEntity()
		{
			if (gameObject.activeInHierarchy == false) {
				return;
			}
			
			if (_initialized || _contexts == null) {
				return;
			}
			
			CreateEntity();
		}

		private void GetInterfaces()
		{
			if ( _interfaces == null )
				_interfaces = new List<IGameObjectEntityComponent>();
			else
				_interfaces.Clear();
			GetSimpleInterfaces();
			GetMonoInterfaces();
		}

		private void AddDefaultComponents()
		{
			Entity.AddGameObject(gameObject);
			Entity.AddTransform(transform);
		}

		private void AddUnityComponents()
		{
			_addUnityComponents.AddComponents(Entity);
		}
		
		private void GetSimpleInterfaces()
		{
			foreach ( var name in simpleComponents ) {
				_interfaces.Add( _gameObjectEntityComponentService.GetComponentByName( name ) );
			}
		}

		private void GetMonoInterfaces()
		{
			foreach (var component in GetComponents<IGameObjectEntityComponent>()) {
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