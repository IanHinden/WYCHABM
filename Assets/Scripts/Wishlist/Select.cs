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
                    ""name"": ""DownSelect"",
                    ""type"": ""PassThrough"",
                    ""id"": ""7dcb72fa-5560-4a5f-8462-5f5d55e17ee3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""UpSelect"",
                    ""type"": ""Button"",
                    ""id"": ""96f4c59c-8f70-45d9-82c1-4b1905437989"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Select"",
                    ""type"": ""Button"",
                    ""id"": ""58c797f6-d975-4ed5-ac24-96341da4abbb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""ae5e357b-64d5-478f-aa0b-e9306e0ecd84"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DownSelect"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2081ed68-d769-4596-b9dc-5211d9278821"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DownSelect"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""93d730b3-d0f7-4966-b870-17d10e5510e5"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UpSelect"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b6c09dd6-e49d-47cb-bfa7-ab41fa16fa55"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UpSelect"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9276d137-d681-441a-bf61-287b3ad7446d"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ebe9445f-f29a-4d11-82ef-0a573c30687c"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": ""Press"",
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
        // Selecting
        m_Selecting = asset.FindActionMap("Selecting", throwIfNotFound: true);
        m_Selecting_DownSelect = m_Selecting.FindAction("DownSelect", throwIfNotFound: true);
        m_Selecting_UpSelect = m_Selecting.FindAction("UpSelect", throwIfNotFound: true);
        m_Selecting_Select = m_Selecting.FindAction("Select", throwIfNotFound: true);
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
    private readonly InputAction m_Selecting_DownSelect;
    private readonly InputAction m_Selecting_UpSelect;
    private readonly InputAction m_Selecting_Select;
    public struct SelectingActions
    {
        private @Select m_Wrapper;
        public SelectingActions(@Select wrapper) { m_Wrapper = wrapper; }
        public InputAction @DownSelect => m_Wrapper.m_Selecting_DownSelect;
        public InputAction @UpSelect => m_Wrapper.m_Selecting_UpSelect;
        public InputAction @Select => m_Wrapper.m_Selecting_Select;
        public InputActionMap Get() { return m_Wrapper.m_Selecting; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(SelectingActions set) { return set.Get(); }
        public void SetCallbacks(ISelectingActions instance)
        {
            if (m_Wrapper.m_SelectingActionsCallbackInterface != null)
            {
                @DownSelect.started -= m_Wrapper.m_SelectingActionsCallbackInterface.OnDownSelect;
                @DownSelect.performed -= m_Wrapper.m_SelectingActionsCallbackInterface.OnDownSelect;
                @DownSelect.canceled -= m_Wrapper.m_SelectingActionsCallbackInterface.OnDownSelect;
                @UpSelect.started -= m_Wrapper.m_SelectingActionsCallbackInterface.OnUpSelect;
                @UpSelect.performed -= m_Wrapper.m_SelectingActionsCallbackInterface.OnUpSelect;
                @UpSelect.canceled -= m_Wrapper.m_SelectingActionsCallbackInterface.OnUpSelect;
                @Select.started -= m_Wrapper.m_SelectingActionsCallbackInterface.OnSelect;
                @Select.performed -= m_Wrapper.m_SelectingActionsCallbackInterface.OnSelect;
                @Select.canceled -= m_Wrapper.m_SelectingActionsCallbackInterface.OnSelect;
            }
            m_Wrapper.m_SelectingActionsCallbackInterface = instance;
            if (instance != null)
            {
                @DownSelect.started += instance.OnDownSelect;
                @DownSelect.performed += instance.OnDownSelect;
                @DownSelect.canceled += instance.OnDownSelect;
                @UpSelect.started += instance.OnUpSelect;
                @UpSelect.performed += instance.OnUpSelect;
                @UpSelect.canceled += instance.OnUpSelect;
                @Select.started += instance.OnSelect;
                @Select.performed += instance.OnSelect;
                @Select.canceled += instance.OnSelect;
            }
        }
    }
    public SelectingActions @Selecting => new SelectingActions(this);
    public interface ISelectingActions
    {
        void OnDownSelect(InputAction.CallbackContext context);
        void OnUpSelect(InputAction.CallbackContext context);
        void OnSelect(InputAction.CallbackContext context);
    }
}
