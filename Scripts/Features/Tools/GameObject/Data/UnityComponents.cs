using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace BartekNizio.Unity.Template.Entitas
{
	public struct AddUnityComponents
	{
		public GameObject GameObject;
		public Transform Transform;
		public Animator Animator;
		public Collider Collider;
		public List<Collider> Colliders;
		public Collider2D Collider2D;
		public List<Collider2D> Colliders2D;
		public Rigidbody Rigidbody;
		public Rigidbody2D Rigidbody2D;
		public CharacterController CharacterController;

		public AddUnityComponents(GameObject gameObject) {
			GameObject = gameObject;
			Transform = gameObject.transform;
			Animator = gameObject.GetComponent<Animator>();
			Collider = gameObject.GetComponent<Collider>();
			Colliders = new List<Collider>();
			gameObject.GetComponents(Colliders);
			Collider2D = gameObject.GetComponent<Collider2D>();
			Colliders2D = new List<Collider2D>();
			gameObject.GetComponents(Colliders2D);
			Rigidbody = gameObject.GetComponent<Rigidbody>();
			Rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
			CharacterController = gameObject.GetComponent<CharacterController>();
		}

		public void AddComponents(Entity entity) {
			switch (entity) {
				case GameEntity gameEntity:
					AddComponents(gameEntity);
					break;
				case MetaEntity metaEntity:
					AddComponents(metaEntity);
					break;
				case InputEntity inputEntity:
					AddComponents(inputEntity);
					break;
				case UiEntity uiEntity:
					AddComponents(uiEntity);
					break;
			}
		}

		private void AddComponents(GameEntity entity) {
			entity.AddGameObject(GameObject);
			entity.AddTransform(Transform);
			if (Animator) {
				entity.AddAnimator(Animator);
			}

			if (Collider) {
				entity.AddCollider(Collider);
			}

			if (Collider2D) {
				entity.AddCollider2D(Collider2D);
			}

			if (Rigidbody) {
				entity.AddRigidbody(Rigidbody);
			}

			if (Rigidbody2D) {
				entity.AddRigidbody2D(Rigidbody2D);
			}

			if (CharacterController) {
				entity.AddCharacterController(CharacterController);
			}

			if (Colliders.Count > 0) {
				entity.AddColliderList(Colliders);
			}

			if (Colliders2D.Count > 0) {
				entity.AddCollider2DList(Colliders2D);
			}
		}

		private void AddComponents(MetaEntity entity) {
			entity.AddGameObject(GameObject);
			entity.AddTransform(Transform);
			if (Animator) {
				entity.AddAnimator(Animator);
			}

			if (Collider) {
				entity.AddCollider(Collider);
			}

			if (Collider2D) {
				entity.AddCollider2D(Collider2D);
			}

			if (Rigidbody) {
				entity.AddRigidbody(Rigidbody);
			}

			if (Rigidbody2D) {
				entity.AddRigidbody2D(Rigidbody2D);
			}

			if (CharacterController) {
				entity.AddCharacterController(CharacterController);
			}

			if (Colliders.Count > 0) {
				entity.AddColliderList(Colliders);
			}

			if (Colliders2D.Count > 0) {
				entity.AddCollider2DList(Colliders2D);
			}
		}

		private void AddComponents(InputEntity entity) {
			entity.AddGameObject(GameObject);
			entity.AddTransform(Transform);
			if (Animator) {
				entity.AddAnimator(Animator);
			}

			if (Collider) {
				entity.AddCollider(Collider);
			}

			if (Collider2D) {
				entity.AddCollider2D(Collider2D);
			}

			if (Rigidbody) {
				entity.AddRigidbody(Rigidbody);
			}

			if (Rigidbody2D) {
				entity.AddRigidbody2D(Rigidbody2D);
			}

			if (Colliders.Count > 0) {
				entity.AddColliderList(Colliders);
			}

			if (Colliders2D.Count > 0) {
				entity.AddCollider2DList(Colliders2D);
			}
		}

		private void AddComponents(UiEntity entity) {
			entity.AddGameObject(GameObject);
			entity.AddTransform(Transform);
			if (Animator) {
				entity.AddAnimator(Animator);
			}

			if (Collider) {
				entity.AddCollider(Collider);
			}

			if (Collider2D) {
				entity.AddCollider2D(Collider2D);
			}

			if (Rigidbody) {
				entity.AddRigidbody(Rigidbody);
			}

			if (Rigidbody2D) {
				entity.AddRigidbody2D(Rigidbody2D);
			}

			if (Colliders.Count > 0) {
				entity.AddColliderList(Colliders);
			}

			if (Colliders2D.Count > 0) {
				entity.AddCollider2DList(Colliders2D);
			}
		}
	}
}