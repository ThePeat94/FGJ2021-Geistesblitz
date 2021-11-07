using System;
using UnityEngine;

namespace UnityTemplateProjects
{
    public class Portal : MonoBehaviour
    {
        [SerializeField] private GameLevelController m_gameLevelController;
        [SerializeField] private AudioSource m_finishedSource;
        private void OnTriggerEnter(Collider other)
        {
            if(other.GetComponent<PlayerMovementController>() != null)
            {
                this.m_gameLevelController.FinishLevel();
                this.m_finishedSource.Play();
            }
        }
    }
}