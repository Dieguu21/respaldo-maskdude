using UnityEngine;

namespace MaskDudeFruitCollecter.Player
{
    public class PlayerGroundChecker : MonoBehaviour
    {
        public static bool IsGrounded;

        private void OnTriggerEnter2D(Collider2D collision) => IsGrounded = true;
        private void OnTriggerExit2D(Collider2D other) => IsGrounded = false;
    }
}
