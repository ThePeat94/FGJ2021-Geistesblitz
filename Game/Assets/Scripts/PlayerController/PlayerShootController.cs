using System;
using Scriptables;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

namespace UnityTemplateProjects
{
    public class PlayerShootController : MonoBehaviour
    {
        [SerializeField] private PlayerData m_playerData;
        private InputProcessor m_inputProcessor;
        private int m_currentFramesCooldown;
        
        private PlayerStatsController m_playerStatsController;
        
        private void Awake()
        {
            this.m_inputProcessor = this.GetComponent<InputProcessor>();
            this.m_playerStatsController = this.GetComponent<PlayerStatsController>();
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
            if(this.m_currentFramesCooldown <= this.m_playerStatsController.CurrentShootFramesCooldown)
                this.m_currentFramesCooldown++;
        }

        private void Shoot()
        {
            if (this.m_currentFramesCooldown <= this.m_playerStatsController.CurrentShootFramesCooldown) return;
            var spreadShotCount =  this.m_playerStatsController.CurrentSpreadShotCount;
            var instantiatedProjectile = Instantiate(this.m_playerData.ProjectilePrefab);
            var forward = this.transform.forward;
            double angle = 20.0;
            Debug.Log(spreadShotCount);
            if (spreadShotCount % 2 == 1)
            {
                ShotHelper(forward, 0, instantiatedProjectile);
            }

            for(var i = 1 ; i < spreadShotCount; i += 2 )
            {
                ShotHelper(forward, angle, Instantiate(this.m_playerData.ProjectilePrefab));
                ShotHelper(forward, angle,  Instantiate(this.m_playerData.ProjectilePrefab));
                angle += angle;
            }

            this.m_currentFramesCooldown = 0;
        }

        private void ShotHelper(Vector3 forward, double angle, GameObject projectile)
        {
            //TODO Winkelberechnung ist nicht ganz Richtig
            var dir = new Vector3( (float)(forward.x * Math.Cos(-angle) + forward.z * -Math.Sin(-angle)),
                forward.y, (float)(forward.x * Math.Sin(-angle) + forward.z * -Math.Cos(-angle)));
            projectile.transform.position = this.transform.position + dir;
            projectile.GetComponent<Projectile>().ShootDirection = dir;
        }
    }
}