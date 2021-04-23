using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShipController : MonoBehaviour
{
    [SerializeField] private float accelerationForce = 50.0f;
    [SerializeField] private float maxLinearVelocity = 100.0f;
    [SerializeField] private float rotationSpeed = 50.0f;
    [SerializeField] private Rigidbody2D rb;

    private float rotationDirection;
    private bool isThrusting = false;
    private bool isReverseThrusting = false;

    private float savedVelocity = 0.0f;


    public float MaxLinearVelocity
    {
        get { return maxLinearVelocity; }
    }
    public float SavedVelocity
    {
        get { return savedVelocity; }
    }

    // Update is called once per frame
    void Update()
    {
        rotationDirection = Input.GetAxisRaw("Horizontal") * -1.0f;
        isThrusting = Input.GetButton("Thrust");
        isReverseThrusting = Input.GetButton("ReverseThrust");
    }

    void FixedUpdate()
    {
        rb.SetRotation(rb.rotation + rotationDirection * rotationSpeed * Time.fixedDeltaTime);

        rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxLinearVelocity);
        savedVelocity = rb.velocity.magnitude;
        if (isReverseThrusting)
        {
            rb.AddForce(rb.velocity * -1.0f * accelerationForce);
        }
        else if (isThrusting)
        {
            rb.AddForce(transform.up * accelerationForce);
            //rb.velocity = transform.up * rb.velocity.magnitude;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Entry Velocity = " + rb.velocity.magnitude);
        if (collision.gameObject.CompareTag("Planet"))
        {
            Debug.Log("Entry Velocity = " + savedVelocity);
            if(savedVelocity < 2.0f)
                Debug.Log("Another happy landing!");
            else
                Debug.Log("You landed too hard and crashed your ship!");
            
        }
    }
}
