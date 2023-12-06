using UnityEngine;

namespace MaskDudeFruitCollecter.Menus.GameMenus
{
    public class InfoMenu : MonoBehaviour
    {
        [SerializeField] private GameObject mainMenu;
    
        public void BackToMainMenu()
        {
            gameObject.SetActive(false);
            mainMenu.SetActive(true);
        }
    }
}
