// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Pregnancy Test/PregnancyTestControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PregnancyTestControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PregnancyTestControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PregnancyTestControls"",
    ""maps"": [
        {
            ""name"": ""Move"",
            ""id"": ""d75b78b6-b99e-49c1-ac60-63e96f1faeb8"",
            ""actions"": [
                {
                    ""name"": ""Moving"",
                    ""type"": ""PassThrough"",
                    ""id"": ""1a6d90a6-041b-4094-818b-6f4c320a4a1a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""bd2f4f92-1507-457d-97f5-ac6362fd229a"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Moving"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""590259fb-e210-4ef6-a5c1-742a25cdf0b3"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Moving"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""aba643b7-69b8-4899-a889-0aba66a8b0f6"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Moving"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Move
        m_Move = asset.FindActionMap("Move", throwIfNotFound: true);
        m_Move_Moving = m_Move.FindAction("Moving", throwIfNotFound: true);
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
    private readonly InputAction m_Move_Moving;
    public struct MoveActions
    {
        private @PregnancyTestControls m_Wrapper;
        public MoveActions(@PregnancyTestControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Moving => m_Wrapper.m_Move_Moving;
        public InputActionMap Get() { return m_Wrapper.m_Move; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MoveActions set) { return set.Get(); }
        public void SetCallbacks(IMoveActions instance)
        {
            if (m_Wrapper.m_MoveActionsCallbackInterface != null)
            {
                @Moving.started -= m_Wrapper.m_MoveActionsCallbackInterface.OnMoving;
                @Moving.performed -= m_Wrapper.m_MoveActionsCallbackInterface.OnMoving;
                @Moving.canceled -= m_Wrapper.m_MoveActionsCallbackInterface.OnMoving;
            }
            m_Wrapper.m_MoveActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Moving.started += instance.OnMoving;
                @Moving.performed += instance.OnMoving;
                @Moving.canceled += instance.OnMoving;
            }
        }
    }
    public MoveActions @Move => new MoveActions(this);
    public interface IMoveActions
    {
        void OnMoving(InputAction.CallbackContext context);
    }
}
