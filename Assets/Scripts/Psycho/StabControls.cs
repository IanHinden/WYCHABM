// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Psycho/StabControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @StabControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @StabControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""StabControls"",
    ""maps"": [
        {
            ""name"": ""Stab"",
            ""id"": ""55eaf3a0-b534-4b5c-a32f-3f1b623c217c"",
            ""actions"": [
                {
                    ""name"": ""Kill"",
                    ""type"": ""PassThrough"",
                    ""id"": ""9048ddbc-74f1-4e8d-a962-caf43ba7ec91"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""1482e393-e0e3-4e24-a372-dd014b952954"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Kill"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Move"",
            ""id"": ""47fc46c6-58d3-47d3-9ad6-40b46563d2e5"",
            ""actions"": [
                {
                    ""name"": ""Directions"",
                    ""type"": ""PassThrough"",
                    ""id"": ""a60b916a-43e4-4eb2-842b-1eff7767b600"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""3a5001b3-1b90-4c09-9c1b-b49bc2698db1"",
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
                    ""id"": ""de978b57-3917-4459-ae68-6d7f3350439c"",
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
                    ""id"": ""91029e1b-02f7-468a-ad3a-416e3904383a"",
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
                    ""id"": ""16a6e4e3-27b8-4dca-814f-d72dcd0cf05e"",
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
                    ""id"": ""49877643-9361-4370-a253-882033420f81"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Directions"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Stab
        m_Stab = asset.FindActionMap("Stab", throwIfNotFound: true);
        m_Stab_Kill = m_Stab.FindAction("Kill", throwIfNotFound: true);
        // Move
        m_Move = asset.FindActionMap("Move", throwIfNotFound: true);
        m_Move_Directions = m_Move.FindAction("Directions", throwIfNotFound: true);
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

    // Stab
    private readonly InputActionMap m_Stab;
    private IStabActions m_StabActionsCallbackInterface;
    private readonly InputAction m_Stab_Kill;
    public struct StabActions
    {
        private @StabControls m_Wrapper;
        public StabActions(@StabControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Kill => m_Wrapper.m_Stab_Kill;
        public InputActionMap Get() { return m_Wrapper.m_Stab; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(StabActions set) { return set.Get(); }
        public void SetCallbacks(IStabActions instance)
        {
            if (m_Wrapper.m_StabActionsCallbackInterface != null)
            {
                @Kill.started -= m_Wrapper.m_StabActionsCallbackInterface.OnKill;
                @Kill.performed -= m_Wrapper.m_StabActionsCallbackInterface.OnKill;
                @Kill.canceled -= m_Wrapper.m_StabActionsCallbackInterface.OnKill;
            }
            m_Wrapper.m_StabActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Kill.started += instance.OnKill;
                @Kill.performed += instance.OnKill;
                @Kill.canceled += instance.OnKill;
            }
        }
    }
    public StabActions @Stab => new StabActions(this);

    // Move
    private readonly InputActionMap m_Move;
    private IMoveActions m_MoveActionsCallbackInterface;
    private readonly InputAction m_Move_Directions;
    public struct MoveActions
    {
        private @StabControls m_Wrapper;
        public MoveActions(@StabControls wrapper) { m_Wrapper = wrapper; }
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
    public interface IStabActions
    {
        void OnKill(InputAction.CallbackContext context);
    }
    public interface IMoveActions
    {
        void OnDirections(InputAction.CallbackContext context);
    }
}
