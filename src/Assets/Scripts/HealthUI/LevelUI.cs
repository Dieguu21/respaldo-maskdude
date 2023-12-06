using System;
using TMPro;
using UnityEngine;

namespace MaskDudeFruitCollecter.HealthUI
{
    public class LevelUI : MonoBehaviour, HealthObserver
    {
        [SerializeField] private TextMeshProUGUI healthOnScreen;

        private void SetHealthOnScreen(float healthPoints)
        {
            healthOnScreen.text = Convert.ToString(healthPoints);
        }

        public void HealthIsUpdated(Player.Player player)
        {
            float playerHealthPoints = player.GetHealthPoints();
            SetHealthOnScreen(playerHealthPoints);
        }
    }
}
