using UnityEngine;

namespace BartekNizio.Unity.Template.Entitas.Platformer2D
{
	public struct CharacterControllerData
	{
		public Vector2 MoveVelocity;
		public bool IsFacingRight;

		public RaycastHit2D GroundHit;
		public RaycastHit2D HeadHit;
		public bool IsGrounded;
		public bool BumpedHead;
	}
}