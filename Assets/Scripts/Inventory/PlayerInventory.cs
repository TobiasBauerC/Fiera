using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : BaseInventory
{
    [SerializeField] private Image[] itemImages;

    void Awake()
    {
        EventManager.AddHandler(EVENT.InventoryUpdated, UpdateItemImages);
    }

    void Start()
    {
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
}
