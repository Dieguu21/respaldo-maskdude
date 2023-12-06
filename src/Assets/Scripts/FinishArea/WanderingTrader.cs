using UnityEngine;

namespace MaskDudeFruitCollecter.FinishArea
{
    public class WanderingTrader : MonoBehaviour
    {
        private Animator animator;
        void Start()
        {
            animator = GetComponent<Animator>();
        }

        public void MakeHappy()
        {
            animator.SetTrigger("isHappy");
        }
    }
}
