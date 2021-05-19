// GENERATED AUTOMATICALLY FROM 'Assets/Input/FieraControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @FieraShipControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @FieraShipControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""FieraControls"",
    ""maps"": [
        {
            ""name"": ""SpaceShip"",
            ""id"": ""969f25b8-dcc8-41db-8769-6bec7af5d08a"",
            ""actions"": [
                {
                    ""name"": ""Thrust"",
                    ""type"": ""PassThrough"",
                    ""id"": ""1a4c02af-3a7b-4f07-aea3-fe0f2fd40be4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Hold""
                },
                {
                    ""name"": ""ReverseThrust"",
                    ""type"": ""PassThrough"",
                    ""id"": ""cc1588ae-5f88-4f66-9a19-5f758bdf0a66"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Hold""
                },
                {
                    ""name"": ""Rotation"",
                    ""type"": ""PassThrough"",
                    ""id"": ""3f712dea-6fd0-493c-a889-44fe8cf09a3f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Hold""
                },
                {
                    ""name"": ""AddThrust"",
                    ""type"": ""PassThrough"",
                    ""id"": ""c0e4c495-afa3-49d4-9113-8d2ace442b65"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Hold""
                },
                {
                    ""name"": ""ActivateInventory"",
                    ""type"": ""Button"",
                    ""id"": ""bafbfcac-836f-4ccd-ad80-893f32e86a67"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""29a1dc16-bf3d-430f-8a9a-2e8a7da1f19e"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Thrust"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""997a2aba-c20c-4139-98ec-eeb95aa8d8ce"",
                    ""path"": ""<DualShockGamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Thrust"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""adcdeae2-d87d-4f2a-ac63-fd73e55d2d4e"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ReverseThrust"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0b6a742c-cb9e-46dd-9def-7108cba18058"",
                    ""path"": ""<DualShockGamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ReverseThrust"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""5917708e-688d-4ccd-be4d-915d29b9d669"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotation"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""9e057df7-69a4-45a6-a5bc-b1d91185236f"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""edc04c2b-a298-454b-a54b-ffb4615ed6c1"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""PS4"",
                    ""id"": ""1dc2ce3a-eda7-4075-95d1-d70e8419a5d2"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotation"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Negative"",
                    ""id"": ""eeb95188-e906-454a-8df8-19b82f71256c"",
                    ""path"": ""<DualShockGamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Positive"",
                    ""id"": ""02c0e9a5-e664-44b5-a9b0-cecab4624b79"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""6619f0ed-36dd-4240-83c3-381127e65ae7"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AddThrust"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2a444655-5bf7-41fc-a242-8b1812e89370"",
                    ""path"": ""<DualShockGamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AddThrust"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9401ee22-1880-405a-8fb6-4da6e7b471c4"",
                    ""path"": ""<Keyboard>/i"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ActivateInventory"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""InventoryUI"",
            ""id"": ""9a2fd44e-f492-4ab6-9de1-153eb307b7a1"",
            ""actions"": [
                {
                    ""name"": ""LeftRight"",
                    ""type"": ""PassThrough"",
                    ""id"": ""6063a49f-7893-4825-93fa-949c380efede"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""AddFuel"",
                    ""type"": ""Button"",
                    ""id"": ""37ce9fd8-d8c1-43c5-ad28-6e036140e4d0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LeaveInventory"",
                    ""type"": ""Button"",
                    ""id"": ""2e1ad4bc-659b-48db-ab3c-d03e0102838f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""fde30b07-05cd-4952-9f49-b680b9240359"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftRight"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""df41e36f-a6d0-4e74-9e98-45af2c06cefa"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""ff11afb3-8a6a-43fc-8571-9382822bc51f"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""7049aa4e-581f-4bdf-8002-6818fe814bc8"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AddFuel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""51a22b94-7467-46d1-baa1-dcab83574653"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeaveInventory"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c25bca43-9bc9-4dd3-817e-4f4882a2da53"",
                    ""path"": ""<Keyboard>/i"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeaveInventory"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // SpaceShip
        m_SpaceShip = asset.FindActionMap("SpaceShip", throwIfNotFound: true);
        m_SpaceShip_Thrust = m_SpaceShip.FindAction("Thrust", throwIfNotFound: true);
        m_SpaceShip_ReverseThrust = m_SpaceShip.FindAction("ReverseThrust", throwIfNotFound: true);
        m_SpaceShip_Rotation = m_SpaceShip.FindAction("Rotation", throwIfNotFound: true);
        m_SpaceShip_AddThrust = m_SpaceShip.FindAction("AddThrust", throwIfNotFound: true);
        m_SpaceShip_ActivateInventory = m_SpaceShip.FindAction("ActivateInventory", throwIfNotFound: true);
        // InventoryUI
        m_InventoryUI = asset.FindActionMap("InventoryUI", throwIfNotFound: true);
        m_InventoryUI_LeftRight = m_InventoryUI.FindAction("LeftRight", throwIfNotFound: true);
        m_InventoryUI_AddFuel = m_InventoryUI.FindAction("AddFuel", throwIfNotFound: true);
        m_InventoryUI_LeaveInventory = m_InventoryUI.FindAction("LeaveInventory", throwIfNotFound: true);
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

    // SpaceShip
    private readonly InputActionMap m_SpaceShip;
    private ISpaceShipActions m_SpaceShipActionsCallbackInterface;
    private readonly InputAction m_SpaceShip_Thrust;
    private readonly InputAction m_SpaceShip_ReverseThrust;
    private readonly InputAction m_SpaceShip_Rotation;
    private readonly InputAction m_SpaceShip_AddThrust;
    private readonly InputAction m_SpaceShip_ActivateInventory;
    public struct SpaceShipActions
    {
        private @FieraShipControls m_Wrapper;
        public SpaceShipActions(@FieraShipControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Thrust => m_Wrapper.m_SpaceShip_Thrust;
        public InputAction @ReverseThrust => m_Wrapper.m_SpaceShip_ReverseThrust;
        public InputAction @Rotation => m_Wrapper.m_SpaceShip_Rotation;
        public InputAction @AddThrust => m_Wrapper.m_SpaceShip_AddThrust;
        public InputAction @ActivateInventory => m_Wrapper.m_SpaceShip_ActivateInventory;
        public InputActionMap Get() { return m_Wrapper.m_SpaceShip; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(SpaceShipActions set) { return set.Get(); }
        public void SetCallbacks(ISpaceShipActions instance)
        {
            if (m_Wrapper.m_SpaceShipActionsCallbackInterface != null)
            {
                @Thrust.started -= m_Wrapper.m_SpaceShipActionsCallbackInterface.OnThrust;
                @Thrust.performed -= m_Wrapper.m_SpaceShipActionsCallbackInterface.OnThrust;
                @Thrust.canceled -= m_Wrapper.m_SpaceShipActionsCallbackInterface.OnThrust;
                @ReverseThrust.started -= m_Wrapper.m_SpaceShipActionsCallbackInterface.OnReverseThrust;
                @ReverseThrust.performed -= m_Wrapper.m_SpaceShipActionsCallbackInterface.OnReverseThrust;
                @ReverseThrust.canceled -= m_Wrapper.m_SpaceShipActionsCallbackInterface.OnReverseThrust;
                @Rotation.started -= m_Wrapper.m_SpaceShipActionsCallbackInterface.OnRotation;
                @Rotation.performed -= m_Wrapper.m_SpaceShipActionsCallbackInterface.OnRotation;
                @Rotation.canceled -= m_Wrapper.m_SpaceShipActionsCallbackInterface.OnRotation;
                @AddThrust.started -= m_Wrapper.m_SpaceShipActionsCallbackInterface.OnAddThrust;
                @AddThrust.performed -= m_Wrapper.m_SpaceShipActionsCallbackInterface.OnAddThrust;
                @AddThrust.canceled -= m_Wrapper.m_SpaceShipActionsCallbackInterface.OnAddThrust;
                @ActivateInventory.started -= m_Wrapper.m_SpaceShipActionsCallbackInterface.OnActivateInventory;
                @ActivateInventory.performed -= m_Wrapper.m_SpaceShipActionsCallbackInterface.OnActivateInventory;
                @ActivateInventory.canceled -= m_Wrapper.m_SpaceShipActionsCallbackInterface.OnActivateInventory;
            }
            m_Wrapper.m_SpaceShipActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Thrust.started += instance.OnThrust;
                @Thrust.performed += instance.OnThrust;
                @Thrust.canceled += instance.OnThrust;
                @ReverseThrust.started += instance.OnReverseThrust;
                @ReverseThrust.performed += instance.OnReverseThrust;
                @ReverseThrust.canceled += instance.OnReverseThrust;
                @Rotation.started += instance.OnRotation;
                @Rotation.performed += instance.OnRotation;
                @Rotation.canceled += instance.OnRotation;
                @AddThrust.started += instance.OnAddThrust;
                @AddThrust.performed += instance.OnAddThrust;
                @AddThrust.canceled += instance.OnAddThrust;
                @ActivateInventory.started += instance.OnActivateInventory;
                @ActivateInventory.performed += instance.OnActivateInventory;
                @ActivateInventory.canceled += instance.OnActivateInventory;
            }
        }
    }
    public SpaceShipActions @SpaceShip => new SpaceShipActions(this);

    // InventoryUI
    private readonly InputActionMap m_InventoryUI;
    private IInventoryUIActions m_InventoryUIActionsCallbackInterface;
    private readonly InputAction m_InventoryUI_LeftRight;
    private readonly InputAction m_InventoryUI_AddFuel;
    private readonly InputAction m_InventoryUI_LeaveInventory;
    public struct InventoryUIActions
    {
        private @FieraShipControls m_Wrapper;
        public InventoryUIActions(@FieraShipControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @LeftRight => m_Wrapper.m_InventoryUI_LeftRight;
        public InputAction @AddFuel => m_Wrapper.m_InventoryUI_AddFuel;
        public InputAction @LeaveInventory => m_Wrapper.m_InventoryUI_LeaveInventory;
        public InputActionMap Get() { return m_Wrapper.m_InventoryUI; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(InventoryUIActions set) { return set.Get(); }
        public void SetCallbacks(IInventoryUIActions instance)
        {
            if (m_Wrapper.m_InventoryUIActionsCallbackInterface != null)
            {
                @LeftRight.started -= m_Wrapper.m_InventoryUIActionsCallbackInterface.OnLeftRight;
                @LeftRight.performed -= m_Wrapper.m_InventoryUIActionsCallbackInterface.OnLeftRight;
                @LeftRight.canceled -= m_Wrapper.m_InventoryUIActionsCallbackInterface.OnLeftRight;
                @AddFuel.started -= m_Wrapper.m_InventoryUIActionsCallbackInterface.OnAddFuel;
                @AddFuel.performed -= m_Wrapper.m_InventoryUIActionsCallbackInterface.OnAddFuel;
                @AddFuel.canceled -= m_Wrapper.m_InventoryUIActionsCallbackInterface.OnAddFuel;
                @LeaveInventory.started -= m_Wrapper.m_InventoryUIActionsCallbackInterface.OnLeaveInventory;
                @LeaveInventory.performed -= m_Wrapper.m_InventoryUIActionsCallbackInterface.OnLeaveInventory;
                @LeaveInventory.canceled -= m_Wrapper.m_InventoryUIActionsCallbackInterface.OnLeaveInventory;
            }
            m_Wrapper.m_InventoryUIActionsCallbackInterface = instance;
            if (instance != null)
            {
                @LeftRight.started += instance.OnLeftRight;
                @LeftRight.performed += instance.OnLeftRight;
                @LeftRight.canceled += instance.OnLeftRight;
                @AddFuel.started += instance.OnAddFuel;
                @AddFuel.performed += instance.OnAddFuel;
                @AddFuel.canceled += instance.OnAddFuel;
                @LeaveInventory.started += instance.OnLeaveInventory;
                @LeaveInventory.performed += instance.OnLeaveInventory;
                @LeaveInventory.canceled += instance.OnLeaveInventory;
            }
        }
    }
    public InventoryUIActions @InventoryUI => new InventoryUIActions(this);
    public interface ISpaceShipActions
    {
        void OnThrust(InputAction.CallbackContext context);
        void OnReverseThrust(InputAction.CallbackContext context);
        void OnRotation(InputAction.CallbackContext context);
        void OnAddThrust(InputAction.CallbackContext context);
        void OnActivateInventory(InputAction.CallbackContext context);
    }
    public interface IInventoryUIActions
    {
        void OnLeftRight(InputAction.CallbackContext context);
        void OnAddFuel(InputAction.CallbackContext context);
        void OnLeaveInventory(InputAction.CallbackContext context);
    }
}
