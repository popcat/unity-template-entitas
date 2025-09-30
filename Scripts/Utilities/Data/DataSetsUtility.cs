using Unity.Collections;
using Unity.Mathematics;

namespace BartekNizio.Unity.Template.Entitas
{
	public static class DataSetsUtility
	{
		public static int2[] HorizontalAndVerticalNeighbours2D()
		{
			return new int2[] {
				new(0, 1),
				new(1, 0),
				new(0, -1),
				new(-1, 0),
			};
		}
		
		public static NativeArray<int2> HorizontalAndVerticalNeighbours2D(Allocator allocator)
		{
			var array = new NativeArray<int2>(4, allocator);
			array[0] = new int2(0, 1);
			array[1] = new int2(1, 0);
			array[2] = new int2(0, -1);
			array[3] = new int2(-1, 0);
			return array;
		}

		public static int3[] HorizontalAndVerticalNeighbours3D()
		{
			return new int3[] {
				new(0, 0, 1),
				new(1, 0, 0),
				new(0, 0, -1),
				new(-1, 0, 0),
			};
		}
		
		public static NativeArray<int3> HorizontalAndVerticalNeighbours3D(Allocator allocator)
		{
			var array = new NativeArray<int3>(4, allocator);
			array[0] = new(0, 0, -1);
			array[1] = new(-1, 0, 0);
			array[2] = new(0, 0, 1);
			array[3] = new(1, 0, 0);
			return array;
		}

		public static int2[] DiagonalNeighbours2D()
		{
			return new int2[] {
				new(1, 1),
				new(1, -1),
				new(-1, -1),
				new(-1, 1),
			};
		}
		
		public static NativeArray<int2> DiagonalNeighbours2D(Allocator allocator)
		{
			var array = new NativeArray<int2>(4, allocator);
			array[0] = new(1, 1);
			array[1] = new(1, -1);
			array[2] = new(-1, -1);
			array[3] = new(-1, 1);
			return array;
		}

		public static int3[] DiagonalNeighbours3D()
		{
			return new int3[] {
				new(1, 0, 1),
				new(1, 0, -1),
				new(-1, 0, -1),
				new(-1, 0, 1),
			};
		}
		
		public static NativeArray<int3> DiagonalNeighbours3D(Allocator allocator)
		{
			var array = new NativeArray<int3>(4, allocator);
			array[0] = new(1, 0, 1);
			array[1] = new(1, 0, -1);
			array[2] = new(-1, 0, -1);
			array[3] = new(-1, 0, 1);
			return array;
		}

		public static int2[] AllNeighbours2D()
		{
			return new int2[] {
				new(0, 1),
				new(1, 0),
				new(0, -1),
				new(-1, 0),
				new(1, 1),
				new(1, -1),
				new(-1, -1),
				new(-1, 1),
			};
		}
		
		public static NativeArray<int2> AllNeighbours2D(Allocator allocator)
		{
			var array = new NativeArray<int2>(8, allocator);
			array[0] = new(0, 1);
			array[1] = new(1, 0);
			array[2] = new(0, -1);
			array[3] = new(-1, 0);
			array[4] = new(1, 1);
			array[5] = new(1, -1);
			array[6] = new(-1, -1);
			array[7] = new(-1, 1);
			return array;
		}

		public static int3[] AllNeighbours3D()
		{
			return new int3[] {
				new(0, 0, 1),
				new(1, 0, 0),
				new(0, 0, -1),
				new(-1, 0, 0),
				new(1, 0, 1),
				new(1, 0, -1),
				new(-1, 0, -1),
				new(-1, 0, 1),
			};
		}
		
		public static NativeArray<int3> AllNeighbours3D(Allocator allocator)
		{
			var array = new NativeArray<int3>(8, allocator);
			array[0] = new(0, 0, 1);
			array[1] = new(1, 0, 0);
			array[2] = new(0, 0, -1);
			array[3] = new(-1, 0, 0);
			array[4] = new(1, 0, 1);
			array[5] = new(1, 0, -1);
			array[6] = new(-1, 0, -1);
			array[7] = new(-1, 0, 1);
			return array;
		}
	}
}