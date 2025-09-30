using System.Collections.Generic;

namespace BartekNizio.Unity.Template.Entitas
{
	public class GraphNode<T>
	{
		public T Value { get; private set; }
		public List<GraphNode<T>> NextNodes { get; private set; }
		public List<GraphNode<T>> PrevNodes { get; private set; }

		public GraphNode(T value)
		{
			Value = value;
			NextNodes = new List<GraphNode<T>>();
			PrevNodes = new List<GraphNode<T>>();
		}

		public void AddNextNode(GraphNode<T> node)
		{
			NextNodes.Add(node);
		}
		
		public void AddPrevNode(GraphNode<T> node)
		{
			if(node == null) return;
			PrevNodes.Add(node);
		}
	}
}