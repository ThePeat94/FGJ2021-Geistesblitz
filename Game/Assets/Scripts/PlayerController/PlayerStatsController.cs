using System;
using Scriptables;
using Unity.VisualScripting;
using UnityEngine;

namespace UnityTemplateProjects
{
    public class PlayerStatsController : MonoBehaviour
    {
        [SerializeField] private PlayerData m_initialPlayerData;

        public float CurrentMovementSpeed { get; set; }
        public float CurrentDashDistance { get; set; }
        public int CurrentDashFramesCooldown { get; set; }
        public int CurrentShootFramesCooldown { get; set; }
        public int CurrentAttackDamage { get; set; }
        public int CurrentDefense { get; set; }

        private void Awake()
        {
            this.CurrentMovementSpeed = this.m_initialPlayerData.MovementSpeed;
            this.CurrentDashDistance = this.m_initialPlayerData.DashDistance;
            this.CurrentDefense = this.m_initialPlayerData.Defense;
            this.CurrentAttackDamage = this.m_initialPlayerData.AttackDamage;
            this.CurrentDashFramesCooldown = this.m_initialPlayerData.DashFramesCooldown;
            this.CurrentShootFramesCooldown = this.m_initialPlayerData.ShootFramesCooldown;
        }
    }
}