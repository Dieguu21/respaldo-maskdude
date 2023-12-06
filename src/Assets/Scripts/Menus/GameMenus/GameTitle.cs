using MaskDudeFruitCollecter.Tools;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MaskDudeFruitCollecter.Menus.GameMenus
{
    public class GameTitle : MonoBehaviour
    {
        private Timer timer;
    
        void Start()
        {
            timer = GetComponent<Timer>();
        }
    
        void Update()
        {
            if (timer.GetSecondsSinceStart() > 5)
                OpenMainMenu();
        }

        public void OpenMainMenu()
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
