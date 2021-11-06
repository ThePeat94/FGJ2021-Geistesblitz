using UnityEngine;

namespace Scriptables
{
    [CreateAssetMenu(fileName = "Player Data", menuName = "Data/Player Data", order = 0)]
    public class PlayerData : ScriptableObject
    {
        [SerializeField] private float m_movementSpeed;
        [SerializeField] private float m_rotationSpeed;
        [SerializeField] private float m_dashDistance;
        [SerializeField] private int m_dashFramesCooldown;
        [SerializeField] private int m_shootFramesCooldown;
        [SerializeField] private GameObject m_projectilePrefab;
        [SerializeField] private int m_attackDamage;
        [SerializeField] private int m_defense;

        public float MovementSpeed => this.m_movementSpeed;
        public float RotationSpeed => this.m_rotationSpeed;
        public float DashDistance => this.m_dashDistance;
        public int DashFramesCooldown => this.m_dashFramesCooldown;
        public int ShootFramesCooldown => this.m_shootFramesCooldown;
        public GameObject ProjectilePrefab => this.m_projectilePrefab;
        public int AttackDamage => this.m_attackDamage;
        public int Defense => this.m_defense;
    }
}