using UnityEngine;

namespace MaskDudeFruitCollecter.Blowgun
{
    public class PlayerBlowgun : MonoBehaviour
    {
        [SerializeField] private GameObject blowgunBullet;
        [SerializeField] private Transform firePoint;
    
        [SerializeField] private float shootingCooldown;
        private float cooldownTimer = 0;
    
        private Player.Player player;
        private SpriteRenderer spriteRenderer;

        void Start()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            player = GetComponentInParent<Player.Player>();
        }
    
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.K) && cooldownTimer > shootingCooldown && player.CanShoot())
            {
                player.StartShootingAnimation();
                Shoot();
            }
            cooldownTimer += 1 * Time.deltaTime;
        }

        private void Shoot()
        {
            Instantiate(blowgunBullet, firePoint.position, firePoint.rotation);
            cooldownTimer = 0;
        }
    
        public void DeactivateSpriteRenderer() => spriteRenderer.enabled = false;
        public void ActivateSpriteRenderer() => spriteRenderer.enabled = true;

    }
}
