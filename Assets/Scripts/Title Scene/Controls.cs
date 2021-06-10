// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Title Scene/Controls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Controls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""Move"",
            ""id"": ""00eed41f-b723-471a-83fd-1445202e4492"",
            ""actions"": [
                {
                    ""name"": ""Down"",
                    ""type"": ""PassThrough"",
                    ""id"": ""89a22c6b-2c1a-421c-a15c-9735d5f39fcd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Up"",
                    ""type"": ""Button"",
                    ""id"": ""94fa8b3e-80ea-4af6-898b-413d0e332764"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""77c0167d-d30f-4ef8-8955-38491177b9fd"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8c19d50a-ae4c-4d43-8ab2-339334294505"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Move
        m_Move = asset.FindActionMap("Move", throwIfNotFound: true);
        m_Move_Down = m_Move.FindAction("Down", throwIfNotFound: true);
        m_Move_Up = m_Move.FindAction("Up", throwIfNotFound: true);
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

    // Move
    private readonly InputActionMap m_Move;
    private IMoveActions m_MoveActionsCallbackInterface;
    private readonly InputAction m_Move_Down;
    private readonly InputAction m_Move_Up;
    public struct MoveActions
    {
        private @Controls m_Wrapper;
        public MoveActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Down => m_Wrapper.m_Move_Down;
        public InputAction @Up => m_Wrapper.m_Move_Up;
        public InputActionMap Get() { return m_Wrapper.m_Move; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MoveActions set) { return set.Get(); }
        public void SetCallbacks(IMoveActions instance)
        {
            if (m_Wrapper.m_MoveActionsCallbackInterface != null)
            {
                @Down.started -= m_Wrapper.m_MoveActionsCallbackInterface.OnDown;
                @Down.performed -= m_Wrapper.m_MoveActionsCallbackInterface.OnDown;
                @Down.canceled -= m_Wrapper.m_MoveActionsCallbackInterface.OnDown;
                @Up.started -= m_Wrapper.m_MoveActionsCallbackInterface.OnUp;
                @Up.performed -= m_Wrapper.m_MoveActionsCallbackInterface.OnUp;
                @Up.canceled -= m_Wrapper.m_MoveActionsCallbackInterface.OnUp;
            }
            m_Wrapper.m_MoveActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Down.started += instance.OnDown;
                @Down.performed += instance.OnDown;
                @Down.canceled += instance.OnDown;
                @Up.started += instance.OnUp;
                @Up.performed += instance.OnUp;
                @Up.canceled += instance.OnUp;
            }
        }
    }
    public MoveActions @Move => new MoveActions(this);
    public interface IMoveActions
    {
        void OnDown(InputAction.CallbackContext context);
        void OnUp(InputAction.CallbackContext context);
    }
}
