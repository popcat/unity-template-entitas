using System.Collections.Generic;

namespace BartekNizio.Unity.Template.Entitas
{
	public class ListPool<T>
	{
		private readonly Dictionary<int, Queue<List<T>>> _collectionsBySize;

		public ListPool()
		{
			_collectionsBySize = new();
			foreach (var size in CollectionPoolSize.sizes) {
				_collectionsBySize.Add(size, new());
			}
		}
		
		public List<T> Get(int capacity = 10)
		{
			var size = CollectionPoolSize.FindBiggerSize(capacity);
			var queue = _collectionsBySize[size];
			if (queue.Count == 0) {
				Create(size);
			}
			
			return queue.Dequeue();
		}

		public void Return(List<T> list)
		{
			if(list == null) return;
			
			var size = CollectionPoolSize.FindSmallerSize(list.Capacity);
			list.Clear();
			_collectionsBySize[size].Enqueue(list);
		}
		
		
		private void Create(int size)
		{
			var list = new List<T>(size);
			_collectionsBySize[size].Enqueue(list);
		}
	}
}