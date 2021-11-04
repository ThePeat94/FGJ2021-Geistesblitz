using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private GameObject m_startMenu;
        [SerializeField] private GameObject m_credits;

        public void StartGame()
        {
            SceneManager.LoadScene(1);
        }

        public void QuitApplication()
        {
            Application.Quit();
        }

        public void ShowCredits()
        {
            this.m_startMenu.SetActive(false);
            this.m_credits.SetActive(true);
        }

        public void BackFromCreditsToStart()
        {
            this.m_startMenu.SetActive(true);
            this.m_credits.SetActive(false);
        }

        public void OpenLink(string url)
        {
            Application.OpenURL(url);
        }
    }
}
