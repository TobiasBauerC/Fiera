using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : BaseInventory
{
    [SerializeField] private PlayerShipController playerShipController;
    [SerializeField] private Image selectedItemMarker;

    private int currentlySelectedIndex = -1;

    void Start()
    {
        Init();
    }

    protected override void Init()
    {
        base.Init();

        selectedItemMarker.gameObject.SetActive(false);
        playerShipController.fieraShipInput.SpaceShip.ActivateInventory.performed += _ => OnEnableInventory();
        playerShipController.fieraShipInput.InventoryUI.LeaveInventory.performed += _ => OnDisableInventory();
        playerShipController.fieraShipInput.InventoryUI.AddFuel.performed += _ => AddFuelToPlayerShip();
        playerShipController.fieraShipInput.InventoryUI.SelectionLeft.performed += _ => UpdateSelection(-1);
        playerShipController.fieraShipInput.InventoryUI.SelectionRight.performed += _ => UpdateSelection(1);
    }

    void SetMarkerLocation()
    {
        Vector3 position = Vector3.zero;
        //int firstItemIndex = GetFirstItemIndex();
        int itemPos = currentlySelectedIndex >= 0 ? currentlySelectedIndex : 0;
        
        selectedItemMarker.transform.position = GetItemImagePosition(itemPos);
        selectedItemMarker.gameObject.SetActive(true);
    }

    void UpdateSelection(int deltaIndex)
    {
        currentlySelectedIndex = ChangeSelection(currentlySelectedIndex, deltaIndex);
        SetMarkerLocation();
    }

    void AddFuelToPlayerShip()
    {
        // No items in inventory, return
        if (!selectedItemMarker.gameObject.activeSelf)
            return;
        float fuelToAdd = ItemDatabase.GetFuelValue(inventory[currentlySelectedIndex].itemType);
        inventory[currentlySelectedIndex].stackCount--;
        if (inventory[currentlySelectedIndex].stackCount <= 0)
        {
            ClearInventoryAtIndex(currentlySelectedIndex);
            UpdateSelection(1);
        }
        playerShipController.UpdateFuel(fuelToAdd);
    }

    void OnDisableInventory()
    {
        selectedItemMarker.gameObject.SetActive(false);
    }

    void OnEnableInventory()
    {
        currentlySelectedIndex = GetFirstItemIndex();
        SetMarkerLocation();
    }
}
