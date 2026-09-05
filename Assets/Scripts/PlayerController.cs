using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float torqueForce = 2.5f;
    [SerializeField] private float baseSpeed = 15f;
    [SerializeField] private float boostMultiplier = 20f;

    private Rigidbody2D rb;
    SurfaceEffector2D surfaceEffector2D;
    ScoreManager scoreManager;

    private InputAction moveAction;

    Vector2 moveValue;
    [HideInInspector]
    private bool canControlPlayer = true;

    float previousRotation;
    float totalRotation;
    int flipCount;




    public bool CanControlPlayer { get => canControlPlayer; set => canControlPlayer = value; }


    void Start()
    {        
        moveAction = InputSystem.actions.FindAction("Move");
        rb = GetComponent<Rigidbody2D>();   
        surfaceEffector2D = FindAnyObjectByType<SurfaceEffector2D>();
        scoreManager = FindAnyObjectByType<ScoreManager>();
    }

    
    void Update()
    {
        if (CanControlPlayer)
        {
            RotatePlayer();
            BoostPlayer();
            CalculateFlips();
        }
        
    }

    void RotatePlayer()
    {
        moveValue = moveAction.ReadValue<Vector2>();
        if (moveValue.x < 0)
        {
            rb.AddTorque(torqueForce);
        }
        else if (moveValue.x > 0)
        {
            rb.AddTorque(-torqueForce);
        }
    }

    void BoostPlayer()
    {
        
         if (moveValue.y > 0)
        {
            Debug.Log("Boosting");
            surfaceEffector2D.speed = boostMultiplier;
        }
        else
        {
            surfaceEffector2D.speed = baseSpeed;
        }

    }

    void CalculateFlips()
    {
        float currentRotation = transform.rotation.eulerAngles.z;
        totalRotation += Mathf.DeltaAngle(previousRotation, currentRotation);
        if (totalRotation > 340 || totalRotation < -30)
        {
            flipCount++;
            totalRotation = 0;
            scoreManager.AddScore(flipCount*100);
            
        }

        previousRotation = currentRotation;
        
    }

    public void ActivatePowerUpEffect(PowerUpScriptableObject powerUpData)
    {
        if (powerUpData.PowerUpType == "speed")
        {
            baseSpeed += powerUpData.ValueChange;
            boostMultiplier += powerUpData.ValueChange;
        }
        
    }

    public void DeactivatePowerUpEffect(PowerUpScriptableObject powerUpData)
    {
        if (powerUpData.PowerUpType == "speed")
        {
            baseSpeed -= powerUpData.ValueChange;
            boostMultiplier -= powerUpData.ValueChange;
        }
        
    }
}
