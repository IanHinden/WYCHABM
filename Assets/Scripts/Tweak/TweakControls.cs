// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Tweak/TweakControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @TweakControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @TweakControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""TweakControls"",
    ""maps"": [
        {
            ""name"": ""Move"",
            ""id"": ""11c6c9c3-458d-4f10-91ad-918592af581d"",
            ""actions"": [
                {
                    ""name"": ""UpArrow"",
                    ""type"": ""PassThrough"",
                    ""id"": ""63b7d0de-a8b1-4fd7-9664-be71176b6eea"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RightArrow"",
                    ""type"": ""PassThrough"",
                    ""id"": ""a1675b35-a458-4381-8322-d65cadfb011d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""DownArrow"",
                    ""type"": ""PassThrough"",
                    ""id"": ""065ffe25-0c7f-4a7a-bd6d-8fbbb784cdf4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LeftArrow"",
                    ""type"": ""PassThrough"",
                    ""id"": ""15c6bf5e-96c6-4fcc-9fab-983c5258eea7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""c3b1545c-568b-49b9-8436-aa4771b045aa"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UpArrow"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cf3753ad-824d-433b-811e-c3b959c77f9b"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightArrow"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""69275142-1648-42c3-8b68-b5c50f85bd48"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DownArrow"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6c8a8b4f-8e74-4c82-be66-dce617073fb3"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftArrow"",
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
        m_Move_UpArrow = m_Move.FindAction("UpArrow", throwIfNotFound: true);
        m_Move_RightArrow = m_Move.FindAction("RightArrow", throwIfNotFound: true);
        m_Move_DownArrow = m_Move.FindAction("DownArrow", throwIfNotFound: true);
        m_Move_LeftArrow = m_Move.FindAction("LeftArrow", throwIfNotFound: true);
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
    private readonly InputAction m_Move_UpArrow;
    private readonly InputAction m_Move_RightArrow;
    private readonly InputAction m_Move_DownArrow;
    private readonly InputAction m_Move_LeftArrow;
    public struct MoveActions
    {
        private @TweakControls m_Wrapper;
        public MoveActions(@TweakControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @UpArrow => m_Wrapper.m_Move_UpArrow;
        public InputAction @RightArrow => m_Wrapper.m_Move_RightArrow;
        public InputAction @DownArrow => m_Wrapper.m_Move_DownArrow;
        public InputAction @LeftArrow => m_Wrapper.m_Move_LeftArrow;
        public InputActionMap Get() { return m_Wrapper.m_Move; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MoveActions set) { return set.Get(); }
        public void SetCallbacks(IMoveActions instance)
        {
            if (m_Wrapper.m_MoveActionsCallbackInterface != null)
            {
                @UpArrow.started -= m_Wrapper.m_MoveActionsCallbackInterface.OnUpArrow;
                @UpArrow.performed -= m_Wrapper.m_MoveActionsCallbackInterface.OnUpArrow;
                @UpArrow.canceled -= m_Wrapper.m_MoveActionsCallbackInterface.OnUpArrow;
                @RightArrow.started -= m_Wrapper.m_MoveActionsCallbackInterface.OnRightArrow;
                @RightArrow.performed -= m_Wrapper.m_MoveActionsCallbackInterface.OnRightArrow;
                @RightArrow.canceled -= m_Wrapper.m_MoveActionsCallbackInterface.OnRightArrow;
                @DownArrow.started -= m_Wrapper.m_MoveActionsCallbackInterface.OnDownArrow;
                @DownArrow.performed -= m_Wrapper.m_MoveActionsCallbackInterface.OnDownArrow;
                @DownArrow.canceled -= m_Wrapper.m_MoveActionsCallbackInterface.OnDownArrow;
                @LeftArrow.started -= m_Wrapper.m_MoveActionsCallbackInterface.OnLeftArrow;
                @LeftArrow.performed -= m_Wrapper.m_MoveActionsCallbackInterface.OnLeftArrow;
                @LeftArrow.canceled -= m_Wrapper.m_MoveActionsCallbackInterface.OnLeftArrow;
            }
            m_Wrapper.m_MoveActionsCallbackInterface = instance;
            if (instance != null)
            {
                @UpArrow.started += instance.OnUpArrow;
                @UpArrow.performed += instance.OnUpArrow;
                @UpArrow.canceled += instance.OnUpArrow;
                @RightArrow.started += instance.OnRightArrow;
                @RightArrow.performed += instance.OnRightArrow;
                @RightArrow.canceled += instance.OnRightArrow;
                @DownArrow.started += instance.OnDownArrow;
                @DownArrow.performed += instance.OnDownArrow;
                @DownArrow.canceled += instance.OnDownArrow;
                @LeftArrow.started += instance.OnLeftArrow;
                @LeftArrow.performed += instance.OnLeftArrow;
                @LeftArrow.canceled += instance.OnLeftArrow;
            }
        }
    }
    public MoveActions @Move => new MoveActions(this);
    public interface IMoveActions
    {
        void OnUpArrow(InputAction.CallbackContext context);
        void OnRightArrow(InputAction.CallbackContext context);
        void OnDownArrow(InputAction.CallbackContext context);
        void OnLeftArrow(InputAction.CallbackContext context);
    }
}
