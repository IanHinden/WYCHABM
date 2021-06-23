// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Job Interview/SwitchCards.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @SwitchCards : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @SwitchCards()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""SwitchCards"",
    ""maps"": [
        {
            ""name"": ""Selecting"",
            ""id"": ""b283a544-8bee-461c-93c3-d95919baebec"",
            ""actions"": [
                {
                    ""name"": ""LeftSelect"",
                    ""type"": ""PassThrough"",
                    ""id"": ""9c9e0083-040d-41bd-83d6-b74a3f3c6481"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RightSelect"",
                    ""type"": ""PassThrough"",
                    ""id"": ""393ad68a-fe5a-4743-bb91-913380a471bf"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Select"",
                    ""type"": ""Button"",
                    ""id"": ""6ccd216e-213d-4f30-aac3-4de5be72ad42"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""f47c8624-d7b6-4057-972f-b93552bfdaac"",
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
                    ""id"": ""5d84aea4-7b67-47fd-9f6a-f599dd2fe5e7"",
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
                    ""id"": ""e509883b-01b2-4a18-b30b-d7e57823b634"",
                    ""path"": ""<Keyboard>/space"",
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
        m_Selecting_LeftSelect = m_Selecting.FindAction("LeftSelect", throwIfNotFound: true);
        m_Selecting_RightSelect = m_Selecting.FindAction("RightSelect", throwIfNotFound: true);
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
    private readonly InputAction m_Selecting_LeftSelect;
    private readonly InputAction m_Selecting_RightSelect;
    private readonly InputAction m_Selecting_Select;
    public struct SelectingActions
    {
        private @SwitchCards m_Wrapper;
        public SelectingActions(@SwitchCards wrapper) { m_Wrapper = wrapper; }
        public InputAction @LeftSelect => m_Wrapper.m_Selecting_LeftSelect;
        public InputAction @RightSelect => m_Wrapper.m_Selecting_RightSelect;
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
                @LeftSelect.started -= m_Wrapper.m_SelectingActionsCallbackInterface.OnLeftSelect;
                @LeftSelect.performed -= m_Wrapper.m_SelectingActionsCallbackInterface.OnLeftSelect;
                @LeftSelect.canceled -= m_Wrapper.m_SelectingActionsCallbackInterface.OnLeftSelect;
                @RightSelect.started -= m_Wrapper.m_SelectingActionsCallbackInterface.OnRightSelect;
                @RightSelect.performed -= m_Wrapper.m_SelectingActionsCallbackInterface.OnRightSelect;
                @RightSelect.canceled -= m_Wrapper.m_SelectingActionsCallbackInterface.OnRightSelect;
                @Select.started -= m_Wrapper.m_SelectingActionsCallbackInterface.OnSelect;
                @Select.performed -= m_Wrapper.m_SelectingActionsCallbackInterface.OnSelect;
                @Select.canceled -= m_Wrapper.m_SelectingActionsCallbackInterface.OnSelect;
            }
            m_Wrapper.m_SelectingActionsCallbackInterface = instance;
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
    public SelectingActions @Selecting => new SelectingActions(this);
    public interface ISelectingActions
    {
        void OnLeftSelect(InputAction.CallbackContext context);
        void OnRightSelect(InputAction.CallbackContext context);
        void OnSelect(InputAction.CallbackContext context);
    }
}
