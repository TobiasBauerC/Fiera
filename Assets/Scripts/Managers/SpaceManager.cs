using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceManager : MonoBehaviour
{
    [SerializeField] private PlayerShipController[] playerShips;
    [SerializeField] private PlayerShipController _activeShip;
    public PlayerShipController activeShip
    {
        get { return _activeShip; }
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
