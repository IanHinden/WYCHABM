// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Contract/WritingControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @WritingControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @WritingControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""WritingControls"",
    ""maps"": [
        {
            ""name"": ""Move"",
            ""id"": ""0b691b8e-6879-4b2f-9d31-355ac6f86bff"",
            ""actions"": [
                {
                    ""name"": ""Directions"",
                    ""type"": ""PassThrough"",
                    ""id"": ""8782414f-d199-49b7-8f11-04f990d90afd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""b4c0b464-1a1e-46ed-99f6-89764a041561"",
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
                    ""id"": ""519ff598-1902-46a8-b24c-d45d4562bbc0"",
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
                    ""id"": ""261ff9d4-759e-4b7d-a932-969e7dd7fdb8"",
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
                    ""id"": ""1299eb8a-b48a-4134-9bd8-4ac537e3654a"",
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
                    ""id"": ""da401312-a8f5-4572-8013-38071347d51f"",
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

    // Move
    private readonly InputActionMap m_Move;
    private IMoveActions m_MoveActionsCallbackInterface;
    private readonly InputAction m_Move_Directions;
    public struct MoveActions
    {
        private @WritingControls m_Wrapper;
        public MoveActions(@WritingControls wrapper) { m_Wrapper = wrapper; }
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
    public interface IMoveActions
    {
        void OnDirections(InputAction.CallbackContext context);
    }
}
