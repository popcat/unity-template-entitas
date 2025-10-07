using System.Collections.Generic;

namespace BartekNizio.Unity.Template.Entitas
{
	public class GraphNode<T>
	{
		public GraphNode(T value, int index) {
			Value = value;
			Index = index;
			NextNodes = new List<GraphNode<T>>();
			PrevNodes = new List<GraphNode<T>>();
		}

		public T Value { get; private set; }
		public int Index { get; private set; }
		public List<GraphNode<T>> NextNodes { get; }
		public List<GraphNode<T>> PrevNodes { get; }

		public void AddNextNode(GraphNode<T> node) {
			NextNodes.Add(node);
		}

		public void AddPrevNode(GraphNode<T> node) {
			if (node == null) {
				return;
			}

			PrevNodes.Add(node);
		}
	}
}