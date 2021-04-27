using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    static private InventoryManager _instance;
    static public InventoryManager instance
    {
        get { return _instance; }
    }

    private ItemEntry[] inventory;

    [SerializeField] private int inventorySize = 10;

    void Awake()
    {
        if (!_instance)
            _instance = this;
        else if(_instance != this)
            Destroy(this);
    }

    void Start()
    {
        inventory = new ItemEntry[inventorySize];
    }
    
    public void AddToInventory(BaseItem item, int count)
    {
        int nullInventoryIndex = -1; // track the first empty inventory slot
        for (int i = 0; i < inventorySize; i++) // loop through inventory
        { 
            if (!inventory[i].item && nullInventoryIndex == -1) // check if this is the first empty inventory slot
                nullInventoryIndex = i; // set index of first empty inventory slot
            else if(inventory[i].item && inventory[i].item.name == item.name && inventory[i].stackCount < item.maxInventoryStack) // item has a slot in inventory and does not fill max stack for that item
            {
                UpdateInventoryEntry(item, ref inventory[i], count); // update that inventory slot
                return;
            }
        }
        if (nullInventoryIndex != -1) // item is not in the inventory and there is an empty slot
            UpdateInventoryEntry(item, ref inventory[nullInventoryIndex], count); // add the new item to inventory
    }

    void UpdateInventoryEntry(BaseItem item, ref ItemEntry itemEntry, int count)
    {
        if (!itemEntry.item)
            itemEntry.item = item;
        int newCount = itemEntry.stackCount + count; // calculate new item stack count in inventory
        if (newCount <= item.maxInventoryStack) // if the new stack count is less than the maximum, add it and destroy the in game item 
            itemEntry.stackCount = newCount; // update item stack count
        else // if the new stack count would be too big
        {
            itemEntry.stackCount = item.maxInventoryStack; // set inventory slot to max count
            AddToInventory(item, newCount - item.maxInventoryStack); // send item with updated count back into inventory to find a new slot
        }
    }

    public struct ItemEntry
    {
        public BaseItem item;
        public int stackCount;
    }
}
