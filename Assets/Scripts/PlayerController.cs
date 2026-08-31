using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float torqueForce = 2.5f;

    private Rigidbody2D rb;

    private InputAction moveAction;
    
    void Start()
    {        
        moveAction = InputSystem.actions.FindAction("Move");
        rb = GetComponent<Rigidbody2D>();   
    }

    
    void Update()
    {
        Vector2 moveValue = moveAction.ReadValue<Vector2>();
        if (moveValue.x < 0)
        {
            rb.AddTorque(torqueForce);
        }
        else if (moveValue.x > 0)
        {
            rb.AddTorque(-torqueForce);
        }
    }
}
