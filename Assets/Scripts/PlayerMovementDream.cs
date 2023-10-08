using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementDream : MonoBehaviour
{
    public float FloatMovementForce = 2f;
    public float Drag = 0.05f;
    public float MaxVelocity = 3f;

    private PlayerInput playerInput;
    private InputAction moveAction;
    private Rigidbody2D rb;

    private PlayerInputSystem inputSystem;

    private Vector2 moveInput;
    private Vector2 _tempScale;

    // Start is called before the first frame update
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.actions.FindAction("Move");
        rb = GetComponent<Rigidbody2D>();
        inputSystem = new PlayerInputSystem();
        inputSystem.Player.Enable();
    }

    void Update()
    {
        GetInput();
        HandleFacingDirection();
    }

    private void FixedUpdate()
    {
        GravityMovement();
    }

    private void GetInput()
    {
        moveInput = moveAction.ReadValue<Vector2>();
    }

            void HandleFacingDirection()
        {
            _tempScale = transform.localScale;

            if (moveInput.x > 0)
                _tempScale.x = Mathf.Abs(_tempScale.x);
            else if (moveInput.x < 0)
                _tempScale.x = -Mathf.Abs(_tempScale.x);

            transform.localScale = _tempScale;
        }


    private void GravityMovement()
    {
        //Setup Physics
        rb.gravityScale = 0f;
        rb.drag = Drag;

        //Player Floaty Movement
        rb.AddForce(moveInput * FloatMovementForce);

        //Clamp float speed  
        if (rb.velocity.magnitude > MaxVelocity)
        {
            rb.velocity = rb.velocity.normalized;
            rb.velocity *= MaxVelocity;
        }
    }
}
