using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class BaseInventory : MonoBehaviour
{
    private Item[] inventory;

    [SerializeField] private int inventorySize = 10;

    public BaseInventory()
    {
        inventory = new Item[inventorySize];
    }
    
    public void AddToInventory(Item item)
    {
        int firstNullIndex = -1;
        for (int i = 0; i < inventorySize; ++i)
        {
            Item inventItem = inventory[i];
            if(inventItem != null && inventItem.itemType == item.itemType && inventItem.stackCount < inventItem.maxStackCount) // item has a slot in inventory and is not full
            {
                UpdateInventorySlot(item, inventItem); // update that inventory slot
                return;
            }
            else if (firstNullIndex == -1 && inventItem.itemType == Item.ItemType.None)
                firstNullIndex = i;
        }
        if (firstNullIndex != -1) // item is not in the inventory and there is an empty slot
        {
            Item inventItem = inventory[firstNullIndex] = new Item { itemType = item.itemType, stackCount = 0 }; // add the item with count zero to the inventory
            UpdateInventorySlot(item, inventItem);
        }
    }

    void UpdateInventorySlot(Item item, Item inventItem)
    {
        int newCount = item.stackCount + inventItem.stackCount;;
        if (newCount < inventItem.maxStackCount)
            inventItem.stackCount = newCount;
        else
        {
            inventItem.stackCount = inventItem.maxStackCount;
            AddToInventory(new Item { itemType = item.itemType, stackCount = (newCount - inventItem.maxStackCount) });
        }
    }
}
