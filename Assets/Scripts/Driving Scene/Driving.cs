// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Driving Scene/Driving.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Driving : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Driving()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Driving"",
    ""maps"": [
        {
            ""name"": ""Drive"",
            ""id"": ""58518812-1865-4605-b3fa-3d2915c0bd0f"",
            ""actions"": [
                {
                    ""name"": ""Steer"",
                    ""type"": ""PassThrough"",
                    ""id"": ""b4f9578b-065a-435b-b144-b1e3015f46d1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""852ad38f-3075-455c-b712-45467cffa7d9"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Steer"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""053cc1ed-7688-43af-a094-9eb8cbb451df"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Steer"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""fd7c38ca-e30a-4feb-82ed-cef3fcea4bbc"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Steer"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Drive
        m_Drive = asset.FindActionMap("Drive", throwIfNotFound: true);
        m_Drive_Steer = m_Drive.FindAction("Steer", throwIfNotFound: true);
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

    // Drive
    private readonly InputActionMap m_Drive;
    private IDriveActions m_DriveActionsCallbackInterface;
    private readonly InputAction m_Drive_Steer;
    public struct DriveActions
    {
        private @Driving m_Wrapper;
        public DriveActions(@Driving wrapper) { m_Wrapper = wrapper; }
        public InputAction @Steer => m_Wrapper.m_Drive_Steer;
        public InputActionMap Get() { return m_Wrapper.m_Drive; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(DriveActions set) { return set.Get(); }
        public void SetCallbacks(IDriveActions instance)
        {
            if (m_Wrapper.m_DriveActionsCallbackInterface != null)
            {
                @Steer.started -= m_Wrapper.m_DriveActionsCallbackInterface.OnSteer;
                @Steer.performed -= m_Wrapper.m_DriveActionsCallbackInterface.OnSteer;
                @Steer.canceled -= m_Wrapper.m_DriveActionsCallbackInterface.OnSteer;
            }
            m_Wrapper.m_DriveActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Steer.started += instance.OnSteer;
                @Steer.performed += instance.OnSteer;
                @Steer.canceled += instance.OnSteer;
            }
        }
    }
    public DriveActions @Drive => new DriveActions(this);
    public interface IDriveActions
    {
        void OnSteer(InputAction.CallbackContext context);
    }
}
