using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerShipController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float accelerationForce = 50.0f;
    [SerializeField] private float maxLinearVelocity = 100.0f;
    [SerializeField] private float rotationSpeed = 50.0f;
    [SerializeField] private Rigidbody2D _rb;
    [Header("Landing")]
    [SerializeField] private float maxLandingVelocity = 2.0f;
    [SerializeField] private Transform[] landingGears;
    [SerializeField] private LayerMask landingMask;
    [Header("Camera")]
    [SerializeField] private float _minCameraSize = 5.0f;
    [SerializeField] private float _maxCameraSize = 25.0f;


    private float rotationDirection;
    private bool isThrusting = false;
    private bool isReverseThrusting = false;

    private float savedVelocity = 0.0f;

    public Rigidbody2D rb
    {
        get { return _rb; }
    }
    public float MaxLinearVelocity
    {
        get { return maxLinearVelocity; }
    }
    public float SavedVelocity
    {
        get { return savedVelocity; }
    }
    public float minCameraSize
    {
        get { return _minCameraSize; }
    }
    public float maxCameraSize
    {
        get { return _maxCameraSize; }
    }

    // Update is called once per frame
    void Update()
    {
        rotationDirection = -Input.GetAxisRaw("Horizontal");
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
        //_rb.SetRotation(_rb.rotation + rotationDirection * rotationSpeed * Time.fixedDeltaTime);
        rb.AddTorque(rotationSpeed * rotationDirection, ForceMode2D.Force);
    }

    void MoveShip()
    {
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxLinearVelocity);
        savedVelocity = rb.velocity.magnitude;
        //_rb.velocity = transform.up * _rb.velocity.magnitude;
        if (isReverseThrusting)
        {
            rb.AddForce(-rb.velocity * accelerationForce);
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

    void OnTriggerEnter2D(Collider2D collider)
    {
        WorldItem worldItem = collider.GetComponent<WorldItem>();
        if (worldItem != null)
        {
            PlayerInventory.instance.AddToInventory(worldItem.item);
            Destroy(collider.gameObject);
        }
    }

    void OnDisable()
    {
        rb.velocity = Vector2.zero;
    }
}
