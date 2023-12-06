using UnityEngine;

namespace MaskDudeFruitCollecter.Enemies.EnemyMovement
{
    public class PatrolGroundChecker : MonoBehaviour
    {
        private bool isGoingToCollide;
        
        private void OnTriggerEnter2D(Collider2D collidedCollider)
        {
            if (collidedCollider.gameObject.CompareTag("MapTiles"))
            {
                isGoingToCollide = true;
            }
        }
        
        private void OnTriggerExit2D(Collider2D collidedCollider)
        {
            isGoingToCollide = false;
        }

        public bool IsGoingToHitGround() => isGoingToCollide;
        
    }
}
