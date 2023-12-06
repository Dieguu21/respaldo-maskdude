using UnityEngine;
using UnityEngine.UI;

namespace MaskDudeFruitCollecter.Menus.LevelMenus
{
    public class PauseButton : MonoBehaviour
    {
        [SerializeField] private Button pauseLevelButton;
        
        [SerializeField] private LevelManager levelManager;
        private MenuMediator levelMenuMediator;

        private void Start()
        {
            pauseLevelButton.onClick.AddListener(PauseLevel);
            
            levelMenuMediator = levelManager.GetComponent(typeof(MenuMediator)) as MenuMediator;
        }

        private void PauseLevel() => levelMenuMediator.NotifyButtonPressed(gameObject, "PauseLevel");
    }
}