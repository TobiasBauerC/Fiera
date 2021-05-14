using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class BaseInventory : MonoBehaviour
{
    protected Item[] inventory;

    [SerializeField] protected int inventorySize = 10;

    public BaseInventory()
    {
        inventory = new Item[inventorySize];
        for (int i = 0; i < inventorySize; ++i)
            inventory[i] = new Item() {itemType = Item.ItemType.None, stackCount = 0};
    }
    
    public void AddToInventory(Item item)
    {
        int firstNullIndex = -1;
        for (int i = 0; i < inventorySize; ++i)
        {
            Item inventItem = inventory[i];
            if(inventItem != null && inventItem.itemType == item.itemType && inventItem.stackCount < ItemDatabase.GetMaxStack(inventItem.itemType)) // item has a slot in inventory and is not full
            {
                UpdateInventorySlot(item, inventItem); // update that inventory slot
                return;
            }
            if (firstNullIndex == -1 && inventItem.itemType == Item.ItemType.None)
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
        if (newCount < ItemDatabase.GetMaxStack(inventItem.itemType))
        {
            inventItem.stackCount = newCount;
        }
        else
        {
            inventItem.stackCount = ItemDatabase.GetMaxStack(inventItem.itemType);
            AddToInventory(new Item { itemType = item.itemType, stackCount = (newCount - ItemDatabase.GetMaxStack(inventItem.itemType)) });
        }

        EventManager.Broadcast(EVENT.InventoryUpdated);
    }

    public Item GetItemAtIndex(int index)
    {
        return inventory[index].itemType == Item.ItemType.None ? null : inventory[index];
    }

    public void ClearInventoryAtIndex(int index)
    {
        inventory[index].ClearItem();
        EventManager.Broadcast(EVENT.InventoryUpdated);
    }
}
