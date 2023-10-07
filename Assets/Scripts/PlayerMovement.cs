using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public bool switchMovementType;
    public Collider2D GroundCollider;
    public ContactFilter2D GroundColliderFilter;

    [Header("Movement")]

    public float jumpCancelSpeed = 0.1f;
    public float walkSpeed = 5f;

    public float jumpForce = 15f;
    [Header("Gravity")]
    public float gravitySpeed = 2f;
    public float rigidbodyGravityScale = 1f;
    public float maxRigidbodyVelocity = 3f;

    private float moveSpeed = 5f;

    private PlayerInput _playerInput;
    private InputAction _moveAction;
    private Rigidbody2D _rigidbody;

    private PlayerInputSystem _input;

    private bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        _playerInput = GetComponent<PlayerInput>();
        _moveAction = _playerInput.actions.FindAction("Move");
        _rigidbody = GetComponent<Rigidbody2D>();
        _input = new PlayerInputSystem();
        _input.Player.Enable();
        _input.Player.Jump.performed += Jump;
        _input.Player.Jump.canceled += Jump_canceled;
    }

    private void FixedUpdate()
    {
        GroundedCheck();
    }

    private void OnDestroy()
    {
        _input.Player.Jump.performed -= Jump;
        _input.Player.Jump.canceled -= Jump_canceled;
    }

    private void GroundedCheck()
    {
        var list = new List<Collider2D>();
        var count = GroundCollider.OverlapCollider(GroundColliderFilter, list);

        isGrounded = count > 0;
    }

    // Update is called once per frame
    void Update()
    {

        if (!switchMovementType)
        {
            Movement();
        }
        else
        {
            GravityMovement();
        }
    }

    private void Movement()
    {
        //set Variables
        moveSpeed = walkSpeed;
        _rigidbody.gravityScale = rigidbodyGravityScale;
        //Player Horizontal Movement
        Vector2 input = _moveAction.ReadValue<Vector2>();
        float horizontalInput = input.x;

        _rigidbody.velocity = new Vector2(horizontalInput * moveSpeed, _rigidbody.velocity.y);
    }

    private void GravityMovement()
    {
        //set Variables
        _rigidbody.gravityScale = 0f;
        moveSpeed = gravitySpeed;
        //Player Floaty Movement
        Vector2 input = _moveAction.ReadValue<Vector2>();
        float horizontalInput = input.x;
        float verticalInput = input.y;

        //For future Knrc (make a thingy which checks how much velocity you have and limit it to a fixed ammount)

        _rigidbody.AddForce(new Vector2(horizontalInput * moveSpeed, verticalInput * moveSpeed));
    }

    private void Jump(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        if (isGrounded)
        {
            _rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
    private void Jump_canceled(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        if (!isGrounded)
        {
            var v = _rigidbody.velocity;
            v.y = Mathf.Min(v.y, jumpCancelSpeed);
            _rigidbody.velocity = v;
        }
    }
}
