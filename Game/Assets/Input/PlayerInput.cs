// GENERATED AUTOMATICALLY FROM 'Assets/Input/PlayerInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerInput : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInput"",
    ""maps"": [
        {
            ""name"": ""Actions"",
            ""id"": ""31318777-1404-478a-926d-2557c940dbe7"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Button"",
                    ""id"": ""d35e711b-4713-44a7-9a73-b71533b22e7f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""eaa44061-bd1f-43b3-ae82-6083ca58b276"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Inspect"",
                    ""type"": ""Button"",
                    ""id"": ""c0f3be09-17f1-4d3a-a71f-5289a0cd2822"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""ff2b652a-8e80-43b8-8204-37a942c8c813"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Dash"",
                    ""type"": ""Button"",
                    ""id"": ""078352b1-a669-49c8-ae36-1f5764643352"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MouseTracking"",
                    ""type"": ""Value"",
                    ""id"": ""2befe50c-0e17-4440-a633-01f16902df48"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Restart"",
                    ""type"": ""Button"",
                    ""id"": ""220dc248-79b9-4439-a1dc-164dd6c7370d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Keys"",
                    ""id"": ""2c4be5f8-52f7-4252-ba6b-d85c26c19fd6"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""0fc86b36-f813-410a-85a4-72e731b2a40d"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""e970f0da-b3f8-4097-90f0-fa89e4eef2c6"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""ceac21aa-fd2b-4241-bff6-951da8d8b2e6"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""c7e000f5-c8df-4eea-b9a8-d92364b9312a"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""83e05aca-594e-4b05-8c7e-88115e2ee45d"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d94e583d-fef5-4485-9cf3-4d5b36ef68ae"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Inspect"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ba39a14c-6acf-43a6-8474-b5d362fb3756"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""caebd682-1861-46aa-8a68-0acd8b51531e"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4882b177-5989-4f56-9d65-72e0d0291b27"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseTracking"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""953f6c25-7121-4f6f-9953-e1c244ee2ec6"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Restart"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Actions
        m_Actions = asset.FindActionMap("Actions", throwIfNotFound: true);
        m_Actions_Move = m_Actions.FindAction("Move", throwIfNotFound: true);
        m_Actions_Interact = m_Actions.FindAction("Interact", throwIfNotFound: true);
        m_Actions_Inspect = m_Actions.FindAction("Inspect", throwIfNotFound: true);
        m_Actions_Shoot = m_Actions.FindAction("Shoot", throwIfNotFound: true);
        m_Actions_Dash = m_Actions.FindAction("Dash", throwIfNotFound: true);
        m_Actions_MouseTracking = m_Actions.FindAction("MouseTracking", throwIfNotFound: true);
        m_Actions_Restart = m_Actions.FindAction("Restart", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Actions
    private readonly InputActionMap m_Actions;
    private IActionsActions m_ActionsActionsCallbackInterface;
    private readonly InputAction m_Actions_Move;
    private readonly InputAction m_Actions_Interact;
    private readonly InputAction m_Actions_Inspect;
    private readonly InputAction m_Actions_Shoot;
    private readonly InputAction m_Actions_Dash;
    private readonly InputAction m_Actions_MouseTracking;
    private readonly InputAction m_Actions_Restart;
    public struct ActionsActions
    {
        private @PlayerInput m_Wrapper;
        public ActionsActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Actions_Move;
        public InputAction @Interact => m_Wrapper.m_Actions_Interact;
        public InputAction @Inspect => m_Wrapper.m_Actions_Inspect;
        public InputAction @Shoot => m_Wrapper.m_Actions_Shoot;
        public InputAction @Dash => m_Wrapper.m_Actions_Dash;
        public InputAction @MouseTracking => m_Wrapper.m_Actions_MouseTracking;
        public InputAction @Restart => m_Wrapper.m_Actions_Restart;
        public InputActionMap Get() { return m_Wrapper.m_Actions; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ActionsActions set) { return set.Get(); }
        public void SetCallbacks(IActionsActions instance)
        {
            if (m_Wrapper.m_ActionsActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_ActionsActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_ActionsActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_ActionsActionsCallbackInterface.OnMove;
                @Interact.started -= m_Wrapper.m_ActionsActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_ActionsActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_ActionsActionsCallbackInterface.OnInteract;
                @Inspect.started -= m_Wrapper.m_ActionsActionsCallbackInterface.OnInspect;
                @Inspect.performed -= m_Wrapper.m_ActionsActionsCallbackInterface.OnInspect;
                @Inspect.canceled -= m_Wrapper.m_ActionsActionsCallbackInterface.OnInspect;
                @Shoot.started -= m_Wrapper.m_ActionsActionsCallbackInterface.OnShoot;
                @Shoot.performed -= m_Wrapper.m_ActionsActionsCallbackInterface.OnShoot;
                @Shoot.canceled -= m_Wrapper.m_ActionsActionsCallbackInterface.OnShoot;
                @Dash.started -= m_Wrapper.m_ActionsActionsCallbackInterface.OnDash;
                @Dash.performed -= m_Wrapper.m_ActionsActionsCallbackInterface.OnDash;
                @Dash.canceled -= m_Wrapper.m_ActionsActionsCallbackInterface.OnDash;
                @MouseTracking.started -= m_Wrapper.m_ActionsActionsCallbackInterface.OnMouseTracking;
                @MouseTracking.performed -= m_Wrapper.m_ActionsActionsCallbackInterface.OnMouseTracking;
                @MouseTracking.canceled -= m_Wrapper.m_ActionsActionsCallbackInterface.OnMouseTracking;
                @Restart.started -= m_Wrapper.m_ActionsActionsCallbackInterface.OnRestart;
                @Restart.performed -= m_Wrapper.m_ActionsActionsCallbackInterface.OnRestart;
                @Restart.canceled -= m_Wrapper.m_ActionsActionsCallbackInterface.OnRestart;
            }
            m_Wrapper.m_ActionsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
                @Inspect.started += instance.OnInspect;
                @Inspect.performed += instance.OnInspect;
                @Inspect.canceled += instance.OnInspect;
                @Shoot.started += instance.OnShoot;
                @Shoot.performed += instance.OnShoot;
                @Shoot.canceled += instance.OnShoot;
                @Dash.started += instance.OnDash;
                @Dash.performed += instance.OnDash;
                @Dash.canceled += instance.OnDash;
                @MouseTracking.started += instance.OnMouseTracking;
                @MouseTracking.performed += instance.OnMouseTracking;
                @MouseTracking.canceled += instance.OnMouseTracking;
                @Restart.started += instance.OnRestart;
                @Restart.performed += instance.OnRestart;
                @Restart.canceled += instance.OnRestart;
            }
        }
    }
    public ActionsActions @Actions => new ActionsActions(this);
    public interface IActionsActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnInspect(InputAction.CallbackContext context);
        void OnShoot(InputAction.CallbackContext context);
        void OnDash(InputAction.CallbackContext context);
        void OnMouseTracking(InputAction.CallbackContext context);
        void OnRestart(InputAction.CallbackContext context);
    }
}
