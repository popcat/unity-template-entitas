using System.Collections.Generic;

namespace BartekNizio.Unity.Template.Entitas
{
	public class HashSetPool<T>
	{
		private readonly Dictionary<int, Queue<HashSet<T>>> _collectionsBySize;

		public HashSetPool() {
			_collectionsBySize = new Dictionary<int, Queue<HashSet<T>>>();
			foreach (var size in CollectionPoolSize.sizes) {
				_collectionsBySize.Add(size, new Queue<HashSet<T>>());
			}
		}

		public HashSet<T> Get(int capacity = 10) {
			var size = CollectionPoolSize.FindBiggerSize(capacity);
			var queue = _collectionsBySize[size];
			if (queue.Count == 0) {
				Create(size);
			}

			return queue.Dequeue();
		}

		public void Return(HashSet<T> set) {
			if (set == null) {
				return;
			}

			var size = CollectionPoolSize.FindSmallerSize(set.Count);
			set.Clear();
			_collectionsBySize[size].Enqueue(set);
		}


		private void Create(int size) {
			var set = new HashSet<T>(size);
			_collectionsBySize[size].Enqueue(set);
		}
	}
}