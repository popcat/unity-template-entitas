using System;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

namespace BartekNizio.Unity.Template.Entitas
{
	public static class MathUtility
	{
		public static bool AreVectorsEqual(float2 v1, float2 v2) {
			var delta = math.abs(v1 - v2);
			return delta.x <= math.EPSILON && delta.y <= math.EPSILON;
		}

		public static bool AreVectorsEqual(float3 v1, float3 v2) {
			var delta = math.abs(v1 - v2);
			return delta.x <= math.EPSILON && delta.y <= math.EPSILON && delta.z <= math.EPSILON;
		}

		public static bool IsCollisionBetweenCircles(Vector3 c1, float r1, Vector3 c2, float r2) {
			var distance = Vector3.Distance(c1, c2);
			if (distance <= r1 + r2) {
				return true;
			}

			return false;
		}

		public static bool IsPointWithinCircle(Vector3 pointPosition, Vector3 circlePosition, float radius) {
			var distance = math.distancesq(pointPosition, circlePosition);
			if (distance <= radius * radius) {
				return true;
			}

			return false;
		}

		public static void GetPointsOnLine(Vector3 origin, Vector3 direction, float interval, float distance,
			List<Vector3> points) {
			points.Clear();
			var pointCount = (int)(distance / interval);
			for (var i = 0; i < pointCount; i++) {
				var pointposition = origin + direction * interval * i;
				points.Add(pointposition);
			}

			if (points.Count == 0) {
				throw new Exception("Line length is too short, no outcomes");
			}
		}

		public static bool IsColinearXZ(float3 a, float3 b, float3 c) {
			var v = (b.x - a.x) * (c.z - a.z) - (c.x - a.x) * (b.z - a.z);

			// Epsilon not chosen with much thought, just that float.Epsilon was a bit too small.
			return v <= 0.0000001f && v >= -0.0000001f;
		}

		public static bool RightOrColinearXZ(float3 a, float3 b, float3 p) {
			return (b.x - a.x) * (p.z - a.z) - (p.x - a.x) * (b.z - a.z) <= 0;
		}


		public static float Angle(float3 from, float3 to) {
			var num = math.sqrt(math.lengthsq(from) * math.lengthsq(to));
			return num < 1.0000000036274937E-15
				? 0.0f
				: (float)math.acos((double)math.clamp(math.dot(from, to) / num, -1f, 1f)) * 57.29578f;
		}

		public static float SignedAngle(float3 from, float3 to, float3 axis) {
			var num1 = Angle(from, to);
			var num2 = (float)(from.y * (double)to.z - from.z * (double)to.y);
			var num3 = (float)(from.z * (double)to.x - from.x * (double)to.z);
			var num4 = (float)(from.x * (double)to.y - from.y * (double)to.x);
			var num5 = math.sign((float)(axis.x * (double)num2 + axis.y * (double)num3 +
			                             axis.z * (double)num4));
			return num1 * num5;
		}
	}
}