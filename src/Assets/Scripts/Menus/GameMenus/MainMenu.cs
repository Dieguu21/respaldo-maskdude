using UnityEngine;
using UnityEngine.SceneManagement;

namespace MaskDudeFruitCollecter.Menus.GameMenus
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private GameObject optionsMenu;
    
        public void OpenLevelsMenu()
        {
            SceneManager.LoadScene("LevelsMenu");
        }

        public void OpenInfoMenu()
        {
            gameObject.SetActive(false);
            optionsMenu.SetActive(true);
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}
