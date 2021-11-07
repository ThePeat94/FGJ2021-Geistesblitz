using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Scriptables;
using UI;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityTemplateProjects;

public class PlayerMovementController : MonoBehaviour
{
    private static PlayerMovementController s_instance;

    private PlayerStatsController m_playerStatsController;
    private Vector3 m_moveDirection;
    private CharacterController m_characterController;
    private InputProcessor m_inputProcessor;
    private Animator m_animator;
    private GameObject m_currentInteractable;
    private PlayerDashController m_playerDashController;
    private Vector3 m_mousePlayerPosition;

    private bool m_isGameOver;
    
    private static readonly int s_isWalkingHash = Animator.StringToHash("IsWalking");

    public static PlayerMovementController Instance => s_instance;


    private void Awake()
    {
        s_instance = this;
        this.m_playerStatsController = this.GetComponent<PlayerStatsController>();
        this.m_inputProcessor = this.GetComponent<InputProcessor>();
        this.m_playerDashController = this.GetComponent<PlayerDashController>();
        this.m_characterController = this.GetComponent<CharacterController>();
        this.m_animator = this.GetComponent<Animator>();
    }

    private void Start()
    {
        this.m_playerStatsController.HealthController.HealthDownToZero += this.OnDied;
    }

    private void OnDied(object sender, System.EventArgs e)
    {
        this.m_isGameOver = true;
        PlayerHUD.Instance.ShowGameOverScreen();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.m_isGameOver)
        {
            if (this.m_inputProcessor.RestartTriggered)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                return;
            }
            return;
        }
        
        if (this.m_playerDashController.IsDashing) return;
        
        var mouseRay = Camera.main.ScreenPointToRay(this.m_inputProcessor.MouseScreenPosition);
        var p = new Plane(Vector3.up, this.transform.position);
        if( p.Raycast( mouseRay, out float hitDist) ){
            Vector3 hitPoint = mouseRay.GetPoint(hitDist);
            this.m_mousePlayerPosition = hitPoint;
        }
        this.Move();
        this.Rotate();
    }

    private void LateUpdate()
    {
        // this.UpdateAnimator();
    }
    
    protected void Move()
    {
        this.m_moveDirection = new Vector3(this.m_inputProcessor.Movement.x, Physics.gravity.y, this.m_inputProcessor.Movement.y);
        this.m_characterController.Move(this.m_moveDirection * Time.deltaTime * this.m_playerStatsController.CurrentMovementSpeed);
    }
        
    private void Rotate()
    {
        this.transform.LookAt(this.m_mousePlayerPosition);
    }

    private void UpdateAnimator()
    {
        this.m_animator.SetBool(s_isWalkingHash, this.m_moveDirection != Physics.gravity);
    }


}
