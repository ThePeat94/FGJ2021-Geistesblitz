using System;
using Scriptables;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

namespace UnityTemplateProjects
{
    public class PlayerShootController : MonoBehaviour
    {
        [SerializeField] private PlayerData m_playerData;
        [SerializeField] private Transform m_projectileSpawn;
        [SerializeField] private AudioClip m_lightningSound;
        [SerializeField] private AudioSource m_sfxPlayer;
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
                this.Shoot();
        }

        private void FixedUpdate()
        {
            if (this.m_currentFramesCooldown <= this.m_playerStatsController.CurrentShootFramesCooldown)
                this.m_currentFramesCooldown++;
        }

        private void Shoot()
        {
            if (this.m_currentFramesCooldown <= this.m_playerStatsController.CurrentShootFramesCooldown) return;
            var spreadShotCount = this.m_playerStatsController.CurrentSpreadShotCount;

            if (spreadShotCount % 2 == 0)
                this.ShootEvenAmount(spreadShotCount);
            else
                this.ShootOddAmount(spreadShotCount);

            this.m_sfxPlayer.clip = this.m_lightningSound;
            this.m_sfxPlayer.loop = false;
            this.m_sfxPlayer.Play();
            
            this.m_currentFramesCooldown = 0;
        }

        private void ShotHelper(float angle, GameObject projectileGO)
        {
            projectileGO.transform.RotateAround(projectileGO.transform.position, Vector3.up, angle);
            var projectile = projectileGO.GetComponent<Projectile>();
            projectile.ShootDirection = projectileGO.transform.forward;
            projectile.Sender = this.gameObject;
        }

        private void ShootOddAmount(int spreadAmount)
        {
            this.ShotHelper(0, 
                Instantiate(
                    this.m_playerData.ProjectilePrefab, 
                    this.m_projectileSpawn.position, 
                    this.transform.rotation
                )
            );

            this.ShootEvenAmount(spreadAmount - 1);
        }

        private void ShootEvenAmount(int spreadAmount)
        {
            var currentAngle = 20f;
            for (var i = 0; i < spreadAmount; i += 2)
            {
                this.ShotHelper(currentAngle, 
                    Instantiate(
                        this.m_playerData.ProjectilePrefab, 
                        this.m_projectileSpawn.position, 
                        this.transform.rotation
                    )
                );
                this.ShotHelper(-currentAngle, 
                    Instantiate(
                        this.m_playerData.ProjectilePrefab, 
                        this.m_projectileSpawn.position, 
                        this.transform.rotation
                    )
                );

                currentAngle += 20f;
            }
        }
    }
}