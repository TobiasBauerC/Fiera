using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item")]
public class ItemSO : ScriptableObject
{
    [SerializeField] private Item.ItemType _itemType;
    [SerializeField] private int _maxStackCount;
    [SerializeField] private float _fuelValue;
    [SerializeField] private float _creditValue;
    [SerializeField] private Sprite _sprite;

    public Item.ItemType itemType
    {
        get { return _itemType; }
    }
    public int maxStackCount
    {
        get { return _maxStackCount; }
    }
    public float fuelValue
    {
        get { return _fuelValue; }
    }
    public float creditValue
    {
        get { return _creditValue; }
    }
    public Sprite sprite
    {
        get { return _sprite; }
    }
}
