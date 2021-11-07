using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Scriptables;
using UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UnityTemplateProjects
{
    public class GameLevelController : MonoBehaviour
    {
        [SerializeField] private MeshGenerator m_meshGenerator;
        [SerializeField] private List<LevelData> m_levelData;
        private static int s_currentLevel;
        
        private static GameLevelController s_instance;
        private static WaitForSeconds s_levelDoneWaitTime = new WaitForSeconds(3);

        private void Awake()
        {
            LevelData toLoad;
            if (s_currentLevel >= this.m_levelData.Count)
                toLoad = this.m_levelData.Last();
            else
                toLoad = this.m_levelData[s_currentLevel];

            this.m_meshGenerator.Width = toLoad.Width;
            this.m_meshGenerator.Height = toLoad.Height;
            this.m_meshGenerator.Threshold= toLoad.Threshold;
            this.m_meshGenerator.Seed = UnityEngine.Random.Range(int.MinValue, int.MaxValue);
            
            this.m_meshGenerator.Generate();
        }

        public void FinishLevel()
        {
            s_currentLevel++;
            StartCoroutine(this.ProcessLevelDone());
        }

        private IEnumerator ProcessLevelDone()
        {
            PlayerHUD.Instance.ShowLevelDoneScreen();
            yield return s_levelDoneWaitTime;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        
    }
}