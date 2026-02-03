// James Letts Brennan Duff
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMovement : MonoBehaviour
{
    // Public variable for speed, visible in the Unity Inspector
    public float movementSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 moveDirection;

    void Start()
    {
        // Get the Rigidbody2D component attached to the player
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb.linearVelocity = moveDirection * movementSpeed;

    }

    public void move(InputAction.CallbackContext context)
    {
        moveDirection = context.ReadValue<Vector2>();
    }
}
