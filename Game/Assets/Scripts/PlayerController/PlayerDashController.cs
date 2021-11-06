using System;
using System.Collections;
using Scriptables;
using UnityEngine;
using UnityTemplateProjects.Utils;

namespace UnityTemplateProjects
{
    public class PlayerDashController : MonoBehaviour
    {
        [SerializeField] private LayerMask m_hitableLayers;
        
        private InputProcessor m_inputProcessor;
        private PlayerStatsController m_playerStatsController;
        private int m_currentDashFrameCooldown;
        
        private Vector3 m_currentDashTarget;
        private Coroutine m_dashCoroutine;

        public bool IsDashing => this.m_dashCoroutine != null;

        private void Awake()
        {
            this.m_inputProcessor = this.GetComponent<InputProcessor>();
            this.m_playerStatsController = this.GetComponent<PlayerStatsController>();
            this.m_currentDashFrameCooldown = this.m_playerStatsController.CurrentDashFramesCooldown;
        }

        private void Update()
        {
            if (this.m_inputProcessor.DashTriggered && this.m_dashCoroutine == null && this.CanDash())
            {
                this.Dash();
            }
        }

        private void Dash()
        {
            var dashDistance = this.m_inputProcessor.Movement * this.m_playerStatsController.CurrentDashDistance;
            this.m_currentDashTarget = this.transform.position + dashDistance.ToXZVector();
            this.m_dashCoroutine = this.StartCoroutine(this.PerformDash());
        }

        private IEnumerator PerformDash()
        {
            var traction = 0.55f;
            while (traction < 1f)
            {
                this.transform.position = Vector3.Lerp(this.transform.position, this.m_currentDashTarget, traction);
                traction += 0.05f;
                
                yield return new WaitForSeconds(0.01f);
            }
            this.m_currentDashFrameCooldown = 0;
            this.m_dashCoroutine = null;
        }

        private void FixedUpdate()
        {
            if (this.m_currentDashFrameCooldown <= this.m_playerStatsController.CurrentDashFramesCooldown && this.m_dashCoroutine == null)
                this.m_currentDashFrameCooldown++;
        }

        private bool CanDash() => 
             !Physics.Raycast(this.transform.position, 
                 this.m_inputProcessor.Movement.ToXZVector(), 
                 this.m_playerStatsController.CurrentDashDistance, 
                 this.m_hitableLayers) &&
             this.m_currentDashFrameCooldown > this.m_playerStatsController.CurrentDashFramesCooldown;
        
    }
}