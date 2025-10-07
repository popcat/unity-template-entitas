using Unity.Mathematics;
using UnityEngine;

namespace BartekNizio.Unity.Template.Entitas
{
	public static class Vector3Extensions
	{
		public static bool IsAtPosition(this Vector3 v1, Vector3 v2) {
			return math.distancesq(v1, v2) < math.EPSILON;
		}

		public static Vector2 ToXZ(this Vector3 v) {
			return new Vector2(v.x, v.z);
		}

		public static Vector3 MultiplyValues(this Vector3 v1, Vector3 v2) {
			return new Vector3(v1.x * v2.x, v1.y * v2.y, v1.z * v2.z);
		}
	}
}