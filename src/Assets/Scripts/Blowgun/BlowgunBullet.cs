using MaskDudeFruitCollecter.Core;
using UnityEngine;

namespace MaskDudeFruitCollecter.Blowgun
{
    public class BlowgunBullet : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private float damage;
        [SerializeField] private float lifeTime;
    
        private Animator animator;
    
        void Start()
        {
            animator = GetComponent<Animator>();
            Destroy(gameObject, lifeTime);
        }
    
        void FixedUpdate()
        {
            transform.Translate(Vector2.right * speed);
        }
    
        private void OnTriggerEnter2D(Collider2D collision)
        {
            IDamageable damageableObject = collision.gameObject.GetComponent<IDamageable>();
  
            if (damageableObject != null && !collision.CompareTag("Player"))
            {
                MakeDamage(damage, damageableObject);
                Destroy(gameObject);
            }

            if (collision.CompareTag("MapTiles"))
                Destroy(gameObject);
            
        }

        private void MakeDamage(float damage, IDamageable damageableObject)
        {
            damageableObject.TakeDamage(damage);
        }
    }
}
