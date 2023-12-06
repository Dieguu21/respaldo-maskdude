using MaskDudeFruitCollecter.Tools;
using UnityEngine;

namespace MaskDudeFruitCollecter.Droppables
{
    public class BrokenBoxController : MonoBehaviour
    {
        private Timer timer;
    
        void Start()
        {
            timer = GetComponent<Timer>();
        }

        void Update()
        {
            if (timer.GetSecondsSinceStart() > 1.2)
                DestroyAllPiecesOnScene();
        }

        private void DestroyAllPiecesOnScene() => Destroy(gameObject);
    
    }
}
