using System;
using System.Collections.Generic;

namespace BartekNizio.Unity.Template.Entitas
{
	public class Graph<T>
	{
		public GraphNode<T> StartNode { get; private set; }
		public GraphNode<T> CurrentNode { get; private set; }
		private List<GraphNode<T>> _graphNodes = new ();

		private void SetOrigin(GraphNode<T> node)
		{
			StartNode = node;
			CurrentNode = node;
		}

		public GraphNode<T> AddNode(T value, params GraphNode<T>[] prevNodes)
		{
			var node = new GraphNode<T>(value);
			foreach (var prevNode in prevNodes) {
				node.AddPrevNode(prevNode);
				prevNode?.AddNextNode(node);
			}
			_graphNodes.Add(node);
			
			if(StartNode == null) SetOrigin(node);
			return node;
		}

		public bool MoveNext(int pathIndex)
		{
			if (CurrentNode.NextNodes == null || CurrentNode.NextNodes.Count == 0) {
				return false;
			}

			if (pathIndex < 0 || CurrentNode.NextNodes.Count >= pathIndex) {
				throw new Exception();
			}
			
			CurrentNode = CurrentNode.NextNodes[pathIndex];
			return true;
		}
		
		public bool MoveNext(GraphNode<T> node)
		{
			if (CurrentNode.NextNodes == null || CurrentNode.NextNodes.Count == 0) {
				return false;
			}

			if (node == null || CurrentNode.NextNodes.Contains(node) == false) {
				throw new Exception();
			}

			CurrentNode = node;
			return true;
		}
	}
}