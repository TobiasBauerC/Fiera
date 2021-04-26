using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetGravityPull : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private float maxDistToPull = 500.0f;

    void FixedUpdate()
    {
        Rigidbody2D playerRB = SpaceManager.instance.activeShip.rb;

        Vector2 direction = rb.position - playerRB.position;
        float distance = direction.magnitude;

        if (distance < maxDistToPull)
        {
            float forceMagnitude = (rb.mass * playerRB.mass) / Mathf.Pow(distance, 2);
            Vector2 force = direction.normalized * forceMagnitude;

            playerRB.AddForce(force);
        }
    }
}
