using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerShipController : MonoBehaviour
{
    [SerializeField] private float takeOffMultiplier = 10.0f;
    [Header("Movement")]
    [SerializeField] private float accelerationForce = 50.0f;
    [SerializeField] private float _maxLinearVelocity = 100.0f;
    [SerializeField] private float rotationSpeed = 50.0f;
    [SerializeField] private Rigidbody2D _rb;
    [Header("Landing")]
    [SerializeField] private float maxLandingVelocity = 2.0f;
    [SerializeField] private Transform[] landingGears;
    [SerializeField] private LayerMask landingMask;
    [Header("Camera")]
    [SerializeField] private float _minCameraSize = 5.0f;
    [SerializeField] private float _maxCameraSize = 25.0f;

    [Header("Ship Stats")] 
    [SerializeField] private float maxHealth = 100.0f;
    [SerializeField] private float _maxFuel = 100.0f;
    [SerializeField] private float fuelLossPerSecond = 1.0f;
    [SerializeField] private float fuelLossRotationDivider = 2.0f;

    [Header("Other Refs")] 
    [SerializeField] private PlayerInventory playerInventory;


    private bool isThrusting = false;
    private bool isReverseThrusting = false;
    private bool isAddingThrust = false;

    private FieraShipControls fieraShipControls;
    
    private float rotationDirection;
    private float _savedVelocity = 0.0f;


    private float _currentFuel;
    private float currentHealth;

    public Rigidbody2D rb
    {
        get { return _rb; }
    }
    public float maxLinearVelocity
    {
        get { return _maxLinearVelocity; }
    }
    public float savedVelocity
    {
        get { return _savedVelocity; }
    }
    public float minCameraSize
    {
        get { return _minCameraSize; }
    }
    public float maxCameraSize
    {
        get { return _maxCameraSize; }
    }
    public float maxFuel
    {
        get { return _maxFuel; }
    }
    public float currentFuel
    {
        get { return _currentFuel; }
    }

    #region InputSetup

    void Awake()
    {
        fieraShipControls = new FieraShipControls();
    }

    void OnEnable()
    {
        fieraShipControls.Enable();
    }

    void OnDisable()
    {
        rb.velocity = Vector2.zero;
        fieraShipControls.Disable();
    }

    #endregion

    void Start()
    {
        _currentFuel = _maxFuel;
        currentHealth = maxHealth;

        EventManager.Broadcast(EVENT.FuelChanged);

        fieraShipControls.SpaceShip.Thrust.started += _ => { isThrusting = true; };
        fieraShipControls.SpaceShip.Thrust.canceled += _ => { isThrusting = false; };
        fieraShipControls.SpaceShip.ReverseThrust.started += _ => { isReverseThrusting = true; };
        fieraShipControls.SpaceShip.ReverseThrust.canceled += _ => { isReverseThrusting = false; };
        fieraShipControls.SpaceShip.AddThrust.started += _ => { isAddingThrust = true; };
        fieraShipControls.SpaceShip.AddThrust.canceled += _ => { isAddingThrust = false; };
    }
    
    void Update()
    {
        if(_currentFuel <= 0.0f || currentHealth <= 0.0f)
            return;

        //rotationDirection = -Input.GetAxisRaw("Horizontal");
        rotationDirection = -fieraShipControls.SpaceShip.Rotation.ReadValue<float>();
    }

    void FixedUpdate()
    {
        if (_currentFuel <= 0.0f || currentHealth <= 0.0f)
            return;

        if (isAddingThrust)
            MoveShip(takeOffMultiplier);
        else
            MoveShip();
        RotateShip();
    }

    void RotateShip()
    {
        rb.AddTorque(rotationSpeed * rotationDirection, ForceMode2D.Force);
        float fuelLost = -(fuelLossPerSecond / fuelLossRotationDivider * Mathf.Abs(rotationDirection) * Time.fixedDeltaTime);
        UpdateFuel(fuelLost);
    }

    void MoveShip(float additionalForce = 1.0f)
    {
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, _maxLinearVelocity);
        _savedVelocity = rb.velocity.magnitude;
        if (isReverseThrusting)
        {
            rb.AddForce(-rb.velocity * accelerationForce * additionalForce);
            UpdateFuel(-(fuelLossPerSecond * additionalForce * Time.fixedDeltaTime));
        }
        else if (isThrusting)
        {
            rb.AddForce(transform.up * accelerationForce * additionalForce);
            UpdateFuel(-(fuelLossPerSecond * additionalForce * Time.fixedDeltaTime));
        }
    }

    void UpdateFuel(float deltaFuel)
    {
        _currentFuel = Mathf.Clamp(_currentFuel + deltaFuel, 0.0f, maxFuel);
        EventManager.Broadcast(EVENT.FuelChanged);
    }

    void CheckLanding()
    {
        if(_savedVelocity > maxLandingVelocity)
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
            playerInventory.AddToInventory(worldItem.item);
            Destroy(collider.gameObject);
        }
    }
}
