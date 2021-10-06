// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Evolving/StopEvolving.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @StopEvolving : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @StopEvolving()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""StopEvolving"",
    ""maps"": [
        {
            ""name"": ""Stop"",
            ""id"": ""d36ae8a4-a2c3-45c5-a8d9-04dfc2a56e55"",
            ""actions"": [
                {
                    ""name"": ""StopEvolve"",
                    ""type"": ""PassThrough"",
                    ""id"": ""c91b0e59-ef38-42bb-a0fc-d960eb8794c1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""29754f9c-de45-4f30-96cb-42e87ec62b41"",
                    ""path"": ""<Keyboard>/b"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""StopEvolve"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Stop
        m_Stop = asset.FindActionMap("Stop", throwIfNotFound: true);
        m_Stop_StopEvolve = m_Stop.FindAction("StopEvolve", throwIfNotFound: true);
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

    // Stop
    private readonly InputActionMap m_Stop;
    private IStopActions m_StopActionsCallbackInterface;
    private readonly InputAction m_Stop_StopEvolve;
    public struct StopActions
    {
        private @StopEvolving m_Wrapper;
        public StopActions(@StopEvolving wrapper) { m_Wrapper = wrapper; }
        public InputAction @StopEvolve => m_Wrapper.m_Stop_StopEvolve;
        public InputActionMap Get() { return m_Wrapper.m_Stop; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(StopActions set) { return set.Get(); }
        public void SetCallbacks(IStopActions instance)
        {
            if (m_Wrapper.m_StopActionsCallbackInterface != null)
            {
                @StopEvolve.started -= m_Wrapper.m_StopActionsCallbackInterface.OnStopEvolve;
                @StopEvolve.performed -= m_Wrapper.m_StopActionsCallbackInterface.OnStopEvolve;
                @StopEvolve.canceled -= m_Wrapper.m_StopActionsCallbackInterface.OnStopEvolve;
            }
            m_Wrapper.m_StopActionsCallbackInterface = instance;
            if (instance != null)
            {
                @StopEvolve.started += instance.OnStopEvolve;
                @StopEvolve.performed += instance.OnStopEvolve;
                @StopEvolve.canceled += instance.OnStopEvolve;
            }
        }
    }
    public StopActions @Stop => new StopActions(this);
    public interface IStopActions
    {
        void OnStopEvolve(InputAction.CallbackContext context);
    }
}
