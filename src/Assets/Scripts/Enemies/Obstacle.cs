using MaskDudeFruitCollecter.Core;
using UnityEngine;

namespace MaskDudeFruitCollecter.Enemies
{
    public class Obstacle : MonoBehaviour
    {
        [SerializeField] private float damage;
        
        private void OnTriggerEnter2D(Collider2D collidedCollider)
        {
            IDamageable damageableObject = collidedCollider.gameObject.GetComponent<IDamageable>();
            if (damageableObject != null)
                MakeDamage(damage, damageableObject);
        }

        private void MakeDamage(float damage, IDamageable damageableObject)
        {
            damageableObject.TakeDamage(damage);
        }
    }
}
