// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Player Controls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerActionControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerActionControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Player Controls"",
    ""maps"": [
        {
            ""name"": ""OverheadMove"",
            ""id"": ""1d6332ed-fea3-433d-b1b1-09698501a0eb"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""PassThrough"",
                    ""id"": ""653baab2-c0b1-4637-827a-0676f7f8f9ba"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""833d17ed-496d-447e-8440-43b0ab2b8037"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""b9adbac1-8df3-4439-8179-f29e42677709"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""a9957a9f-4c22-49d2-b0df-495c6cc47c3e"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""6e33eed1-7a2b-46e5-9a30-e3ac0cb1f900"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""4d2a24be-b24a-45c3-accc-6d12eb04568c"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // OverheadMove
        m_OverheadMove = asset.FindActionMap("OverheadMove", throwIfNotFound: true);
        m_OverheadMove_Move = m_OverheadMove.FindAction("Move", throwIfNotFound: true);
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

    // OverheadMove
    private readonly InputActionMap m_OverheadMove;
    private IOverheadMoveActions m_OverheadMoveActionsCallbackInterface;
    private readonly InputAction m_OverheadMove_Move;
    public struct OverheadMoveActions
    {
        private @PlayerActionControls m_Wrapper;
        public OverheadMoveActions(@PlayerActionControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_OverheadMove_Move;
        public InputActionMap Get() { return m_Wrapper.m_OverheadMove; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(OverheadMoveActions set) { return set.Get(); }
        public void SetCallbacks(IOverheadMoveActions instance)
        {
            if (m_Wrapper.m_OverheadMoveActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_OverheadMoveActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_OverheadMoveActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_OverheadMoveActionsCallbackInterface.OnMove;
            }
            m_Wrapper.m_OverheadMoveActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
            }
        }
    }
    public OverheadMoveActions @OverheadMove => new OverheadMoveActions(this);
    public interface IOverheadMoveActions
    {
        void OnMove(InputAction.CallbackContext context);
    }
}
