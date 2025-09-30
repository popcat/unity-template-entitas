using System.Collections.Generic;
using UnityEngine;

namespace BartekNizio.Unity.Template.Entitas
{
    public class AddUnityComponents
    {
        public Animator Animator;
        public Collider Collider;
        public List<Collider> Colliders;
        public Collider2D Collider2D;
        public List<Collider2D> Colliders2D;
        public Rigidbody Rigidbody;
        public Rigidbody2D Rigidbody2D;

        public void Initialize(GameObject gameObject)
        {
            Animator = gameObject.GetComponent<Animator>();
            Collider = gameObject.GetComponent<Collider>();
            Colliders = new List<Collider>();
            gameObject.GetComponents(Colliders);
            Collider2D = gameObject.GetComponent<Collider2D>();
            Colliders2D = new List<Collider2D>();
            gameObject.GetComponents(Colliders2D);
            Rigidbody = gameObject.GetComponent<Rigidbody>();
            Rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        }

        public void AddComponents(GameEntity entity)
        {
            if(Animator) entity.AddAnimator(Animator);
            if(Collider) entity.AddCollider(Collider);
            if(Collider2D) entity.AddCollider2D(Collider2D);
            if(Rigidbody) entity.AddRigidbody(Rigidbody);
            if(Rigidbody2D) entity.AddRigidbody2D(Rigidbody2D);
            if(Colliders.Count > 0) entity.AddColliderList(Colliders);
            if(Colliders2D.Count > 0) entity.AddCollider2DList(Colliders2D);
        }
    }
}