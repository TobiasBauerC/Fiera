using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item")]
public class ItemSO : ScriptableObject
{
    public Item.ItemType itemType;
    public int maxStackCount;
    public float fuelValue;
    public float creditValue;
}
