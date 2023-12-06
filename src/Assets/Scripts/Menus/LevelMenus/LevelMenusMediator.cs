using UnityEngine;
using UnityEngine.SceneManagement;

namespace MaskDudeFruitCollecter.Menus.LevelMenus
{
    public class LevelMenusMediator : MonoBehaviour, MenuMediator // LevelUI Mediatos? mejor nombre?
    {
        [SerializeField] private GameObject pauseButton;
        [SerializeField] private GameObject pauseMenu;
        [SerializeField] private GameObject levelCompletedMenu;

        public void NotifyButtonPressed(GameObject menuWhereButtonWasPressed, string actionToDo)
        {
            if (menuWhereButtonWasPressed == pauseButton)
                ReactOnPauseButton(actionToDo);
            
            else if (menuWhereButtonWasPressed == pauseMenu)
                ReactOnPauseMenu(actionToDo);
            
            else if (menuWhereButtonWasPressed == levelCompletedMenu)
                ReactOnLevelCompletedMenu(actionToDo);
        }

        private void ReactOnPauseButton(string actionToDo)
        {
            if (actionToDo == "PauseLevel")
            {
                Time.timeScale = 0f;
                pauseButton.SetActive(false);
                pauseMenu.SetActive(true);
            }
        }

        private void ReactOnPauseMenu(string actionToDo)
        {
            if (actionToDo == "ResumeLevel")
            {
                Time.timeScale = 1f;
                pauseMenu.SetActive(false);
                pauseButton.SetActive(true);
            }
            else if (actionToDo == "RestartLevel")
            {
                RestartLevel();
            }
            else if (actionToDo == "QuitLevel")
            {
                QuitLevel();
            }
        }

        private void ReactOnLevelCompletedMenu(string actionToDo)
        {
            if (actionToDo == "GoToNextLevel")
            {
                Time.timeScale = 1f;
                int thisLevelIndex = SceneManager.GetActiveScene().buildIndex;
                SceneManager.LoadScene(thisLevelIndex + 1);
            }
            else if (actionToDo == "RestartLevel")
            {
                RestartLevel();
            }
            else if (actionToDo == "QuitLevel")
            {
                QuitLevel();
            }
        }

        private void RestartLevel()
        {
            Time.timeScale = 1f;
            Scene thisLevel = SceneManager.GetActiveScene();
            SceneManager.LoadScene(thisLevel.name);
        }

        private void QuitLevel()
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene("LevelsMenu");
        }
        
        
    }
}
