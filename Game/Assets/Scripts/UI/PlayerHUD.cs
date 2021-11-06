using System;
using UnityEngine;

namespace UI
{
    public class PlayerHUD : MonoBehaviour
    {
        private static PlayerHUD s_instance;
        public static PlayerHUD Instance => s_instance;

        private void Awake()
        {
            DontDestroyOnLoad(this.gameObject);
        }

        public void Show()
        {
            this.gameObject.SetActive(true);
        }

        public void Hide()
        {
            this.gameObject.SetActive(false);
        }

        public void ShowGameOverScreen()
        {
        }

        public void ShowLevelDoneScreen()
        {
        }

        public void ShowGameWonScreen()
        {
        }
    }
}