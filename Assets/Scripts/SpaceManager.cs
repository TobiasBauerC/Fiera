using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceManager : MonoBehaviour
{
    static private SpaceManager _instance;
    static public SpaceManager instance
    {
        get { return _instance; }
    }

    [SerializeField] private PlayerShipController[] playerShips;
    [SerializeField] private PlayerShipController _activeShip;
    public PlayerShipController activeShip
    {
        get { return _activeShip; }
    }

    void Awake()
    {
        if (!_instance)
            _instance = this;
        else if(_instance != this)
            Destroy(this);
    }

    void Start()
    {
        OnActiveShipChange(activeShip);
    }

    void OnActiveShipChange(PlayerShipController newActiveShip)
    {
        foreach (PlayerShipController ship in playerShips)
        {
            if (ship == newActiveShip)
            {
                _activeShip = newActiveShip;
                _activeShip.enabled = true;
            }
            else
            {
                ship.enabled = false;
            }
        }
    }

    void OnValidate()
    {
        OnActiveShipChange(activeShip);
    }
}
