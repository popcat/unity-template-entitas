using System.Collections.Generic;
using Unity.Mathematics;

namespace BartekNizio.Unity.Template.Entitas
{
	public static class AlgorithmUtility
	{
		public static int2[] positionNeighbours = new[] {
			new int2(1, 0),
			new int2(-1, 0),
			new int2(0, 1),
			new int2(0, -1),
		};
		
		public static HashSet<int> FrontierSearch(int2 startPosition, Dictionary<int2, int> positionsMap)
		{
			var frontier = new HashSet<int>();
			if (!positionsMap.ContainsKey(startPosition)) {
				return frontier;
			}

			frontier.Add(positionsMap[startPosition]);
			var queue = new Queue<int2>();
			queue.Enqueue(startPosition);

			while (queue.Count != 0) {
				var currentPosition = queue.Dequeue();
				for (int i = 0; i < 4; i++) {
					var nextPosition = currentPosition + positionNeighbours[i];
					if (!positionsMap.TryGetValue(nextPosition, out var positionIndex)) continue;
					if(frontier.Contains(positionIndex)) continue;
					
					queue.Enqueue(nextPosition);
					frontier.Add(positionIndex);
				}
			}

			return frontier;
		}
	}
}