// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Mix/Stir.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Stir : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Stir()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Stir"",
    ""maps"": [
        {
            ""name"": ""MoveStraw"",
            ""id"": ""403e8216-f27e-481c-b0eb-5cceafa8d5e5"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Button"",
                    ""id"": ""9ab10bf2-ccbd-4d21-a3c4-cf522ddff443"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""6cf579cf-db3a-4846-b1ec-c0d7aae11054"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""1e585e73-b154-4804-be3d-6de30d662657"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""5f06fb80-935e-49a2-adfa-7092d4165250"",
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
        // MoveStraw
        m_MoveStraw = asset.FindActionMap("MoveStraw", throwIfNotFound: true);
        m_MoveStraw_Move = m_MoveStraw.FindAction("Move", throwIfNotFound: true);
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

    // MoveStraw
    private readonly InputActionMap m_MoveStraw;
    private IMoveStrawActions m_MoveStrawActionsCallbackInterface;
    private readonly InputAction m_MoveStraw_Move;
    public struct MoveStrawActions
    {
        private @Stir m_Wrapper;
        public MoveStrawActions(@Stir wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_MoveStraw_Move;
        public InputActionMap Get() { return m_Wrapper.m_MoveStraw; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MoveStrawActions set) { return set.Get(); }
        public void SetCallbacks(IMoveStrawActions instance)
        {
            if (m_Wrapper.m_MoveStrawActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_MoveStrawActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_MoveStrawActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_MoveStrawActionsCallbackInterface.OnMove;
            }
            m_Wrapper.m_MoveStrawActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
            }
        }
    }
    public MoveStrawActions @MoveStraw => new MoveStrawActions(this);
    public interface IMoveStrawActions
    {
        void OnMove(InputAction.CallbackContext context);
    }
}
