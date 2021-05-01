// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/CharacterSelect/CharacterSelectControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @CharacterSelectControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @CharacterSelectControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""CharacterSelectControls"",
    ""maps"": [
        {
            ""name"": ""CharacterSelect"",
            ""id"": ""b1fca8d1-027b-434e-8105-c63f969e2965"",
            ""actions"": [
                {
                    ""name"": ""Selection"",
                    ""type"": ""PassThrough"",
                    ""id"": ""6931e789-167d-42b5-9e76-0a770f8a4887"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""ade107fc-8369-40b9-afc9-de00d5b75d5f"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Selection"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""3dce94cc-5fec-4551-abfc-168ec0760de8"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Selection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""315f4f26-1bcc-4cde-9cdb-ba14417152f8"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Selection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // CharacterSelect
        m_CharacterSelect = asset.FindActionMap("CharacterSelect", throwIfNotFound: true);
        m_CharacterSelect_Selection = m_CharacterSelect.FindAction("Selection", throwIfNotFound: true);
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

    // CharacterSelect
    private readonly InputActionMap m_CharacterSelect;
    private ICharacterSelectActions m_CharacterSelectActionsCallbackInterface;
    private readonly InputAction m_CharacterSelect_Selection;
    public struct CharacterSelectActions
    {
        private @CharacterSelectControls m_Wrapper;
        public CharacterSelectActions(@CharacterSelectControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Selection => m_Wrapper.m_CharacterSelect_Selection;
        public InputActionMap Get() { return m_Wrapper.m_CharacterSelect; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CharacterSelectActions set) { return set.Get(); }
        public void SetCallbacks(ICharacterSelectActions instance)
        {
            if (m_Wrapper.m_CharacterSelectActionsCallbackInterface != null)
            {
                @Selection.started -= m_Wrapper.m_CharacterSelectActionsCallbackInterface.OnSelection;
                @Selection.performed -= m_Wrapper.m_CharacterSelectActionsCallbackInterface.OnSelection;
                @Selection.canceled -= m_Wrapper.m_CharacterSelectActionsCallbackInterface.OnSelection;
            }
            m_Wrapper.m_CharacterSelectActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Selection.started += instance.OnSelection;
                @Selection.performed += instance.OnSelection;
                @Selection.canceled += instance.OnSelection;
            }
        }
    }
    public CharacterSelectActions @CharacterSelect => new CharacterSelectActions(this);
    public interface ICharacterSelectActions
    {
        void OnSelection(InputAction.CallbackContext context);
    }
}
