using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace BartekNizio.Unity.Template.Entitas
{
	public class GameObjectPoolService
	{
		[Inject]
		private readonly DiContainer _diContainer;
		
		private Dictionary<GameObject, GameObjectPool> _prefab2pool;
		private Dictionary<GameObject, GameObjectPool> _instance2pool;
		private Transform _rootTransform;
		
		public GameObjectPoolService( Transform root )
		{
			_prefab2pool = new Dictionary<GameObject, GameObjectPool>();
			_instance2pool = new Dictionary<GameObject, GameObjectPool>();
			_rootTransform = root;
		}
		
		public GameObject Create( GameObject prefab, Vector3 position, Quaternion rotation )
		{
			return InternalCreate( prefab, position, rotation );
		}

		public GameObject Create( GameObject prefab )
		{
			return Create( prefab, Vector3.zero, Quaternion.identity );
		}
		
		public void Destroy( GameObject obj )
		{
			InternalDestroy( obj );
		}
		
		public int Count(GameObject prefab)
		{
			return !_prefab2pool.TryGetValue(prefab, out var pool) ? 0 : pool.ActiveCount;
		}
		
		public void Clear()
		{
			foreach ( var pool in _prefab2pool.Values ) {
				pool.Clear();
			}
			Resources.UnloadUnusedAssets();
		}

		public void Clean()
		{
			foreach (var pool in _prefab2pool.Values ) {
				pool.Clean();
			}
		}
		
		public void Prewarm( GameObject prefab, int count )
		{
			var pool = GetOrCreatePool(prefab);
			if ( count > pool.PoolCount ) {
				pool.Prewarm( count - pool.PoolCount);
			} else if ( count < pool.PoolCount ) {
				pool.Remove( pool.PoolCount - count);
			}
		}

		public void Prewarm(GameObjectPoolConfig objectPoolConfig)
		{
			foreach (var prewarmGameObject in objectPoolConfig.objectsToPrewarm) {
				Prewarm(prewarmGameObject.prefab, prewarmGameObject.count);
			}
		}
		
		private GameObjectPool CreatePool( GameObject prefab )
		{
			GameObject obj = new GameObject(prefab.name + " Pool");
			GameObjectPool pool = obj.AddComponent<GameObjectPool>();
			_diContainer.Inject( pool );
			pool.Initialize(prefab);
			return pool;
		}
		
		private GameObject InternalCreate( GameObject prefab, Vector3 position, Quaternion rotation )
		{
			GameObjectPool pool = GetOrCreatePool(prefab);
			GameObject obj = pool.Instantiate(position, rotation);
			_instance2pool[obj] = pool;

			return obj;
		}
		
		private GameObjectPool GetOrCreatePool( GameObject prefab )
		{
			GameObjectPool pool;
			if ( !_prefab2pool.ContainsKey( prefab ) ) {
				pool = CreatePool( prefab );
				pool.gameObject.transform.parent = _rootTransform;
				_prefab2pool[prefab] = pool;
			} else {
				pool = _prefab2pool[prefab];
			}
			return pool;
		}
		
		private void InternalDestroy( GameObject obj )
		{
			if ( _instance2pool.ContainsKey( obj ) ) {
				var pool = _instance2pool[obj];
				pool.Recycle( obj );
			} else {
				DebugLogger.LogWarning( "Destroying non-pooled object " + obj.name );
				Object.Destroy( obj );
			}
		}
	}
}