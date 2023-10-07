using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementDream : MonoBehaviour
{
    [Header("Gravity")]
    public float gravitySpeed = 2f;
    public float rigidbodyGravityScale = 1f; //TODO
    public float maxRigidbodyVelocity = 3f; //TODO

    private float moveSpeed = 5f;

    private PlayerInput playerInput;
    private InputAction moveAction;
    private Rigidbody2D rb;

    private PlayerInputSystem inputSystem;

    private Vector2 moveInput;

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
    }

    private void FixedUpdate()
    {
        GravityMovement();
    }

    private void GetInput()
    {
        moveInput = moveAction.ReadValue<Vector2>();
    }


    private void GravityMovement()
    {
        //Setup Physics
        rb.gravityScale = 0f;
        moveSpeed = gravitySpeed;

        //Player Floaty Movement
        rb.AddForce(new Vector2(moveInput.x * moveSpeed, moveInput.y * moveSpeed));

        //TODO: make a thingy which checks how much velocity you have and limit it to a fixed ammount
    }
}
