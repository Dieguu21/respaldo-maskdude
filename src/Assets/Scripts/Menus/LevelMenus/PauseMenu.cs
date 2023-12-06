using UnityEngine;
using UnityEngine.UI;

namespace MaskDudeFruitCollecter.Menus.LevelMenus
{
    public class PauseMenu : MonoBehaviour
    {
        [Header("Buttons")]
        [SerializeField] private Button resumeLevelButton;
        [SerializeField] private Button restartLevelButton;
        [SerializeField] private Button quitLevelButton;

        [SerializeField] private LevelManager levelManager;
        private MenuMediator levelMenuMediator;

        private void Start()
        {
            resumeLevelButton.onClick.AddListener(ResumeLevel);
            restartLevelButton.onClick.AddListener(RestartLevel);
            quitLevelButton.onClick.AddListener(QuitLevel);

            levelMenuMediator = levelManager.GetComponent(typeof(MenuMediator)) as MenuMediator;
        }

        private void ResumeLevel() => levelMenuMediator.NotifyButtonPressed(gameObject, "ResumeLevel");
        private void RestartLevel() => levelMenuMediator.NotifyButtonPressed(gameObject, "RestartLevel");
        private void QuitLevel() => levelMenuMediator.NotifyButtonPressed(gameObject, "QuitLevel");
        
    }
}