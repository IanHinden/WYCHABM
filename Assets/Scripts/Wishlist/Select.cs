// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Wishlist/Select.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Select : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Select()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Select"",
    ""maps"": [
        {
            ""name"": ""Selecting"",
            ""id"": ""a0c62ba9-0688-4366-87a4-d5b1f50ec7bc"",
            ""actions"": [
                {
                    ""name"": ""Selecting"",
                    ""type"": ""PassThrough"",
                    ""id"": ""7dcb72fa-5560-4a5f-8462-5f5d55e17ee3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""7deeec21-32fa-460b-a0fd-897aeb95e043"",
                    ""path"": ""1DAxis"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Selecting"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""aafac24c-3ae3-4b06-baf5-8f57ee491c43"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Selecting"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""09f44111-0f1f-4090-be0d-1ca45f457bbc"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Selecting"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Selecting
        m_Selecting = asset.FindActionMap("Selecting", throwIfNotFound: true);
        m_Selecting_Selecting = m_Selecting.FindAction("Selecting", throwIfNotFound: true);
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

    // Selecting
    private readonly InputActionMap m_Selecting;
    private ISelectingActions m_SelectingActionsCallbackInterface;
    private readonly InputAction m_Selecting_Selecting;
    public struct SelectingActions
    {
        private @Select m_Wrapper;
        public SelectingActions(@Select wrapper) { m_Wrapper = wrapper; }
        public InputAction @Selecting => m_Wrapper.m_Selecting_Selecting;
        public InputActionMap Get() { return m_Wrapper.m_Selecting; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(SelectingActions set) { return set.Get(); }
        public void SetCallbacks(ISelectingActions instance)
        {
            if (m_Wrapper.m_SelectingActionsCallbackInterface != null)
            {
                @Selecting.started -= m_Wrapper.m_SelectingActionsCallbackInterface.OnSelecting;
                @Selecting.performed -= m_Wrapper.m_SelectingActionsCallbackInterface.OnSelecting;
                @Selecting.canceled -= m_Wrapper.m_SelectingActionsCallbackInterface.OnSelecting;
            }
            m_Wrapper.m_SelectingActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Selecting.started += instance.OnSelecting;
                @Selecting.performed += instance.OnSelecting;
                @Selecting.canceled += instance.OnSelecting;
            }
        }
    }
    public SelectingActions @Selecting => new SelectingActions(this);
    public interface ISelectingActions
    {
        void OnSelecting(InputAction.CallbackContext context);
    }
}
