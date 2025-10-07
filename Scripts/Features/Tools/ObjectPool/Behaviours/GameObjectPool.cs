using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace BartekNizio.Unity.Template.Entitas
{
	public class GameObjectPool : MonoBehaviour
	{
		[Inject]
		private readonly DiContainer _container;

		private Queue<GameObject> _pool;

		private GameObject _prefab;
		private Transform _transform;

		public int ActiveCount { get; private set; }

		public int PoolCount => _pool.Count;

		public void Initialize(GameObject prefab) {
			_transform = transform;
			_prefab = prefab;
			_pool = new Queue<GameObject>();
		}

		public GameObject Instantiate(Vector3 position, Quaternion rotation) {
			var obj = _pool.Count < 1 ? InternalInstantiate() : _pool.Dequeue();
			var objTransform = obj.transform;
			objTransform.position = position;
			objTransform.rotation = rotation;
			obj.SetActive(true);
			ActiveCount++;
			return obj;
		}

		public void Recycle(GameObject obj) {
			obj.SetActive(false);
			obj.transform.SetParent(_transform, false);

			if (_pool.Contains(obj)) {
				DebugLogger.LogError($"Trying to Recycle {obj.name} twice!");
				return;
			}

			ActiveCount--;
			_pool.Enqueue(obj);
		}

		public void Prewarm(int count) {
			for (var i = 0; i < count; i++) {
				InternalInstantiate();
			}
		}

		public void Clear() {
			while (_pool.Count > 0) {
				var obj = _pool.Dequeue();
				Destroy(obj);
			}
		}

		public void Clean() {
			foreach (Transform child in _transform) {
				if (child.gameObject.activeSelf) {
					Recycle(child.gameObject);
				}
			}
		}

		public void Remove(int count) {
			for (var i = 0; i < count; i++) {
				if (_pool.Count > 0) {
					var obj = _pool.Dequeue();
					Destroy(obj);
				}
				else {
					return;
				}
			}
		}

		private GameObject InternalInstantiate() {
			var obj = Instantiate(_prefab, _transform);
			_container.InjectGameObject(obj);
			obj.SetActive(false);
			return obj;
		}
	}
}