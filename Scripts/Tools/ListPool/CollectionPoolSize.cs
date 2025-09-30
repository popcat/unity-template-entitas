using System;

namespace BartekNizio.Unity.Template.Entitas
{
	public static class CollectionPoolSize
	{
		public static readonly int[] sizes = {
			0,
			10,
			100,
			1000,
			10000,
			100000,
			1000000,
			Int32.MaxValue
		};
		
		public static int FindBiggerSize(int size)
		{
			var s  = 0;
			foreach (var ls in sizes) {
				if(size > ls) continue;
				s = ls;
				break;
			}

			return s;
		}
		
		public static int FindSmallerSize(int size)
		{
			var s  = 0;
			foreach (var ls in sizes) {
				if(size > ls) break;
				s = ls;
			}

			return s;
		}
	}
}