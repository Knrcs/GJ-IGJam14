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
    private InputAction _jumpAction;
    private PlayerInput _playerInput;
    
    public Collider2D GroundCollider;
    public ContactFilter2D GroundColliderFilter;
    
    private bool isGrounded;
    private bool _isjumping;

    private Vector2 _moveInput;
    private float _jumpInput;

    void Start()
    {
        _animatior = GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _playerInput = GetComponent<PlayerInput>();
        _moveAction = _playerInput.actions.FindAction("Move");
        _jumpAction = _playerInput.actions.FindAction("Jump");
    }

    // Update is called once per frame
    void Update()
    {
        MovementAnimation();
        JumpFallAnimation();
        OnGroundAnimation();
        IsFloating();
    }

    private void MovementAnimation()
    {
        //Covers the xVelocity Animation
        _moveInput = _moveAction.ReadValue<Vector2>();
        
        _animatior.SetFloat("xVelocity", Mathf.Abs(_moveInput.x));
    }

    private void JumpFallAnimation()
    {
        _jumpInput = _jumpAction.ReadValue<float>();

        if (_jumpInput > 0)
        {
            _isjumping = true;
        }
        else
        {
            _isjumping = false;

        }
        
        _animatior.SetBool("jump", _isjumping);
        _animatior.SetFloat("yVelocity", _rigidbody2D.velocity.y);
    }

    private void OnGroundAnimation()
    {
        var list = new List<Collider2D>();
        var count = GroundCollider.OverlapCollider(GroundColliderFilter, list);

        isGrounded = count > 0;
        
        _animatior.SetBool("onGround", isGrounded);
    }

    private void IsFloating()
    {
        if(GetComponent<PlayerMovementDream>().isActiveAndEnabled)
        {
            _animatior.SetBool("isFloating", true);
        }
        else
        {
            _animatior.SetBool("isFloating", false);
        }
    }
}
