// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Mensch/FingerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @FingerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @FingerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""FingerControls"",
    ""maps"": [
        {
            ""name"": ""Move"",
            ""id"": ""1ae95915-0904-4d33-9c1b-84b3eead7f9f"",
            ""actions"": [
                {
                    ""name"": ""Directions"",
                    ""type"": ""PassThrough"",
                    ""id"": ""a992a968-8bc9-4418-8762-41ab66286244"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""416cbc6a-0928-4e05-ba11-b9efe0f95140"",
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
                    ""id"": ""f397f7a0-f9b0-40ac-ac3e-de86d63fc134"",
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
                    ""id"": ""5fa2650c-6e76-43f4-99db-018f6c2abb34"",
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
                    ""id"": ""ea66dbd5-8707-42f0-bba3-053db376220e"",
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
                    ""id"": ""7b1d7723-9e53-4e68-8697-f8692135fd33"",
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
            ""name"": ""Press"",
            ""id"": ""6f1edb4f-550c-482a-8b89-c81adbe2789a"",
            ""actions"": [
                {
                    ""name"": ""FingerPress"",
                    ""type"": ""PassThrough"",
                    ""id"": ""13a3a581-2a33-4ef2-9168-e35140fd74c0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""94c75361-2295-44a5-a184-fd3c068ef5cc"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FingerPress"",
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
        // Press
        m_Press = asset.FindActionMap("Press", throwIfNotFound: true);
        m_Press_FingerPress = m_Press.FindAction("FingerPress", throwIfNotFound: true);
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
        private @FingerControls m_Wrapper;
        public MoveActions(@FingerControls wrapper) { m_Wrapper = wrapper; }
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

    // Press
    private readonly InputActionMap m_Press;
    private IPressActions m_PressActionsCallbackInterface;
    private readonly InputAction m_Press_FingerPress;
    public struct PressActions
    {
        private @FingerControls m_Wrapper;
        public PressActions(@FingerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @FingerPress => m_Wrapper.m_Press_FingerPress;
        public InputActionMap Get() { return m_Wrapper.m_Press; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PressActions set) { return set.Get(); }
        public void SetCallbacks(IPressActions instance)
        {
            if (m_Wrapper.m_PressActionsCallbackInterface != null)
            {
                @FingerPress.started -= m_Wrapper.m_PressActionsCallbackInterface.OnFingerPress;
                @FingerPress.performed -= m_Wrapper.m_PressActionsCallbackInterface.OnFingerPress;
                @FingerPress.canceled -= m_Wrapper.m_PressActionsCallbackInterface.OnFingerPress;
            }
            m_Wrapper.m_PressActionsCallbackInterface = instance;
            if (instance != null)
            {
                @FingerPress.started += instance.OnFingerPress;
                @FingerPress.performed += instance.OnFingerPress;
                @FingerPress.canceled += instance.OnFingerPress;
            }
        }
    }
    public PressActions @Press => new PressActions(this);
    public interface IMoveActions
    {
        void OnDirections(InputAction.CallbackContext context);
    }
    public interface IPressActions
    {
        void OnFingerPress(InputAction.CallbackContext context);
    }
}
