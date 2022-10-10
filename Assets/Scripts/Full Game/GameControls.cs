// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Full Game/GameControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @GameControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @GameControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""GameControls"",
    ""maps"": [
        {
            ""name"": ""Move"",
            ""id"": ""a39a0e6b-62f3-46f3-8951-9c4c2e802f5c"",
            ""actions"": [
                {
                    ""name"": ""Directions"",
                    ""type"": ""PassThrough"",
                    ""id"": ""99053ed3-7c9f-434c-aa69-77b50b1c28b1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""c3542fdd-0279-4b3d-827b-191b415b8dcc"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Directions"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""13a5718e-ff05-4eeb-a22b-edaf5f9d2a37"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Directions"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""d8c67aad-9edc-483f-ad5e-77b0086bf4e2"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Directions"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""a3ea4a10-d0e0-40bc-b3a2-2fc8f943eb49"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Directions"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""3710f70a-8d98-4dac-8f4e-2ba3f97c69ee"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Directions"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""Select"",
            ""id"": ""32e7b7f1-2b34-425d-8a26-8d10367176c6"",
            ""actions"": [
                {
                    ""name"": ""LeftSelect"",
                    ""type"": ""PassThrough"",
                    ""id"": ""3f56a20f-52f6-47b8-a710-69e28c606a47"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RightSelect"",
                    ""type"": ""PassThrough"",
                    ""id"": ""76bc8f95-e244-4767-a824-a05d5b0a01e0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Select"",
                    ""type"": ""PassThrough"",
                    ""id"": ""615e1d2e-b92e-430e-a504-e0a16ccc147a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Tap""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""85b668d6-9a47-4a1a-b41a-65d62b32aff6"",
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
                    ""id"": ""84c79184-d382-48e0-93f7-ed4d4da356cd"",
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
                    ""id"": ""f70d3d34-e505-4059-88aa-8cb2214bc36d"",
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
        // Move
        m_Move = asset.FindActionMap("Move", throwIfNotFound: true);
        m_Move_Directions = m_Move.FindAction("Directions", throwIfNotFound: true);
        // Select
        m_Select = asset.FindActionMap("Select", throwIfNotFound: true);
        m_Select_LeftSelect = m_Select.FindAction("LeftSelect", throwIfNotFound: true);
        m_Select_RightSelect = m_Select.FindAction("RightSelect", throwIfNotFound: true);
        m_Select_Select = m_Select.FindAction("Select", throwIfNotFound: true);
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
    private readonly InputAction m_Move_Directions;
    public struct MoveActions
    {
        private @GameControls m_Wrapper;
        public MoveActions(@GameControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Directions => m_Wrapper.m_Move_Directions;
        public InputActionMap Get() { return m_Wrapper.m_Move; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MoveActions set) { return set.Get(); }
        public void SetCallbacks(IMoveActions instance)
        {
            if (m_Wrapper.m_MoveActionsCallbackInterface != null)
            {
                @Directions.started -= m_Wrapper.m_MoveActionsCallbackInterface.OnDirections;
                @Directions.performed -= m_Wrapper.m_MoveActionsCallbackInterface.OnDirections;
                @Directions.canceled -= m_Wrapper.m_MoveActionsCallbackInterface.OnDirections;
            }
            m_Wrapper.m_MoveActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Directions.started += instance.OnDirections;
                @Directions.performed += instance.OnDirections;
                @Directions.canceled += instance.OnDirections;
            }
        }
    }
    public MoveActions @Move => new MoveActions(this);

    // Select
    private readonly InputActionMap m_Select;
    private ISelectActions m_SelectActionsCallbackInterface;
    private readonly InputAction m_Select_LeftSelect;
    private readonly InputAction m_Select_RightSelect;
    private readonly InputAction m_Select_Select;
    public struct SelectActions
    {
        private @GameControls m_Wrapper;
        public SelectActions(@GameControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @LeftSelect => m_Wrapper.m_Select_LeftSelect;
        public InputAction @RightSelect => m_Wrapper.m_Select_RightSelect;
        public InputAction @Select => m_Wrapper.m_Select_Select;
        public InputActionMap Get() { return m_Wrapper.m_Select; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(SelectActions set) { return set.Get(); }
        public void SetCallbacks(ISelectActions instance)
        {
            if (m_Wrapper.m_SelectActionsCallbackInterface != null)
            {
                @LeftSelect.started -= m_Wrapper.m_SelectActionsCallbackInterface.OnLeftSelect;
                @LeftSelect.performed -= m_Wrapper.m_SelectActionsCallbackInterface.OnLeftSelect;
                @LeftSelect.canceled -= m_Wrapper.m_SelectActionsCallbackInterface.OnLeftSelect;
                @RightSelect.started -= m_Wrapper.m_SelectActionsCallbackInterface.OnRightSelect;
                @RightSelect.performed -= m_Wrapper.m_SelectActionsCallbackInterface.OnRightSelect;
                @RightSelect.canceled -= m_Wrapper.m_SelectActionsCallbackInterface.OnRightSelect;
                @Select.started -= m_Wrapper.m_SelectActionsCallbackInterface.OnSelect;
                @Select.performed -= m_Wrapper.m_SelectActionsCallbackInterface.OnSelect;
                @Select.canceled -= m_Wrapper.m_SelectActionsCallbackInterface.OnSelect;
            }
            m_Wrapper.m_SelectActionsCallbackInterface = instance;
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
    public SelectActions @Select => new SelectActions(this);
    public interface IMoveActions
    {
        void OnDirections(InputAction.CallbackContext context);
    }
    public interface ISelectActions
    {
        void OnLeftSelect(InputAction.CallbackContext context);
        void OnRightSelect(InputAction.CallbackContext context);
        void OnSelect(InputAction.CallbackContext context);
    }
}
