using UnityEngine;

namespace MaskDudeFruitCollecter.FinishArea
{
    public class FinishArea : MonoBehaviour
    {
        [SerializeField] private WanderingTrader wanderingTrader;

        private bool playerReachedFinishLine = false;
        
        private void OnTriggerEnter2D(Collider2D collidedObject)
        {
            if (collidedObject.CompareTag("Player"))
            {
                playerReachedFinishLine = true;
                wanderingTrader.MakeHappy();
            }
        }

        public bool PlayerReachedFinishLine() => playerReachedFinishLine;
    }
}
