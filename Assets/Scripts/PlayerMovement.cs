using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private PlayerInput _playerInput;
    private InputAction _moveAction;
    private InputAction _jumpAction;
    private Rigidbody2D _rigidbody;

    private PlayerInputSystem _input;

    public bool switchMovementType;

    [SerializeField]private bool _playerJumped = false;
    [Header("Movement")]

    private float moveSpeed = 5f;
    public float walkSpeed = 5f;

    public float jumpForce = 15f;
    [Header("Gravity")]
    public float gravitySpeed = 2f;
    public float rigidbodyGravityScale = 1f;
    public float maxRigidbodyVelocity = 3f;

    
    // Start is called before the first frame update
    void Start()
    {
        _playerInput = GetComponent<PlayerInput>();
        _moveAction = _playerInput.actions.FindAction("Move");
        _jumpAction = _playerInput.actions.FindAction("Jump");
        _rigidbody = GetComponent<Rigidbody2D>();
        _input = new PlayerInputSystem();
        _input.Player.Enable();
        _input.Player.Jump.performed += Jump;
        _input.Player.Jump.canceled += Jump_canceled;
        
        moveSpeed = walkSpeed;
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
        if(!switchMovementType)
        {
            _playerJumped = true;
            _rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
    private void Jump_canceled(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        Debug.Log("woa");
        if (_playerJumped == false)
        {
        var forceEffect = context.duration;
        _rigidbody.AddForce(Vector2.up * (jumpForce * (float)forceEffect), ForceMode2D.Impulse);
        Debug.Log("Awa Canle");
        }
    }
}
