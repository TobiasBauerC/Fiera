using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : BaseInventory
{
    static private PlayerInventory _instance;
    static public PlayerInventory instance
    {
        get { return _instance; }
    }

    void Awake()
    {
        if (!_instance)
            _instance = this;
        else if(_instance != this)
            Destroy(this);
    }
}
