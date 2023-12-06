using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace MaskDudeFruitCollecter.Menus.LevelMenus
{
    public class LevelCompletedMenu : MonoBehaviour
    {
        [Header("UI")]
        [SerializeField] private TextMeshProUGUI levelNumber;
        [SerializeField] private TextMeshProUGUI timePlayed;
        [SerializeField] private TextMeshProUGUI fruitsSold;
        [SerializeField] private TextMeshProUGUI totalEarnings;
        
        [Header("Buttons")]
        [SerializeField] private Button nextLevelButton;
        [SerializeField] private Button restartLevelButton;
        [SerializeField] private Button GoToMenuButton;

        [SerializeField] private LevelManager levelManager;
        
        private MenuMediator levelMenuMediator;

        private void Start()
        {
            nextLevelButton.onClick.AddListener(GoToNextLevel);
            restartLevelButton.onClick.AddListener(RestartLevel);
            GoToMenuButton.onClick.AddListener(GoToMenu);
            
            levelMenuMediator = levelManager.GetComponent(typeof(MenuMediator)) as MenuMediator;
        }
        
        private void GoToNextLevel() => levelMenuMediator.NotifyButtonPressed(gameObject, "GoToNextLevel");
        private void RestartLevel() => levelMenuMediator.NotifyButtonPressed(gameObject, "RestartLevel");
        private void GoToMenu() => levelMenuMediator.NotifyButtonPressed(gameObject, "QuitLevel");
        
        public void SetStatsOnReceipt1()
        {
            levelNumber.text = Convert.ToString(GetLevelNumber());
            timePlayed.text = GetTimePlayedInMinutesAndSeconds();
            fruitsSold.text = Convert.ToString(GetAmountOfFruitsCollected()) + "      de     " + Convert.ToString(GetTotalAmountOfFrutsInMap());
            totalEarnings.text = Convert.ToString(GetAmountOfFruitsCollected()) + "  $";
        }

        private int GetLevelNumber()
        {
            return SceneManager.GetActiveScene().buildIndex - 2;
        }

        private string GetTimePlayedInMinutesAndSeconds()
        {
            float secondsPlayed = levelManager.GetSecondsPlayed();

            int timePlayedInMinutes = (int)(secondsPlayed / 60);
            int restOfTimeInSeconds = (int)(secondsPlayed - (timePlayedInMinutes * 60));
            
            return $"{timePlayedInMinutes}     min       {restOfTimeInSeconds}    s";
        }

        private int GetAmountOfFruitsCollected()
        {
            return levelManager.GetAmountOfFruitsCollectedByPlayer();
        }

        private int GetTotalAmountOfFrutsInMap()
        {
            return levelManager.GetTotalPriceOfFruitsInLevel();
        }
    }
}
