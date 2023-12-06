using UnityEngine;

namespace MaskDudeFruitCollecter.Enemies.EnemyMovement
{
    public class PatrolMovement : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private bool lookingRight;
        
        [Header("Raycast")]
        [SerializeField] private Transform raycastStartingPoint;
        [SerializeField] private float raycastDistance;
        
        [Header("Ground Checker")]
        [SerializeField] private PatrolGroundChecker groundChecker;

        private Rigidbody2D rigidbody;
        
        private void Start()
        {
            rigidbody = GetComponent<Rigidbody2D>();
        }
        
        private void FixedUpdate()
        {
            RaycastHit2D raycastHit = Physics2D.Raycast(raycastStartingPoint.position, Vector2.down, raycastDistance);
            rigidbody.velocity = new Vector2(speed, rigidbody.velocity.y);

            if (!raycastHit || groundChecker.IsGoingToHitGround())
                ChangeDirection();
        }

        private void ChangeDirection()
        {
            speed *= -1;

            if (lookingRight)
            {
                FlipLeft();
                lookingRight = false;
            }
            else
            {
                FlipRight();
                lookingRight = true;
            }
                
        }

        private void FlipRight() => transform.eulerAngles = new Vector3(0, 0, 0);
        
        private void FlipLeft() => transform.eulerAngles = new Vector3(0, 180, 0);

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Vector3 raycastStartingPosition = raycastStartingPoint.position;
            Vector3 raycastFinalPosition = raycastStartingPosition + Vector3.down * raycastDistance;
            Gizmos.DrawLine(raycastStartingPosition, raycastFinalPosition);
        }
        
        
    }
}
