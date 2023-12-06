using System.Collections.Generic;
using MaskDudeFruitCollecter.Blowgun;
using MaskDudeFruitCollecter.Core;
using MaskDudeFruitCollecter.HealthUI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MaskDudeFruitCollecter.Player
{
    public class Player : MonoBehaviour, IDamageable
    {
        [SerializeField] private float healthPoints;

        private int amountOfFruitsCollected = 0;

        private List<HealthObserver> healthObservers = new List<HealthObserver>();

        private PlayerMovement playerMovement;
        private Animator playerAnimator;
        private PlayerBlowgun playerBlowgun;

        public void AddOneFruitToCounter() => amountOfFruitsCollected++;

        public int GetAmountOfFruitsCollected() => amountOfFruitsCollected;

        public void SubscribeToHealthUpdates(HealthObserver healthObserver)
        {
            healthObservers.Add(healthObserver);
        }

        public void UnsubscribeFromHealthUpdates(HealthObserver healthObserver)
        {
            healthObservers.Remove(healthObserver);
        }

        private void NotifyHealthUpdate()
        {
            foreach (var healthObserver in healthObservers)
            {
                healthObserver.HealthIsUpdated(this);
            }
        }

        public float GetHealthPoints() => healthPoints;

        void Start()
        {
            playerMovement = GetComponent<PlayerMovement>();
            playerAnimator = GetComponent<Animator>();
            playerBlowgun = GetComponentInChildren<PlayerBlowgun>();
            
            NotifyHealthUpdate();
        }
    
        void FixedUpdate()
        {
            UpdateMovementAnimation();
            if (healthPoints <= 0)
            {
                Kill();
            }
        }
    
        private void UpdateMovementAnimation()
        {
            playerAnimator.SetBool("isRunning", playerMovement.IsRunning());
            playerAnimator.SetBool("isJumping", playerMovement.IsJumping());
            playerAnimator.SetBool("isFalling", playerMovement.IsFalling());
        }

        public void StartShootingAnimation()
        {
            playerBlowgun.ActivateSpriteRenderer();
            playerAnimator.SetTrigger("isShooting");
        }
    
        private void StopShootingAnimation()
        {
            playerBlowgun.DeactivateSpriteRenderer();
        }
    
        public bool CanShoot()
        {
            return !playerMovement.IsRunning() && !playerMovement.IsJumping() && !playerMovement.IsFalling();
        }

        private void OnTriggerEnter2D(Collider2D collidedObject)
        {
            if (collidedObject.CompareTag("Finish"))
            {
                playerMovement.CanMove = false;
                playerMovement.StopHorizontalMovement();
            }
        }

        private void OnTriggerExit2D(Collider2D collidedObject)
        {
            playerMovement.CanMove = true;
        }
        
        public void TakeDamage(float damage)
        {
            healthPoints -= damage;
            playerAnimator.SetTrigger("isBeingHit");
            NotifyHealthUpdate();
        }

        private void Kill()
        {
            Destroy(gameObject, 0.15f);
            Scene thisScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(thisScene.name);
        }
    }
}
