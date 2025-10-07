using System;
using System.Collections.Generic;

namespace BartekNizio.Unity.Template.Entitas
{
	public class CollectionPool
	{
		private static bool _initialized;

		private static Dictionary<Type, object> _listPools;
		private static Dictionary<Type, object> _queuePools;
		private static Dictionary<Type, object> _hashSetPools;

		public static void Initialize() {
			if (_initialized) {
				return;
			}

			_listPools = new Dictionary<Type, object>();
			_queuePools = new Dictionary<Type, object>();
			_hashSetPools = new Dictionary<Type, object>();

			_initialized = true;
		}

		public static List<T> GetList<T>(int capacity = 10) {
			Initialize();
			var pool = GetListPool<T>();
			return pool.Get(capacity);
		}

		public static Queue<T> GetQueue<T>(int capacity = 10) {
			Initialize();
			var pool = GetQueuePool<T>();
			return pool.Get(capacity);
		}

		public static HashSet<T> GetHashSet<T>(int capacity = 10) {
			Initialize();
			var pool = GetHashSetPool<T>();
			return pool.Get(capacity);
		}

		public static void Return<T>(List<T> list) {
			Initialize();
			var pool = GetListPool<T>();
			pool.Return(list);
		}

		public static void Return<T>(Queue<T> queue) {
			Initialize();
			var pool = GetQueuePool<T>();
			pool.Return(queue);
		}

		public static void Return<T>(HashSet<T> set) {
			Initialize();
			var pool = GetHashSetPool<T>();
			pool.Return(set);
		}

		private static ListPool<T> GetListPool<T>() {
			if (_listPools.TryGetValue(typeof(T), out var pool) == false) {
				pool = new ListPool<T>();
				_listPools.Add(typeof(T), pool);
			}

			return (ListPool<T>)pool;
		}

		private static QueuePool<T> GetQueuePool<T>() {
			if (_queuePools.TryGetValue(typeof(T), out var pool) == false) {
				pool = new QueuePool<T>();
				_queuePools.Add(typeof(T), pool);
			}

			return (QueuePool<T>)pool;
		}

		private static HashSetPool<T> GetHashSetPool<T>() {
			if (_hashSetPools.TryGetValue(typeof(T), out var pool) == false) {
				pool = new HashSetPool<T>();
				_hashSetPools.Add(typeof(T), pool);
			}

			return (HashSetPool<T>)pool;
		}
	}
}