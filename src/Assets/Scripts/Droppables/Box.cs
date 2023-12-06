using System.Collections.Generic;
using MaskDudeFruitCollecter.Core;
using UnityEngine;
using Random = UnityEngine.Random;

namespace MaskDudeFruitCollecter.Droppables
{
    public class Box : MonoBehaviour, IDroppable, IDamageable
    {
        private List<IDroppable> droppableLoot;
    
        private SpriteRenderer spriteRenderer;
        private BoxCollider2D boxCollider2D;
        private Rigidbody2D rigidbody2D;
        private Animator animator;
        
        [SerializeField] private float healthPoints;
    
        [Header("Drop Effects")]
        [SerializeField] private GameObject brokenBox;
        [SerializeField] private float dropForce;
    
        public void Start()
        {
            droppableLoot = GetDroppableLoot();
            spriteRenderer = GetComponent<SpriteRenderer>();
            boxCollider2D = GetComponent<BoxCollider2D>();
            rigidbody2D = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();
        }

        private List<IDroppable> GetDroppableLoot()
        {
            List<IDroppable> droppableObjects = new List<IDroppable>();
            List<GameObject> gameObjectChildrens = GetDirectChildrens();
            foreach (var children in gameObjectChildrens)
            {
                IDroppable droppableChild = children.GetComponent(typeof(IDroppable)) as IDroppable;
                if (droppableChild != null)
                {
                    droppableObjects.Add(droppableChild);
                }
            }

            return droppableObjects;
        }

        private List<GameObject> GetDirectChildrens()
        {
            List<GameObject> childrens = new List<GameObject>();
            foreach (Transform child in transform)
                childrens.Add(child.gameObject);

            return childrens;
        }

        public int GetTotalPrice()
        {
            int total = 0;
            foreach (var component in droppableLoot)
                total += component.GetTotalPrice();
            return total;
        }

        private void DisableObjectInScene()
        {
            spriteRenderer.enabled = false;
            boxCollider2D.enabled = false;
            rigidbody2D.bodyType = RigidbodyType2D.Static;
        }

        public void DropLoot()
        {
            foreach (var item in droppableLoot)
            {
                Vector2 dropDirection = GetRandomDropDirection();
                Vector3 position = transform.position;
                item.Drop(position, dropForce, dropDirection);
            }
        }
    
        private Vector2 GetRandomDropDirection()
        {
            float xRange = Random.Range(-1f, 1f);
            float yRange = Random.Range(0.0001f, 1f);
            return new Vector2(xRange, yRange);            
        }
    
        public void Drop(Vector3 position, float dropForce, Vector2 dropDirection)
        {
            transform.position = position + new Vector3(0, 0.1f, 0);
            EnableObjectInScene();
            rigidbody2D.AddForce(dropForce * dropDirection);
        }
    
        private void EnableObjectInScene()
        {
            spriteRenderer.enabled = true;
            boxCollider2D.enabled = true;
            rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
        }

        private void StartExplodingAnimationIfAppropriate()
        {
            if (healthPoints <= 0)
            {
                DisableObjectInScene();
                BlowUpInPieces();
                DropLoot();
            }
        }

        private void BlowUpInPieces() => Instantiate(brokenBox, transform.position, Quaternion.identity);

        public void TakeDamage(float damage)
        {
            animator.SetTrigger("isBeingHit");
            healthPoints -= damage;
        }

    }
}
