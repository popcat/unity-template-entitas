using System;
using UnityEngine;

namespace BartekNizio.Unity.Template.Entitas.Platformer2D
{
	[Serializable]
	public struct CharacterControllerSpecs
	{
		[Header("Walk")]
		[Range(1f, 100f)]
		public float MaxWalkSpeed;

		[Range(0.25f, 50f)]
		public float GroundAcceleration;

		[Range(0.25f, 50f)]
		public float GroundDeceleration;

		[Range(0.25f, 50f)]
		public float AirAcceleration;

		[Range(0.25f, 50f)]
		public float AirDeceleration;

		[Header("Run")]
		[Range(1f, 100f)]
		public float MaxRunSpeed;

		[Header("Collision")]
		public LayerMask GroundLayer;

		public float GroundCheckDistance;
		public float HeadCheckDistance;

		[Range(0f, 1f)]
		public float HeadWidth;

		[NonSerialized]
		public Collider2D BodyCollider;

		[NonSerialized]
		public Collider2D FeetCollider;
	}
}