using Unity.Mathematics;

namespace BartekNizio.Unity.Template.Entitas
{
	public static class Collision3D
	{
		public static bool Intersect(Sphere sphere, Box box)
		{
			var x = math.max(box.min.x, math.min(sphere.center.x, box.max.x));
			var y = math.max(box.min.y, math.min(sphere.center.y, box.max.y));
			var z = math.max(box.min.z, math.min(sphere.center.z, box.max.z));

			var distance = math.sqrt(
				math.pow(x - sphere.center.x, 2) +
				math.pow(y - sphere.center.y, 2) +
				math.pow(z - sphere.center.z, 2)
			);

			return distance < sphere.radius;
		}
	}

	public struct Sphere
	{
		public float3 center;
		public float radius;
	}

	public struct Box
	{
		public float3 min;
		public float3 max;
	}
}