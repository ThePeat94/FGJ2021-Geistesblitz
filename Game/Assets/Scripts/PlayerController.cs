using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Scriptables;
using UI;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private static PlayerController s_instance;

    [SerializeField] private PlayerData m_playerData;

    private Vector3 m_moveDirection;
    private CharacterController m_characterController;
    private InputProcessor m_inputProcessor;
    private Animator m_animator;
    private GameObject m_currentInteractable;
    
    private static readonly int s_isWalkingHash = Animator.StringToHash("IsWalking");

    public static PlayerController Instance => s_instance;
    
    
    private void Awake()
    {
        if (s_instance == null)
        {
            s_instance = this;
        }
        else
        {
            Destroy(this.gameObject);
            return;
        }
        
        this.m_inputProcessor = this.GetComponent<InputProcessor>();
        this.m_characterController = this.GetComponent<CharacterController>();
        this.m_animator = this.GetComponent<Animator>();
    }
    
    // Update is called once per frame
    void Update()
    {
        this.Move();
        this.Rotate();
    }

    private void LateUpdate()
    {
        this.UpdateAnimator();
    }
    
    protected void Move()
    {
        this.m_moveDirection = new Vector3(this.m_inputProcessor.Movement.x, Physics.gravity.y, this.m_inputProcessor.Movement.y);
        this.m_characterController.Move(this.m_moveDirection * Time.deltaTime * this.m_playerData.MovementSpeed);
    }
        
    private void Rotate()
    {
        var targetDir = this.m_moveDirection;
        targetDir.y = 0f;

        if (targetDir == Vector3.zero)
            targetDir = this.transform.forward;
    
        this.RotateTowards(targetDir);
    }

    private void RotateTowards(Vector3 dir)
    {
        var lookRotation = Quaternion.LookRotation(dir.normalized);
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, lookRotation, this.m_playerData.RotationSpeed * Time.deltaTime);
    }

    private void UpdateAnimator()
    {
        this.m_animator.SetBool(s_isWalkingHash, this.m_moveDirection != Physics.gravity);
    }


}
