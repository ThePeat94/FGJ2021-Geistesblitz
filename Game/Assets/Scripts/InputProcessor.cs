using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputProcessor : MonoBehaviour
{
    private PlayerInput m_playerInput;
    private Vector2 m_movementInput;

    public Vector2 Movement => this.m_movementInput.normalized;
    public Vector2 MouseScreenPosition { get; private set; }
    public bool InteractTriggered => this.m_playerInput.Actions.Interact.triggered;
    public bool InspectTriggered => this.m_playerInput.Actions.Inspect.triggered;
    public bool ShootTriggered { get; private set; }
    public bool DashTriggered => this.m_playerInput.Actions.Dash.triggered;

    private void Awake()
    {
        this.m_playerInput = new PlayerInput();
    }

    private void OnEnable()
    {
        this.m_playerInput?.Enable();
        this.m_playerInput.Actions.Shoot.started += this.OnShootStarted;
        this.m_playerInput.Actions.Shoot.canceled += this.OnShootCanceled;
    }

    private void OnShootStarted(InputAction.CallbackContext obj)
    {
        this.ShootTriggered = true;
    }

    private void OnShootCanceled(InputAction.CallbackContext obj)
    {
        this.ShootTriggered = false;
    }
    
    private void Update()
    {
        this.m_movementInput = this.m_playerInput.Actions.Move.ReadValue<Vector2>();
        this.MouseScreenPosition = this.m_playerInput.Actions.MouseTracking.ReadValue<Vector2>();
    }

    private void OnDisable()
    {
        this.m_playerInput?.Disable();
        this.m_movementInput = Vector3.zero;
        this.m_playerInput.Actions.Shoot.started -= this.OnShootStarted;
        this.m_playerInput.Actions.Shoot.canceled -= this.OnShootCanceled;
    }
}
