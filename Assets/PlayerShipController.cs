using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShipController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float accelerationForce = 50.0f;
    [SerializeField] private float maxLinearVelocity = 100.0f;
    [SerializeField] private float rotationSpeed = 50.0f;
    [SerializeField] private Rigidbody2D rb;
    [Header("Landing")]
    [SerializeField] private float maxLandingVelocity = 2.0f;
    [SerializeField] private Transform[] landingGears;
    [SerializeField] private LayerMask landingMask;

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
        MoveShip();
        RotateShip();
    }

    void RotateShip()
    {
        //float speedPercentage = savedVelocity / maxLinearVelocity;
        //float modedRatationSpeed = Mathf.Lerp(0.0f, rotationSpeed, speedPercentage);
        //rb.SetRotation(rb.rotation + rotationDirection * rotationSpeed * Time.fixedDeltaTime);
        rb.AddTorque(rb.rotation + rotationSpeed * rotationDirection, ForceMode2D.Force);
    }

    void MoveShip()
    {
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxLinearVelocity);
        savedVelocity = rb.velocity.magnitude;
        //rb.velocity = transform.up * rb.velocity.magnitude;
        if (isReverseThrusting)
        {
            rb.AddForce(rb.velocity * -1.0f * accelerationForce);
        }
        if (isThrusting)
        {
            rb.AddForce(transform.up * accelerationForce);
        }
    }

    void CheckLanding()
    {
        if(savedVelocity > maxLandingVelocity)
            FailedLanding(1);

        foreach (Transform landingGear in landingGears)
        {
            RaycastHit2D hit2D = Physics2D.Raycast(landingGear.position, -transform.up, 0.2f, landingMask);
            if(!hit2D || !hit2D.collider.CompareTag("Planet"))
                FailedLanding(2);
        }
    }

    void FailedLanding(int reason)
    {
        Debug.LogWarning("Failed Landing due to " + reason);
        transform.position = Vector3.zero;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Planet"))
        {
            CheckLanding();                
        }
    }
}
