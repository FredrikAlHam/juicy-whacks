// GENERATED AUTOMATICALLY FROM 'Assets/NewStuff/Input/GameControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Controls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""GameControls"",
    ""maps"": [
        {
            ""name"": ""Whacks"",
            ""id"": ""480ce912-0a4e-4c10-8a4d-243c40183576"",
            ""actions"": [
                {
                    ""name"": ""Whack 1"",
                    ""type"": ""Button"",
                    ""id"": ""fef7ebed-4b2e-4f51-8625-f1308b1781fa"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Whack 2"",
                    ""type"": ""Button"",
                    ""id"": ""5812fe45-9041-47b1-bcdd-5c07d16280ac"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Whack 3"",
                    ""type"": ""Button"",
                    ""id"": ""9707bc15-af8f-491f-91a9-ad3dfe6b7a1b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Whack 4"",
                    ""type"": ""Button"",
                    ""id"": ""288d7833-8eff-4cb7-90ed-ec876f3c5f33"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Whack 5"",
                    ""type"": ""Button"",
                    ""id"": ""230c8546-08ae-405b-aa4b-eacd133ca66a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Whack 6"",
                    ""type"": ""Button"",
                    ""id"": ""c36107e2-35c1-4c68-b878-bf50bc5924a1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""c5ee3c0b-0b4e-49a7-a5db-8a38cdbb0316"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Whack 1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7e77ff76-dcfa-4992-b66c-b26ba5cb7e1e"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Whack 2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cbd1e3bc-9aaf-4a7d-8ffb-094111b6cd68"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Whack 3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""de31b548-5750-4257-af69-387f4c1177c3"",
                    ""path"": ""<Keyboard>/j"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Whack 4"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a1c58f46-9cc5-44c5-a05d-1ef5e7b6b2a3"",
                    ""path"": ""<Keyboard>/k"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Whack 5"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ce69b216-42cd-4841-8c58-5a8442018b32"",
                    ""path"": ""<Keyboard>/l"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Whack 6"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""UI"",
            ""id"": ""e3a3eafe-a6b9-4079-ba92-c619af147e29"",
            ""actions"": [
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""b4ef8bd6-c735-49a9-adcf-ef416280489c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""d43f3c44-6175-4eb8-b978-5fa0d8f8c87b"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Whacks
        m_Whacks = asset.FindActionMap("Whacks", throwIfNotFound: true);
        m_Whacks_Whack1 = m_Whacks.FindAction("Whack 1", throwIfNotFound: true);
        m_Whacks_Whack2 = m_Whacks.FindAction("Whack 2", throwIfNotFound: true);
        m_Whacks_Whack3 = m_Whacks.FindAction("Whack 3", throwIfNotFound: true);
        m_Whacks_Whack4 = m_Whacks.FindAction("Whack 4", throwIfNotFound: true);
        m_Whacks_Whack5 = m_Whacks.FindAction("Whack 5", throwIfNotFound: true);
        m_Whacks_Whack6 = m_Whacks.FindAction("Whack 6", throwIfNotFound: true);
        // UI
        m_UI = asset.FindActionMap("UI", throwIfNotFound: true);
        m_UI_Pause = m_UI.FindAction("Pause", throwIfNotFound: true);
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

    // Whacks
    private readonly InputActionMap m_Whacks;
    private IWhacksActions m_WhacksActionsCallbackInterface;
    private readonly InputAction m_Whacks_Whack1;
    private readonly InputAction m_Whacks_Whack2;
    private readonly InputAction m_Whacks_Whack3;
    private readonly InputAction m_Whacks_Whack4;
    private readonly InputAction m_Whacks_Whack5;
    private readonly InputAction m_Whacks_Whack6;
    public struct WhacksActions
    {
        private @Controls m_Wrapper;
        public WhacksActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Whack1 => m_Wrapper.m_Whacks_Whack1;
        public InputAction @Whack2 => m_Wrapper.m_Whacks_Whack2;
        public InputAction @Whack3 => m_Wrapper.m_Whacks_Whack3;
        public InputAction @Whack4 => m_Wrapper.m_Whacks_Whack4;
        public InputAction @Whack5 => m_Wrapper.m_Whacks_Whack5;
        public InputAction @Whack6 => m_Wrapper.m_Whacks_Whack6;
        public InputActionMap Get() { return m_Wrapper.m_Whacks; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(WhacksActions set) { return set.Get(); }
        public void SetCallbacks(IWhacksActions instance)
        {
            if (m_Wrapper.m_WhacksActionsCallbackInterface != null)
            {
                @Whack1.started -= m_Wrapper.m_WhacksActionsCallbackInterface.OnWhack1;
                @Whack1.performed -= m_Wrapper.m_WhacksActionsCallbackInterface.OnWhack1;
                @Whack1.canceled -= m_Wrapper.m_WhacksActionsCallbackInterface.OnWhack1;
                @Whack2.started -= m_Wrapper.m_WhacksActionsCallbackInterface.OnWhack2;
                @Whack2.performed -= m_Wrapper.m_WhacksActionsCallbackInterface.OnWhack2;
                @Whack2.canceled -= m_Wrapper.m_WhacksActionsCallbackInterface.OnWhack2;
                @Whack3.started -= m_Wrapper.m_WhacksActionsCallbackInterface.OnWhack3;
                @Whack3.performed -= m_Wrapper.m_WhacksActionsCallbackInterface.OnWhack3;
                @Whack3.canceled -= m_Wrapper.m_WhacksActionsCallbackInterface.OnWhack3;
                @Whack4.started -= m_Wrapper.m_WhacksActionsCallbackInterface.OnWhack4;
                @Whack4.performed -= m_Wrapper.m_WhacksActionsCallbackInterface.OnWhack4;
                @Whack4.canceled -= m_Wrapper.m_WhacksActionsCallbackInterface.OnWhack4;
                @Whack5.started -= m_Wrapper.m_WhacksActionsCallbackInterface.OnWhack5;
                @Whack5.performed -= m_Wrapper.m_WhacksActionsCallbackInterface.OnWhack5;
                @Whack5.canceled -= m_Wrapper.m_WhacksActionsCallbackInterface.OnWhack5;
                @Whack6.started -= m_Wrapper.m_WhacksActionsCallbackInterface.OnWhack6;
                @Whack6.performed -= m_Wrapper.m_WhacksActionsCallbackInterface.OnWhack6;
                @Whack6.canceled -= m_Wrapper.m_WhacksActionsCallbackInterface.OnWhack6;
            }
            m_Wrapper.m_WhacksActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Whack1.started += instance.OnWhack1;
                @Whack1.performed += instance.OnWhack1;
                @Whack1.canceled += instance.OnWhack1;
                @Whack2.started += instance.OnWhack2;
                @Whack2.performed += instance.OnWhack2;
                @Whack2.canceled += instance.OnWhack2;
                @Whack3.started += instance.OnWhack3;
                @Whack3.performed += instance.OnWhack3;
                @Whack3.canceled += instance.OnWhack3;
                @Whack4.started += instance.OnWhack4;
                @Whack4.performed += instance.OnWhack4;
                @Whack4.canceled += instance.OnWhack4;
                @Whack5.started += instance.OnWhack5;
                @Whack5.performed += instance.OnWhack5;
                @Whack5.canceled += instance.OnWhack5;
                @Whack6.started += instance.OnWhack6;
                @Whack6.performed += instance.OnWhack6;
                @Whack6.canceled += instance.OnWhack6;
            }
        }
    }
    public WhacksActions @Whacks => new WhacksActions(this);

    // UI
    private readonly InputActionMap m_UI;
    private IUIActions m_UIActionsCallbackInterface;
    private readonly InputAction m_UI_Pause;
    public struct UIActions
    {
        private @Controls m_Wrapper;
        public UIActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Pause => m_Wrapper.m_UI_Pause;
        public InputActionMap Get() { return m_Wrapper.m_UI; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UIActions set) { return set.Get(); }
        public void SetCallbacks(IUIActions instance)
        {
            if (m_Wrapper.m_UIActionsCallbackInterface != null)
            {
                @Pause.started -= m_Wrapper.m_UIActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnPause;
            }
            m_Wrapper.m_UIActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
            }
        }
    }
    public UIActions @UI => new UIActions(this);
    public interface IWhacksActions
    {
        void OnWhack1(InputAction.CallbackContext context);
        void OnWhack2(InputAction.CallbackContext context);
        void OnWhack3(InputAction.CallbackContext context);
        void OnWhack4(InputAction.CallbackContext context);
        void OnWhack5(InputAction.CallbackContext context);
        void OnWhack6(InputAction.CallbackContext context);
    }
    public interface IUIActions
    {
        void OnPause(InputAction.CallbackContext context);
    }
}
