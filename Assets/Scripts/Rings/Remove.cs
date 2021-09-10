// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Rings/Remove.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Remove : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Remove()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Remove"",
    ""maps"": [
        {
            ""name"": ""Tap"",
            ""id"": ""15201e98-2886-4284-8f6c-024d47fb2aad"",
            ""actions"": [
                {
                    ""name"": ""Up"",
                    ""type"": ""PassThrough"",
                    ""id"": ""12de69a3-bcb3-4849-8b1f-5eae1481d963"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""c0c46b0e-fe03-4741-b45d-b0042691f196"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Tap
        m_Tap = asset.FindActionMap("Tap", throwIfNotFound: true);
        m_Tap_Up = m_Tap.FindAction("Up", throwIfNotFound: true);
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

    // Tap
    private readonly InputActionMap m_Tap;
    private ITapActions m_TapActionsCallbackInterface;
    private readonly InputAction m_Tap_Up;
    public struct TapActions
    {
        private @Remove m_Wrapper;
        public TapActions(@Remove wrapper) { m_Wrapper = wrapper; }
        public InputAction @Up => m_Wrapper.m_Tap_Up;
        public InputActionMap Get() { return m_Wrapper.m_Tap; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(TapActions set) { return set.Get(); }
        public void SetCallbacks(ITapActions instance)
        {
            if (m_Wrapper.m_TapActionsCallbackInterface != null)
            {
                @Up.started -= m_Wrapper.m_TapActionsCallbackInterface.OnUp;
                @Up.performed -= m_Wrapper.m_TapActionsCallbackInterface.OnUp;
                @Up.canceled -= m_Wrapper.m_TapActionsCallbackInterface.OnUp;
            }
            m_Wrapper.m_TapActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Up.started += instance.OnUp;
                @Up.performed += instance.OnUp;
                @Up.canceled += instance.OnUp;
            }
        }
    }
    public TapActions @Tap => new TapActions(this);
    public interface ITapActions
    {
        void OnUp(InputAction.CallbackContext context);
    }
}
