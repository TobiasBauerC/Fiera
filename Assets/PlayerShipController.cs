using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShipController : MonoBehaviour
{
    public float accelerationForce = 50.0f;
    public float maxLinearVelocity = 100.0f;
    public float rotationSpeed = 50.0f;
    public float maxAngularVelocity = 100.0f;
    public Rigidbody2D rb;

    private float rotationDirection;
    private bool isThrusting = false;

    // Update is called once per frame
    void Update()
    {
        rotationDirection = Input.GetAxisRaw("Horizontal") * -1.0f;
        isThrusting = Input.GetButton("Thrust");
    }

    void FixedUpdate()
    {
        rb.AddTorque(rotationDirection * rotationSpeed * Time.fixedDeltaTime);
        if (rb.angularVelocity > maxAngularVelocity)
            rb.angularVelocity = maxAngularVelocity;

        rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxLinearVelocity);
        //rb.velocity = transform.up * rb.velocity.magnitude;
        if (isThrusting) rb.AddForce(transform.up * accelerationForce);
    }
}
