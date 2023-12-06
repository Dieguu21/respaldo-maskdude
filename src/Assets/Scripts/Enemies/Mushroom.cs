using MaskDudeFruitCollecter.Core;
using MaskDudeFruitCollecter.Player;
using UnityEngine;

namespace MaskDudeFruitCollecter.Enemies
{
    public class Mushroom : MonoBehaviour, IDamageable
    {
        [SerializeField] private float healthPoints;
        
        [Header("Attack")]
        [SerializeField] private float attackDamage;
        [SerializeField] private float attackCooldown;
        private float cooldownTimer = 0;
        
        private Animator animator;

        private void Start()
        {
            animator = GetComponent<Animator>();
        }

        private void Update()
        {
            cooldownTimer += 1 * Time.deltaTime;
        }

        private void OnCollisionEnter2D(Collision2D collidedObject)
        {
            if (collidedObject.gameObject.CompareTag("Player"))
            {
                GameObject player = collidedObject.gameObject;
                ContactPoint2D hitPoint = collidedObject.GetContact(0);
                player.GetComponent<PlayerMovement>().Bounce(hitPoint.normal);
                if (hitPoint.normal.y <= -0.9)
                {
                    TakeDamage(healthPoints);
                }
                else
                {
                    if (cooldownTimer > attackCooldown)
                    {
                        player.GetComponent<Player.Player>().TakeDamage(attackDamage);
                        cooldownTimer = 0;
                    }
                    
                }
            }
        }

        private void KillIfAppropriate()
        {
            if (healthPoints <= 0)
                Destroy(gameObject);
        }

        public void TakeDamage(float damage)
        {
            healthPoints -= damage;
            animator.SetTrigger("isBeingHit");
        }
    }
}
