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
                    ""name"": ""LeftSelect"",
                    ""type"": ""PassThrough"",
                    ""id"": ""f1649822-c70c-41fa-a669-a45fbedc7b76"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RightSelect"",
                    ""type"": ""PassThrough"",
                    ""id"": ""fa51771d-a81e-49e5-aa6c-6a64d628e19f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Select"",
                    ""type"": ""PassThrough"",
                    ""id"": ""588bfc4a-e10c-490d-aadd-ea7bb8b2106b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Tap""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""13d70685-3417-4358-95f7-4abd31eab6b3"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftSelect"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""860d950b-5d0f-4137-9f8d-c34f542fe780"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightSelect"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d5406d06-958b-49c6-8c5d-dee3a969a533"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // CharacterSelect
        m_CharacterSelect = asset.FindActionMap("CharacterSelect", throwIfNotFound: true);
        m_CharacterSelect_LeftSelect = m_CharacterSelect.FindAction("LeftSelect", throwIfNotFound: true);
        m_CharacterSelect_RightSelect = m_CharacterSelect.FindAction("RightSelect", throwIfNotFound: true);
        m_CharacterSelect_Select = m_CharacterSelect.FindAction("Select", throwIfNotFound: true);
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
    private readonly InputAction m_CharacterSelect_LeftSelect;
    private readonly InputAction m_CharacterSelect_RightSelect;
    private readonly InputAction m_CharacterSelect_Select;
    public struct CharacterSelectActions
    {
        private @CharacterSelectControls m_Wrapper;
        public CharacterSelectActions(@CharacterSelectControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @LeftSelect => m_Wrapper.m_CharacterSelect_LeftSelect;
        public InputAction @RightSelect => m_Wrapper.m_CharacterSelect_RightSelect;
        public InputAction @Select => m_Wrapper.m_CharacterSelect_Select;
        public InputActionMap Get() { return m_Wrapper.m_CharacterSelect; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CharacterSelectActions set) { return set.Get(); }
        public void SetCallbacks(ICharacterSelectActions instance)
        {
            if (m_Wrapper.m_CharacterSelectActionsCallbackInterface != null)
            {
                @LeftSelect.started -= m_Wrapper.m_CharacterSelectActionsCallbackInterface.OnLeftSelect;
                @LeftSelect.performed -= m_Wrapper.m_CharacterSelectActionsCallbackInterface.OnLeftSelect;
                @LeftSelect.canceled -= m_Wrapper.m_CharacterSelectActionsCallbackInterface.OnLeftSelect;
                @RightSelect.started -= m_Wrapper.m_CharacterSelectActionsCallbackInterface.OnRightSelect;
                @RightSelect.performed -= m_Wrapper.m_CharacterSelectActionsCallbackInterface.OnRightSelect;
                @RightSelect.canceled -= m_Wrapper.m_CharacterSelectActionsCallbackInterface.OnRightSelect;
                @Select.started -= m_Wrapper.m_CharacterSelectActionsCallbackInterface.OnSelect;
                @Select.performed -= m_Wrapper.m_CharacterSelectActionsCallbackInterface.OnSelect;
                @Select.canceled -= m_Wrapper.m_CharacterSelectActionsCallbackInterface.OnSelect;
            }
            m_Wrapper.m_CharacterSelectActionsCallbackInterface = instance;
            if (instance != null)
            {
                @LeftSelect.started += instance.OnLeftSelect;
                @LeftSelect.performed += instance.OnLeftSelect;
                @LeftSelect.canceled += instance.OnLeftSelect;
                @RightSelect.started += instance.OnRightSelect;
                @RightSelect.performed += instance.OnRightSelect;
                @RightSelect.canceled += instance.OnRightSelect;
                @Select.started += instance.OnSelect;
                @Select.performed += instance.OnSelect;
                @Select.canceled += instance.OnSelect;
            }
        }
    }
    public CharacterSelectActions @CharacterSelect => new CharacterSelectActions(this);
    public interface ICharacterSelectActions
    {
        void OnLeftSelect(InputAction.CallbackContext context);
        void OnRightSelect(InputAction.CallbackContext context);
        void OnSelect(InputAction.CallbackContext context);
    }
}
