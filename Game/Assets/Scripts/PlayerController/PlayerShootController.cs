using System;
using Scriptables;
using Unity.VisualScripting;
using UnityEngine;

namespace UnityTemplateProjects
{
    public class PlayerShootController : MonoBehaviour
    {
        [SerializeField] private PlayerData m_playerData;

        private InputProcessor m_inputProcessor;
        private int m_currentFramesCooldown;
        
        private void Awake()
        {
            this.m_inputProcessor = this.GetComponent<InputProcessor>();
        }

        private void Update()
        {
            if (this.m_inputProcessor.ShootTriggered)
            {
                this.Shoot();
            }
        }

        private void FixedUpdate()
        {
            if(this.m_currentFramesCooldown <= this.m_playerData.ShootFramesCooldown)
                this.m_currentFramesCooldown++;
        }

        private void Shoot()
        {
            if (this.m_currentFramesCooldown <= this.m_playerData.ShootFramesCooldown) return;

            var instantiatedProjectile = Instantiate(this.m_playerData.ProjectilePrefab);
            instantiatedProjectile.transform.position = this.transform.position + this.transform.forward;
            instantiatedProjectile.GetComponent<Projectile>().ShootDirection = this.transform.forward;

            this.m_currentFramesCooldown = 0;
        }
    }
}