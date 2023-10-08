using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAnimator : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator _animatior;
    private Rigidbody2D _rigidbody2D;
    private InputAction _moveAction;
    private PlayerInput _playerInput;

    private Vector2 _moveInput;

    void Start()
    {
        _animatior = GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _playerInput = GetComponent<PlayerInput>();
        _moveAction = _playerInput.actions.FindAction("Move");
    }

    // Update is called once per frame
    void Update()
    {
        MovementAnimation();
    }

    private void MovementAnimation()
    {
        _moveInput = _moveAction.ReadValue<Vector2>();
        
        _animatior.SetFloat("xVelocity", Mathf.Abs(_moveInput.x));
        Debug.Log(Mathf.Abs(_moveInput.x));
    }
}
