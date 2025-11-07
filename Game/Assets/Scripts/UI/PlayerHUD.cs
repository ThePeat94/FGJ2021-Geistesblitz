using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class PlayerHUD : MonoBehaviour
    {
        [SerializeField] private UpgradeMeterUI m_healthUpgradeUi;
        [SerializeField] private UpgradeMeterUI m_attackUpgradeUi;
        [SerializeField] private UpgradeMeterUI m_speedUpgradeUi;
        [SerializeField] private GameObject m_gameOverScreen;
        [SerializeField] private GameObject m_levelWonScreen;
        
        
        private static PlayerHUD s_instance;
        public static PlayerHUD Instance => s_instance;

        private void Awake()
        {
            s_instance = this;
        }

        private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
        {
            this.m_attackUpgradeUi.ResetSlider();
            this.m_speedUpgradeUi.ResetSlider();
            this.m_attackUpgradeUi.ResetSlider();
            this.m_gameOverScreen.SetActive(false);
            this.m_levelWonScreen.SetActive(false);
        }

        public void Show()
        {
            this.gameObject.SetActive(true);
        }

        public void Hide()
        {
            this.gameObject.SetActive(false);
        }

        public void IncreaseHealthMeter()
        {
            this.m_healthUpgradeUi.IncreaseSlider();
        }

        public void IncreaseSpeedMeter()
        {
            this.m_speedUpgradeUi.IncreaseSlider();
        }
        
        public void IncreaseAttackMeter()
        {
            this.m_attackUpgradeUi.IncreaseSlider();
        }
        
        public void ShowGameOverScreen()
        {
            this.m_gameOverScreen.SetActive(true);
        }

        public void ShowLevelDoneScreen()
        {
            this.m_levelWonScreen.SetActive(true);
        }

        public void ShowGameWonScreen()
        {
        }
    }
}