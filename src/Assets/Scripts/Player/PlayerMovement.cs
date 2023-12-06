using UnityEngine;

namespace MaskDudeFruitCollecter.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        public bool CanMove { get; set; } = true;

        [Header("HorizontalMovement")]
        [SerializeField] private float horizontalSpeed;
        [SerializeField] private bool betterHorizontalMovement;
        [Range(0, 0.3f)][SerializeField] private float velocitySmoothTime;
    
        [Header("VerticalMovement")]
        [SerializeField] private float verticalSpeed;
        [SerializeField] private bool betterVerticalMovement;
        [SerializeField] private float fallMultiplier = 0.5f;
        [SerializeField] private float lowJumpMultiplier = 1f;

        [Header("BouncingMovement")]
        [SerializeField] private Vector2 bounceForce;
        
        private Rigidbody2D rigidbody;

        void Start()
        {
            rigidbody = GetComponent<Rigidbody2D>();
        }

        void FixedUpdate()
        {
            if (CanMove)
            {
                MoveHorizontalIfAppropriate();
                MoveVerticalIfAppropriate();
            }
            
        }
    
        private void MoveHorizontalIfAppropriate()
        {
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                MoveHorizontal(horizontalSpeed);
                FlipRight();
            
            }
            else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                MoveHorizontal(-horizontalSpeed);
                FlipLeft();
            
            }
            else
                StopHorizontalMovement();
        }

        private void FlipRight() => transform.eulerAngles = new Vector3(0, 0, 0);
        
        private void FlipLeft() => transform.eulerAngles = new Vector3(0, 180, 0);

        private void MoveHorizontal(float speed)
        {
            Vector2 currentVelocity = rigidbody.velocity;
            Vector2 targetVelocity = new Vector2(speed, currentVelocity.y);
            if (betterHorizontalMovement)
                rigidbody.velocity = Vector2.SmoothDamp(currentVelocity, targetVelocity, ref currentVelocity, velocitySmoothTime);
            else
                rigidbody.velocity = targetVelocity;
        }

        public void StopHorizontalMovement()
        {
            rigidbody.velocity = new Vector2(0, rigidbody.velocity.y);
        }

        private void MoveVerticalIfAppropriate()
        {
            if (Input.GetKey(KeyCode.Space) && PlayerIsGrounded())
                MoveVertical(verticalSpeed);
            if (betterVerticalMovement)
                ApplyPostVerticalMovementMultipliers();
        }

        private void MoveVertical(float speed)
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, verticalSpeed);
        }

        public void ApplyPostVerticalMovementMultipliers()
        {
            if (rigidbody.velocity.y < 0)
                rigidbody.velocity += Vector2.up * Physics2D.gravity.y * fallMultiplier * Time.deltaTime;

            if (rigidbody.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
                rigidbody.velocity += Vector2.up * Physics2D.gravity.y * lowJumpMultiplier * Time.deltaTime;
        }

        public bool IsRunning() => 
            PlayerIsGrounded() && (rigidbody.velocity.x > 0.001f | rigidbody.velocity.x < -0.001f);
    
        public bool IsJumping() =>
            !PlayerIsGrounded() && rigidbody.velocity.y > 0.0001f;
    
        public bool IsFalling() => 
            !PlayerIsGrounded() && rigidbody.velocity.y <= 0.0001f;
    

        private bool PlayerIsGrounded() => PlayerGroundChecker.IsGrounded;

        public void Bounce(Vector2 hitPoint)
        {
            rigidbody.AddForce(new Vector2(-bounceForce.x * hitPoint.x, bounceForce.y));
        }

    }
}
