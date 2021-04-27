using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseItem : MonoBehaviour
{
    [SerializeField] private string _itemName;
    [SerializeField] private float _creditValue;
    [SerializeField] private float _fuelValue;
    [SerializeField] private int _maxInventoryStack;

    public string itemName
    {
        get { return _itemName; }
        protected set { _itemName = value; }
    }
    public float creditValue
    {
        get { return _creditValue; }
        protected set { _creditValue = value; }
    }
    public float fuelValue
    {
        get { return _fuelValue; }
        protected set { _fuelValue = value; }
    }
    public int maxInventoryStack
    {
        get { return _maxInventoryStack; }
        protected set { _maxInventoryStack = value; }
    }

    void Update()
    {
        if(Input.anyKey)
            InventoryManager.instance.AddToInventory(this, 150);
    }
}
