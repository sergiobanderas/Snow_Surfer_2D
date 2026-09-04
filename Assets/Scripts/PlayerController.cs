using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float torqueForce = 2.5f;
    [SerializeField] private float baseSpeed = 15f;
    [SerializeField] private float boostMultiplier = 20f;

    private Rigidbody2D rb;
    SurfaceEffector2D surfaceEffector2D;

    private InputAction moveAction;

    Vector2 moveValue;
    
    void Start()
    {        
        moveAction = InputSystem.actions.FindAction("Move");
        rb = GetComponent<Rigidbody2D>();   
        surfaceEffector2D = FindAnyObjectByType<SurfaceEffector2D>();
    }

    
    void Update()
    {
        RotatePlayer();
        BoostPlayer();
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
}
