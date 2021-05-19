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

    // Input System
    private FieraShipControls _fieraShipInput;
    
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
    public FieraShipControls fieraShipInput
    {
        get { return _fieraShipInput; }
    }

    #region InputSetup

    void Awake()
    {
        _fieraShipInput = new FieraShipControls();
        fieraShipInput.InventoryUI.Disable();
    }

    void OnEnable()
    {
        fieraShipInput.Enable();
    }

    void OnDisable()
    {
        rb.velocity = Vector2.zero;
        fieraShipInput.Disable();
    }

    #endregion

    void Start()
    {
        _currentFuel = _maxFuel;
        currentHealth = maxHealth;

        EventManager.Broadcast(EVENT.FuelChanged);

        fieraShipInput.SpaceShip.Thrust.started += _ => { isThrusting = true; };
        fieraShipInput.SpaceShip.Thrust.canceled += _ => { isThrusting = false; };
        fieraShipInput.SpaceShip.ReverseThrust.started += _ => { isReverseThrusting = true; };
        fieraShipInput.SpaceShip.ReverseThrust.canceled += _ => { isReverseThrusting = false; };
        fieraShipInput.SpaceShip.AddThrust.started += _ => { isAddingThrust = true; };
        fieraShipInput.SpaceShip.AddThrust.canceled += _ => { isAddingThrust = false; };
        fieraShipInput.SpaceShip.ActivateInventory.performed += _ => EnableInventory();
        fieraShipInput.InventoryUI.LeaveInventory.performed += _ => DisableInventory();
    }
    
    void Update()
    {
        if(_currentFuel <= 0.0f || currentHealth <= 0.0f)
            return;

        //rotationDirection = -Input.GetAxisRaw("Horizontal");
        rotationDirection = -fieraShipInput.SpaceShip.Rotation.ReadValue<float>();
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
        if(rotationDirection != 0.0f) UpdateFuel(fuelLost);
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

    public void UpdateFuel(float deltaFuel)
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

    // Turn off Player Ship Action Map and enable Inventory Action Map
    void EnableInventory()
    {
        isThrusting = isReverseThrusting = isAddingThrust = false;
        fieraShipInput.SpaceShip.Disable();
        fieraShipInput.InventoryUI.Enable();
    }

    // Turn off Inventory Action Map and enable Player Ship Action Map
    void DisableInventory()
    {
        fieraShipInput.InventoryUI.Disable();
        fieraShipInput.SpaceShip.Enable();
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
