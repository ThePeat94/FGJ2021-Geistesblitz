using System;
using System.Collections;
using UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UnityTemplateProjects
{
    public class GameLevelController : MonoBehaviour
    {
        [SerializeField] private MeshGenerator m_meshGenerator;
        private int m_currentLevel;
        
        private static GameLevelController s_instance;
        private static WaitForSeconds s_levelDoneWaitTime = new WaitForSeconds(3);

        private void Awake()
        {
            if (s_instance == null)
            {
                s_instance = this;
                DontDestroyOnLoad(this.gameObject);
                SceneManager.sceneLoaded += OnSceneLoaded;
            }
            else
            {
                Destroy(this.gameObject);
                return;
            }
        }

        public void FinishLevel()
        {
            StartCoroutine(this.ProcessLevelDone());
        }

        private IEnumerator ProcessLevelDone()
        {
            PlayerHUD.Instance.ShowLevelDoneScreen();
            yield return s_levelDoneWaitTime;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        
        private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
        {
            if(this.m_currentLevel > 0)
                this.m_meshGenerator.Generate();
        }
    }
}