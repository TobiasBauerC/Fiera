using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BaseInventory : MonoBehaviour
{
    protected Item[] inventory;

    [SerializeField] protected int inventorySize = 10;
    [SerializeField] private Image[] itemImages;

    public BaseInventory()
    {
        inventory = new Item[inventorySize];
        for (int i = 0; i < inventorySize; ++i)
            inventory[i] = new Item() {itemType = Item.ItemType.None, stackCount = 0};
    }

    protected virtual void Init()
    {
        EventManager.AddHandler(EVENT.FuelChanged, UpdateItemImages);
    }
    
    public void AddToInventory(Item item)
    {
        int firstNullIndex = -1; // Track position of first empty inventory slot
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

        UpdateItemImages();
    }

    void UpdateItemImages()
    {
        for (int i = 0; i < itemImages.Length; ++i)
        {
            Image image = itemImages[i];
            Item item = inventory[i];
            TextMeshProUGUI tmp = image.GetComponentInChildren<TextMeshProUGUI>();
            if (item.itemType == Item.ItemType.None || item.stackCount <= 0)
            {
                image.enabled = false;
                tmp.text = string.Empty;
                image.sprite = null;
            }
            else
            {
                image.sprite = ItemDatabase.GetSprite(inventory[i].itemType);
                image.enabled = true;
                tmp.text = item.stackCount.ToString();
            }
        }
    }

    public Item GetItemAtIndex(int index)
    {
        return inventory[index].itemType == Item.ItemType.None ? null : inventory[index];
    }

    public void ClearInventoryAtIndex(int index)
    {
        inventory[index].ClearItem();
        UpdateItemImages();
    }

    protected int GetFirstItemIndex()
    {
        for (int i = 0; i < inventory.Length; i++)
        {
            if(inventory[i].itemType != Item.ItemType.None && inventory[i].stackCount > 0)
                return i;
        }

        return -1;
    }

    protected Vector3 GetItemImagePosition(int index)
    {
        return itemImages[index].transform.position;
    }

    protected int ChangeSelection(int currentIndex, int deltaIndex)
    {
        // If there is nothing in the inventory, don't return an index
        if (GetFirstItemIndex() == -1)
            return -1;

        int attempts = 0;
        int newIndex = currentIndex;
        int clampedDeltaIndex = Mathf.Clamp(deltaIndex, -1, 1);

        while (attempts < inventory.Length)
        {
            newIndex += clampedDeltaIndex;
            if (newIndex < 0)
                newIndex = inventory.Length - 1;
            if (newIndex >= inventory.Length)
                newIndex = 0;

            if (inventory[newIndex].itemType != Item.ItemType.None && inventory[newIndex].stackCount > 0)
                break;
            attempts++;
        }

        return newIndex;
    }

    void OnEnable()
    {
        UpdateItemImages();
    }
}
