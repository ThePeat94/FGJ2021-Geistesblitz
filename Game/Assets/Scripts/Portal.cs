using System;
using UnityEngine;

namespace UnityTemplateProjects
{
    public class Portal : MonoBehaviour
    {
        [SerializeField] private GameLevelController m_gameLevelController;

        private void OnTriggerEnter(Collider other)
        {
            if(other.GetComponent<PlayerMovementController>() != null)
                this.m_gameLevelController.FinishLevel();
        }
    }
}