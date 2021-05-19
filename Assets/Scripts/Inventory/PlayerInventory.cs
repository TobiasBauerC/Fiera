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

    protected void Init()
    {
        base.Init();

        selectedItemMarker.gameObject.SetActive(false);
        playerShipController.fieraShipInput.SpaceShip.ActivateInventory.performed += _ => SetMarkerLocation();
        playerShipController.fieraShipInput.InventoryUI.LeaveInventory.performed += _ => OnDisableInventory();
        playerShipController.fieraShipInput.InventoryUI.AddFuel.performed += _ => AddFuelToPlayerShip();
    }

    void SetMarkerLocation()
    {
        Vector3 position = Vector3.zero;
        int firstItemIndex = GetFirstItemIndex();
        if (firstItemIndex < 0)
        {
            currentlySelectedIndex = -1;
            selectedItemMarker.gameObject.SetActive(false);
            return;
        }

        currentlySelectedIndex = firstItemIndex;
        selectedItemMarker.transform.position = GetItemImagePosition(firstItemIndex);
        selectedItemMarker.gameObject.SetActive(true);
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
            SetMarkerLocation();
        }
        playerShipController.UpdateFuel(fuelToAdd);
    }

    void OnDisableInventory()
    {
        selectedItemMarker.gameObject.SetActive(false);
    }
}
