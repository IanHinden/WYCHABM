// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/LogoScreen/NextScene.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @NextScene : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @NextScene()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""NextScene"",
    ""maps"": [
        {
            ""name"": ""FadeOut"",
            ""id"": ""70c44ad3-37f4-41d8-8f27-53b3a7de64ab"",
            ""actions"": [
                {
                    ""name"": ""Change"",
                    ""type"": ""PassThrough"",
                    ""id"": ""6ad08477-7482-4682-852f-711b75b58654"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""e5e91b9c-5c8c-4424-8358-4261068fc14c"",
                    ""path"": ""<Keyboard>/anyKey"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Change"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // FadeOut
        m_FadeOut = asset.FindActionMap("FadeOut", throwIfNotFound: true);
        m_FadeOut_Change = m_FadeOut.FindAction("Change", throwIfNotFound: true);
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

    // FadeOut
    private readonly InputActionMap m_FadeOut;
    private IFadeOutActions m_FadeOutActionsCallbackInterface;
    private readonly InputAction m_FadeOut_Change;
    public struct FadeOutActions
    {
        private @NextScene m_Wrapper;
        public FadeOutActions(@NextScene wrapper) { m_Wrapper = wrapper; }
        public InputAction @Change => m_Wrapper.m_FadeOut_Change;
        public InputActionMap Get() { return m_Wrapper.m_FadeOut; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(FadeOutActions set) { return set.Get(); }
        public void SetCallbacks(IFadeOutActions instance)
        {
            if (m_Wrapper.m_FadeOutActionsCallbackInterface != null)
            {
                @Change.started -= m_Wrapper.m_FadeOutActionsCallbackInterface.OnChange;
                @Change.performed -= m_Wrapper.m_FadeOutActionsCallbackInterface.OnChange;
                @Change.canceled -= m_Wrapper.m_FadeOutActionsCallbackInterface.OnChange;
            }
            m_Wrapper.m_FadeOutActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Change.started += instance.OnChange;
                @Change.performed += instance.OnChange;
                @Change.canceled += instance.OnChange;
            }
        }
    }
    public FadeOutActions @FadeOut => new FadeOutActions(this);
    public interface IFadeOutActions
    {
        void OnChange(InputAction.CallbackContext context);
    }
}
