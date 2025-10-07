using Unity.Mathematics;

namespace BartekNizio.Unity.Template.Entitas
{
	public static class Collision2D
	{
		public static bool Intersect(Circle circle, Rectangle rectangle) {
			var x = math.max(rectangle.min.x, math.min(circle.center.x, rectangle.max.x));
			var y = math.max(rectangle.min.y, math.min(circle.center.y, rectangle.max.y));

			var distance = math.sqrt(
				math.pow(x - circle.center.x, 2) +
				math.pow(y - circle.center.y, 2)
			);

			return distance < circle.radius;
		}

		public static bool Intersect(Line line, Rectangle rectangle) {
			if (rectangle.min.x < line.start.x && rectangle.max.x > line.start.x) {
				return true;
			}

			if (rectangle.min.x < line.end.x && rectangle.max.x > line.end.x) {
				return true;
			}

			if (rectangle.min.y < line.start.y && rectangle.max.y > line.start.y) {
				return true;
			}

			if (rectangle.min.y < line.end.y && rectangle.max.y > line.end.y) {
				return true;
			}

			return false;
		}
	}

	public struct Circle
	{
		public float2 center;
		public float radius;
	}

	public struct Rectangle
	{
		public Rectangle(float2 center, float2 size) {
			min = center - size * 0.5f;
			max = center + size * 0.5f;
		}

		public float2 min;
		public float2 max;
	}

	public struct Line
	{
		public float2 start;
		public float2 end;
	}
}