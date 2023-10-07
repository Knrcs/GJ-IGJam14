using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementNightmare : MonoBehaviour
{
    [Header("Movement")]
    public float walkSpeed = 5f;

    [Header("Jump")]
    public float jumpCancelSpeed = 0.1f;
    public float jumpForce = 15f;
    public float rigidbodyGravityScale = 1f;

    [Header("GroundCheck")]
    public Collider2D GroundCollider;
    public ContactFilter2D GroundColliderFilter;

    private float currentMoveSpeed = 5f;

    private PlayerInput playerInput;
    private InputAction moveAction;
    private Rigidbody2D rb;

    private PlayerInputSystem inputSystem;

    private bool isGrounded;
    private Vector2 moveInput;

    // Start is called before the first frame update
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.actions.FindAction("Move");
        rb = GetComponent<Rigidbody2D>();
        inputSystem = new PlayerInputSystem();
        inputSystem.Player.Enable();
        inputSystem.Player.Jump.performed += Jump;
        inputSystem.Player.Jump.canceled += Jump_canceled;
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

    private void OnDestroy()
    {
        if (inputSystem != null)
        {
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
        currentMoveSpeed = walkSpeed;
        rb.gravityScale = rigidbodyGravityScale;
        //Player Horizontal Movement
        float horizontalInput = moveInput.x;

        rb.velocity = new Vector2(horizontalInput * currentMoveSpeed, rb.velocity.y);
    }

    private void Jump(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        if (isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    private void Jump_canceled(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        if (!isGrounded)
        {
            var v = rb.velocity;
            v.y = Mathf.Min(v.y, jumpCancelSpeed);
            rb.velocity = v;
        }
    }
}
