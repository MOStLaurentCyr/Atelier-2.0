using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementComponent : MonoBehaviour
{
    public bool Sprinting = false;
    public float WalkSpeed = 10.0f;
    public float SprintMultiplier = 2f;
    public float JumpForce = 4.0f;

    private CharacterController _controller;
    private Vector2 _moveVector;

    // Start is called before the first frame update
    private void Start()
    {
        _controller = GetComponent<CharacterController>();

        _moveVector = new Vector2();
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        // Movements
        Vector3 displacement = new Vector3(_moveVector.x, 0, _moveVector.y) * WalkSpeed;

        if (Sprinting)
            displacement *= SprintMultiplier;

        // Gravity
        displacement.y += Physics.gravity.y; // FIXME: Gravity is reset each frame (need to stack it until the player touch the ground).

        // Apply movement to Character Controller
        _controller.Move(displacement * Time.fixedDeltaTime);
    }

    /// <summary>
    /// Set the movement vector (usually the controller input).
    /// </summary>
    /// <param name="value">A normalized Vector2 representing the input vector.</param>
    public void Move(Vector2 value)
    {
        _moveVector = value;
    }
}
