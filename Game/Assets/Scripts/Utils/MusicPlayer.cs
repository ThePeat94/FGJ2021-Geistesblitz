using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UnityTemplateProjects.Utils
{
    public class MusicPlayer : MonoBehaviour
    {
        [SerializeField] private AudioClip m_gameOverClip;
        [SerializeField] private AudioClip m_defaultQueue;
        [SerializeField] private AudioSource m_player;

        private static MusicPlayer s_instance;
        
        private void Awake()
        {
            if (s_instance == null)
            {
                DontDestroyOnLoad(this.gameObject);
                s_instance = this;
            }
            else
            {
                Destroy(this.gameObject);
            }
        }

        private void Start()
        {
            SceneManager.sceneLoaded += SceneManagerOnsceneLoaded;
        }

        private void LateUpdate()
        {
            this.transform.position = Camera.main.transform.position;
        }

        private void SceneManagerOnsceneLoaded(Scene arg0, LoadSceneMode arg1)
        {
            this.m_player.clip = this.m_defaultQueue;
            this.m_player.Play();
            this.m_player.loop = true;
        }

        public void PlayGameOver()
        {
            this.m_player.clip = this.m_gameOverClip;
            this.m_player.Play();
            this.m_player.loop = false;
        }
    }
}