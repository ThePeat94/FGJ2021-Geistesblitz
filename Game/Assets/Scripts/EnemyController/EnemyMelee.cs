
using EventArgs;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public partial class EnemyMelee : MonoBehaviour
{
    [SerializeField] private NavMeshAgent m_agent;
    private Transform m_player;

    [SerializeField] private LayerMask m_whatIsGround, m_whatIsPlayer;
    //Patroling
    private Vector3 m_walkPoint;
    bool walkPointSet;
    [SerializeField] private float m_walkPointRange = 10;
    
    [SerializeField] private float m_timeBetweenAttacks = 1;
    bool alreadyAttacked;

    //States
    [SerializeField] private float m_sightRange = 15, m_attackRange = 1;
    private bool m_playerInSightRange, m_playerInAttackRange;

    //Health Bar
    [SerializeField] public Slider m_healthBar;
    
    private void Awake()
    {
        m_player = PlayerMovementController.Instance.transform;
        m_agent = GetComponent<NavMeshAgent>();
        
        this.GetComponent<HealthController>().HealthDownToZero += this.OnHealthDownToZero;
        this.GetComponent<HealthController>().GetResourceController().ResourceValueChanged += this.OnHealthChanged;
        this.GetComponent<HealthController>().GetResourceController().MaxValueChanged += this.OnMaxHealthChanged;
    }

    private void Update()
    {
        //Check for sight and attack range
        m_playerInSightRange = Physics.CheckSphere(transform.position, m_sightRange, m_whatIsPlayer);
        m_playerInAttackRange = Physics.CheckSphere(transform.position, m_attackRange, m_whatIsPlayer);
        if (!m_playerInSightRange && !m_playerInAttackRange) Patroling();
        if (m_playerInSightRange && !m_playerInAttackRange) ChasePlayer();
        if (m_playerInAttackRange && m_playerInSightRange) AttackPlayer();
    }

    private void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            m_agent.SetDestination(m_walkPoint);

        Vector3 distanceToWalkPoint = transform.position - m_walkPoint;

        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }
    private void SearchWalkPoint()
    {
        //Calculate random point in range
        float randomZ = Random.Range(-m_walkPointRange, m_walkPointRange);
        float randomX = Random.Range(-m_walkPointRange, m_walkPointRange);

        m_walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(m_walkPoint, -transform.up, 2f, m_whatIsGround))
            walkPointSet = true;
    }

    private void ChasePlayer()
    {
        m_agent.SetDestination(m_player.position);
    }

    private void AttackPlayer()
    {
        //Make sure enemy doesn't move
        m_agent.SetDestination(transform.position);

        transform.LookAt(m_player);

        if (!alreadyAttacked)
        {
            // MELEE ATTACK
            m_player.GetComponent<HealthController>().TakeDamage(1);
            
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), m_timeBetweenAttacks);
        }
    }
    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    public void TakeDamage(int damage)
    {
        this.GetComponent<HealthController>().TakeDamage(damage);
    }
    
    private void OnHealthChanged(object sender, ResourceValueChangedEventArgs e)
    {
        this.m_healthBar.value = (e.NewValue / this.GetComponent<HealthController>().GetResourceController().MaxValue);
    }
    
    private void OnMaxHealthChanged(object sender, ResourceValueChangedEventArgs e)
    {
        this.m_healthBar.value = (this.GetComponent<HealthController>().GetResourceController().CurrentValue / e.NewValue);
    }
    
    private void OnHealthDownToZero(object sender, System.EventArgs e)
    {
        this.DestroyEnemy();
    }
    
    private void DestroyEnemy()
    {
        this.GetComponent<HealthController>().HealthDownToZero -= this.OnHealthDownToZero;
        Destroy(gameObject);
    }
}
