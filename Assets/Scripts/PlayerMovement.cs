using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private PlayerInput _playerInput;
    private InputAction _moveAction;
    private Rigidbody2D _rigidbody;
    [Header("Movement")]

    public float moveSpeed = 5f;
    public float walkSpeed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        _playerInput = GetComponent<PlayerInput>();
        _moveAction = _playerInput.actions.FindAction("Move");
        _rigidbody = GetComponent<Rigidbody2D>();

        moveSpeed = walkSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        //Player Horizontal Movement
        Vector2 input = _moveAction.ReadValue<Vector2>();
        float horizontalInput = input.x;

        _rigidbody.velocity = new Vector2(horizontalInput * moveSpeed, _rigidbody.velocity.y);
    }
}
