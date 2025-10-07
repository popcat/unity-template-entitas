using System.Collections.Generic;

namespace BartekNizio.Unity.Template.Entitas
{
	public class QueuePool<T>
	{
		private readonly Dictionary<int, Queue<Queue<T>>> _collectionsBySize;

		public QueuePool() {
			_collectionsBySize = new Dictionary<int, Queue<Queue<T>>>();
			foreach (var size in CollectionPoolSize.sizes) {
				_collectionsBySize.Add(size, new Queue<Queue<T>>());
			}
		}

		public Queue<T> Get(int capacity = 10) {
			var size = CollectionPoolSize.FindBiggerSize(capacity);
			var queue = _collectionsBySize[size];
			if (queue.Count == 0) {
				Create(size);
			}

			return queue.Dequeue();
		}

		public void Return(Queue<T> queue) {
			if (queue == null) {
				return;
			}

			var size = CollectionPoolSize.FindSmallerSize(queue.Count);
			queue.Clear();
			_collectionsBySize[size].Enqueue(queue);
		}


		private void Create(int size) {
			var list = new Queue<T>(size);
			_collectionsBySize[size].Enqueue(list);
		}
	}
}