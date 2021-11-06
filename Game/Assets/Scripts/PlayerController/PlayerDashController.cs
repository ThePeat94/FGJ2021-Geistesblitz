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
        [SerializeField] private PlayerData m_playerData;
        
        private InputProcessor m_inputProcessor;
        private int m_currentDashFrameCooldown;
        
        private Vector3 m_currentDashTarget;
        private Coroutine m_dashCoroutine;

        public bool IsDashing => this.m_dashCoroutine != null;

        private void Awake()
        {
            this.m_inputProcessor = this.GetComponent<InputProcessor>();
            this.m_currentDashFrameCooldown = this.m_playerData.DashFramesCooldown;
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
            var forwardMovement = this.transform.forward * this.m_inputProcessor.Movement.y;
            var sideMovement = this.transform.right * this.m_inputProcessor.Movement.x;
            var dashTarget = Vector3.Lerp(forwardMovement, sideMovement, 0.5f).normalized * this.m_playerData.DashDistance;
            dashTarget.y = 0f;
            this.m_currentDashTarget = this.transform.position + dashTarget;
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
            if (this.m_currentDashFrameCooldown <= this.m_playerData.DashFramesCooldown && this.m_dashCoroutine == null)
                this.m_currentDashFrameCooldown++;
        }

        private bool CanDash() => 
             !Physics.Raycast(this.transform.position, 
                 this.m_inputProcessor.Movement.ToXZVector(), 
                 this.m_playerData.DashDistance, 
                 1 << this.m_hitableLayers) &&
             this.m_currentDashFrameCooldown > this.m_playerData.DashFramesCooldown;
        
    }
}