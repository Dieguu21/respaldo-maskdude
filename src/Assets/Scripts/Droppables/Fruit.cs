using UnityEngine;

namespace MaskDudeFruitCollecter.Droppables
{
    public class Fruit : MonoBehaviour, IDroppable
    {
        private int price = 1;

        private SpriteRenderer spriteRenderer;
        private BoxCollider2D boxCollider2D;
        private Rigidbody2D rigidbody2D;

        public void Start()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            boxCollider2D = GetComponent<BoxCollider2D>();
            rigidbody2D = GetComponent<Rigidbody2D>();
        }

        public int GetTotalPrice()
        {
            return price;
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
    
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                DisableObjectInScene();
                StartExplodingAnimation();
                Destroy(gameObject, 0.5f);
                collision.gameObject.GetComponent<Player.Player>().AddOneFruitToCounter();
            }
        }
    
        private void DisableObjectInScene()
        {
            spriteRenderer.enabled = false;
            boxCollider2D.enabled = false;
            rigidbody2D.bodyType = RigidbodyType2D.Static;
        }

        private void StartExplodingAnimation()
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
    }
}
