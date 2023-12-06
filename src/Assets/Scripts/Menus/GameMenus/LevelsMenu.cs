using UnityEngine;
using UnityEngine.SceneManagement;

namespace MaskDudeFruitCollecter.Menus.GameMenus
{
    public class LevelsMenu : MonoBehaviour
    {
        public void BackToMainMenu()
        {
            SceneManager.LoadScene("MainMenu");
        }
    
        public void GoToLevel(string levelName)
        {
            SceneManager.LoadScene(levelName);
        }
    }
}
