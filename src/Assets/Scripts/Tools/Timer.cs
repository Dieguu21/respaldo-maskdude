using UnityEngine;

namespace MaskDudeFruitCollecter.Tools
{
    public class Timer : MonoBehaviour
    {
        private float StartTime;
        private float secondsSinceStart;
        private void Start() 
        {
            StartTime = Time.time;
        }
        private void Update()
        {
            float TimerControl = Time.time - StartTime;
            secondsSinceStart = (TimerControl % 60);
        }

        public float GetSecondsSinceStart() => secondsSinceStart;

    }
}
