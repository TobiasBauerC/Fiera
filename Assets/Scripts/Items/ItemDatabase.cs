using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    [SerializeField] private List<ItemSO> _items;
    private static List<ItemSO> items;

    void Awake()
    {
        items = _items;
    }

    public static ItemSO GetItemSO(Item.ItemType itemType)
    {
        return items.Find(item => item.itemType == itemType);
    }

    public static int GetMaxStack(Item.ItemType itemType)
    {
        return GetItemSO(itemType).maxStackCount;
    }

    public static float GetFuelValue(Item.ItemType itemType)
    {
        return GetItemSO(itemType).fuelValue;
    }

    public static float GetCreditValue(Item.ItemType itemType)
    {
        return GetItemSO(itemType).creditValue;
    }
}
