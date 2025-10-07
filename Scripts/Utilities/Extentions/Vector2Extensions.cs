using UnityEngine;

namespace BartekNizio.Unity.Template.Entitas
{
	public static class Vector2Extensions
	{
		public static Vector3 MapTo3D(this Vector2 v, float y = 0) {
			return new Vector3(v.x, y, v.y);
		}
	}
}