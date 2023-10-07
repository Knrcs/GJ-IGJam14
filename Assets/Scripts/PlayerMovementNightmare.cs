using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementNightmare : MonoBehaviour
{
    [Header("Movement")]
    public float WalkSpeed = 5f;

    [Header("Jump")]
    public float JumpCancelSpeed = 0.1f;
    public float JumpForce = 5f;
    public float RigidbodyGravityScale = 1f;

    [Header("GroundCheck")]
    public Collider2D GroundCollider;
    public ContactFilter2D GroundColliderFilter;

    private PlayerInput playerInput;
    private InputAction moveAction;
    private Rigidbody2D rb;

    private PlayerInputSystem inputSystem;

    private bool isGrounded;
    private Vector2 moveInput;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.actions.FindAction("Move");
    }

    private void FixedUpdate()
    {
        GroundedCheck();
        Movement();
    }

    void Update()
    {
        GetInput();
    }

    private void OnEnable()
    {
        if (inputSystem == null)
        {
            inputSystem = new PlayerInputSystem();
        }

        inputSystem.Player.Enable();
        inputSystem.Player.Jump.performed += Jump;
        inputSystem.Player.Jump.canceled += Jump_canceled;
    }

    private void OnDisable()
    {
        if (inputSystem != null)
        {
            inputSystem.Player.Disable();
            inputSystem.Player.Jump.performed -= Jump;
            inputSystem.Player.Jump.canceled -= Jump_canceled;
        }
    }

    private void GetInput()
    {
        moveInput = moveAction.ReadValue<Vector2>();
    }

    private void GroundedCheck()
    {
        var list = new List<Collider2D>();
        var count = GroundCollider.OverlapCollider(GroundColliderFilter, list);

        isGrounded = count > 0;
    }

    private void Movement()
    {
        //set Variables
        rb.gravityScale = RigidbodyGravityScale;
        rb.drag = 0f;
        //Player Horizontal Movement
        float horizontalInput = moveInput.x;

        rb.velocity = new Vector2(horizontalInput * WalkSpeed, rb.velocity.y);
    }

    private void Jump(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        if (isGrounded)
        {
            rb.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
        }
    }

    private void Jump_canceled(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        if (!isGrounded)
        {
            var v = rb.velocity;
            v.y = Mathf.Min(v.y, JumpCancelSpeed);
            rb.velocity = v;
        }
    }
}
