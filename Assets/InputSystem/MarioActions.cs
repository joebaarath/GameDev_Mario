//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.6.3
//     from Assets/InputSystem/MarioActions.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @MarioActions: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @MarioActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""MarioActions"",
    ""maps"": [
        {
            ""name"": ""gameplay"",
            ""id"": ""997b2ba2-8660-4320-8ce6-603e7f30f37b"",
            ""actions"": [
                {
                    ""name"": ""move"",
                    ""type"": ""Value"",
                    ""id"": ""14c2c5e2-98d5-4c0a-bacf-1ea9454a099c"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""jump"",
                    ""type"": ""Button"",
                    ""id"": ""9408c817-804e-42d8-8f9d-06940c0fe1c1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""jumpHold"",
                    ""type"": ""Button"",
                    ""id"": ""37f90017-7039-4b08-b8d8-e1f7a3c7962b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Hold(duration=0.3)"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""click"",
                    ""type"": ""Button"",
                    ""id"": ""1cf7cd4d-3b73-49df-bd4f-04f06089e320"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""point"",
                    ""type"": ""Value"",
                    ""id"": ""1d6ff47f-5fe5-47b4-b1f9-bf08cac1a162"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""325b0d36-212e-4f66-bad9-83268b7693eb"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""be2e37d0-61fa-4992-bf90-6d7102457596"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""151a547c-b8b5-4d7d-91e8-fe35e75aa021"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""1D Axis (arrow)"",
                    ""id"": ""2fe018cd-c6cf-4d83-88d6-e9ea048d43bc"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""dccbab6d-77ab-4826-bbb7-706bb9def64a"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""cae5254b-d69f-485d-ac31-68fb9f9ca3b7"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""0ce240c5-2a76-49fe-8db6-829111a1cf31"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""MarioActions"",
                    ""action"": ""jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0601f95a-5096-45e0-860c-43915cb68853"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""MarioActions"",
                    ""action"": ""jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8529248c-26f1-4a8a-aa0c-e325218f60d8"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MarioActions"",
                    ""action"": ""jumpHold"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""62a7063e-a070-4174-8d90-5cb0e8da7ffe"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MarioActions"",
                    ""action"": ""jumpHold"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5d76964b-a03f-4061-8a2e-42a7175e6ed8"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MarioActions"",
                    ""action"": ""click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""One Modifier"",
                    ""id"": ""b11bf51e-b5e1-48af-94b3-90f5fdc86de0"",
                    ""path"": ""OneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""point"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""b2f3ab05-db5d-4145-8225-3829dd9b0b24"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MarioActions"",
                    ""action"": ""point"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""binding"",
                    ""id"": ""5dd41d90-a8c3-4909-9db2-0f9e6dd8bae4"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MarioActions"",
                    ""action"": ""point"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""MarioActions"",
            ""bindingGroup"": ""MarioActions"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // gameplay
        m_gameplay = asset.FindActionMap("gameplay", throwIfNotFound: true);
        m_gameplay_move = m_gameplay.FindAction("move", throwIfNotFound: true);
        m_gameplay_jump = m_gameplay.FindAction("jump", throwIfNotFound: true);
        m_gameplay_jumpHold = m_gameplay.FindAction("jumpHold", throwIfNotFound: true);
        m_gameplay_click = m_gameplay.FindAction("click", throwIfNotFound: true);
        m_gameplay_point = m_gameplay.FindAction("point", throwIfNotFound: true);
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

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // gameplay
    private readonly InputActionMap m_gameplay;
    private List<IGameplayActions> m_GameplayActionsCallbackInterfaces = new List<IGameplayActions>();
    private readonly InputAction m_gameplay_move;
    private readonly InputAction m_gameplay_jump;
    private readonly InputAction m_gameplay_jumpHold;
    private readonly InputAction m_gameplay_click;
    private readonly InputAction m_gameplay_point;
    public struct GameplayActions
    {
        private @MarioActions m_Wrapper;
        public GameplayActions(@MarioActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @move => m_Wrapper.m_gameplay_move;
        public InputAction @jump => m_Wrapper.m_gameplay_jump;
        public InputAction @jumpHold => m_Wrapper.m_gameplay_jumpHold;
        public InputAction @click => m_Wrapper.m_gameplay_click;
        public InputAction @point => m_Wrapper.m_gameplay_point;
        public InputActionMap Get() { return m_Wrapper.m_gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void AddCallbacks(IGameplayActions instance)
        {
            if (instance == null || m_Wrapper.m_GameplayActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_GameplayActionsCallbackInterfaces.Add(instance);
            @move.started += instance.OnMove;
            @move.performed += instance.OnMove;
            @move.canceled += instance.OnMove;
            @jump.started += instance.OnJump;
            @jump.performed += instance.OnJump;
            @jump.canceled += instance.OnJump;
            @jumpHold.started += instance.OnJumpHold;
            @jumpHold.performed += instance.OnJumpHold;
            @jumpHold.canceled += instance.OnJumpHold;
            @click.started += instance.OnClick;
            @click.performed += instance.OnClick;
            @click.canceled += instance.OnClick;
            @point.started += instance.OnPoint;
            @point.performed += instance.OnPoint;
            @point.canceled += instance.OnPoint;
        }

        private void UnregisterCallbacks(IGameplayActions instance)
        {
            @move.started -= instance.OnMove;
            @move.performed -= instance.OnMove;
            @move.canceled -= instance.OnMove;
            @jump.started -= instance.OnJump;
            @jump.performed -= instance.OnJump;
            @jump.canceled -= instance.OnJump;
            @jumpHold.started -= instance.OnJumpHold;
            @jumpHold.performed -= instance.OnJumpHold;
            @jumpHold.canceled -= instance.OnJumpHold;
            @click.started -= instance.OnClick;
            @click.performed -= instance.OnClick;
            @click.canceled -= instance.OnClick;
            @point.started -= instance.OnPoint;
            @point.performed -= instance.OnPoint;
            @point.canceled -= instance.OnPoint;
        }

        public void RemoveCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IGameplayActions instance)
        {
            foreach (var item in m_Wrapper.m_GameplayActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_GameplayActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public GameplayActions @gameplay => new GameplayActions(this);
    private int m_MarioActionsSchemeIndex = -1;
    public InputControlScheme MarioActionsScheme
    {
        get
        {
            if (m_MarioActionsSchemeIndex == -1) m_MarioActionsSchemeIndex = asset.FindControlSchemeIndex("MarioActions");
            return asset.controlSchemes[m_MarioActionsSchemeIndex];
        }
    }
    public interface IGameplayActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnJumpHold(InputAction.CallbackContext context);
        void OnClick(InputAction.CallbackContext context);
        void OnPoint(InputAction.CallbackContext context);
    }
}
