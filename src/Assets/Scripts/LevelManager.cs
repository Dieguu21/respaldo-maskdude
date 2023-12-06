using System.Collections.Generic;
using MaskDudeFruitCollecter.Droppables;
using MaskDudeFruitCollecter.HealthUI;
using MaskDudeFruitCollecter.Menus.LevelMenus;
using MaskDudeFruitCollecter.Tools;
using UnityEngine;

namespace MaskDudeFruitCollecter
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private Player.Player player;
        [SerializeField] private GameObject openingTransition;
        [SerializeField] private GameObject closingTransition;
    
        [SerializeField] private GameObject pauseButton;
        [SerializeField] private GameObject pauseMenu;
        [SerializeField] private GameObject levelCompletedMenu;
        [SerializeField] private GameObject healthBar;

        [SerializeField] private List<Fruit> fruitsInLevel;
        [SerializeField] private List<Box> boxesInLevel;

        [SerializeField] private FinishArea.FinishArea finishArea;

        private LevelUI levelUI;
        private Timer timer;
    
        private bool levelIsPaused = false;

        void Start()
        {
            levelUI = GetComponent<LevelUI>();
            timer = GetComponent<Timer>();

            player.SubscribeToHealthUpdates(levelUI);
        
            openingTransition.SetActive(true);
            Invoke("EnablePauseButton", 0.3f);
            healthBar.SetActive(true);
        }

        void Update()
        {
            if (LevelIsCleared())
            {
                DisablePauseButton();
                healthBar.SetActive(false);
                closingTransition.SetActive(true);
            
                levelCompletedMenu.GetComponent<LevelCompletedMenu>().SetStatsOnReceipt1();
            
                Invoke("OpenLevelCompletedMenu", 0.7f);
            }
        
        }

        private bool LevelIsCleared() => finishArea.PlayerReachedFinishLine();

        private void OpenLevelCompletedMenu()
        {
            Time.timeScale = 0f;
            levelCompletedMenu.SetActive(true);
        }
    
        private void DisablePauseButton() => pauseButton.SetActive(false);

        private void EnablePauseButton() => pauseButton.SetActive(true);

        public int GetTotalPriceOfFruitsInLevel()
        {
            int displayedFruitsPrice = GetPriceOfDisplayedFruits();
            int boxedFruitsPrice = GetPriceOfBoxedFruits();
        
            return displayedFruitsPrice + boxedFruitsPrice;
        }

        private int GetPriceOfDisplayedFruits()
        {
            int totalPrice = 0;
            foreach (var fruit in fruitsInLevel)
            {
                int fruitPrice = fruit.GetTotalPrice();
                totalPrice += fruitPrice;
            }

            return totalPrice;
        }

        private int GetPriceOfBoxedFruits()
        {
            int totalPrice = 0;
            foreach (var box in boxesInLevel)
            {
                int boxPrice = box.GetTotalPrice();
                totalPrice += boxPrice;
            }

            return totalPrice;
        }

        public float GetSecondsPlayed()
        {
            return timer.GetSecondsSinceStart();
        }

        public int GetAmountOfFruitsCollectedByPlayer()
        {
            return player.GetAmountOfFruitsCollected();
        }
    }
}
