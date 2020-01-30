using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementComponent : MonoBehaviour
{
    public bool IsInAir => !_controller.isGrounded;
    public bool IsSprinting { get; private set; }

    public float WalkSpeed = 150.0f;
    public float SprintMultiplier = 2f;
    public float JumpHeight = 1.0f;
    public Vector3 GroundDrag = new Vector3(50f, 0, 50f);

    [Tooltip("The camera is use to know the direction the player is looking at and to apply movement relative to that direction.")]
    public Camera PlayerCamera;

    private CharacterController _controller;

    private bool _isJumping;
    private Vector2 _moveVector;
    private Vector3 _velocity;

    private void Start()
    {
        // If the camera wasn't provided, find one in the scene.
        if (!PlayerCamera)
            PlayerCamera = FindObjectOfType<Camera>();

        _controller = GetComponent<CharacterController>();

        _isJumping = false;
        _moveVector = new Vector2();
        _velocity = new Vector3();
    }

    // Compute movement inputs
    private void Update()
    {
        var move = new Vector3(_moveVector.x, 0, _moveVector.y) * WalkSpeed * Time.deltaTime;
        move = Quaternion.AngleAxis(PlayerCamera.transform.rotation.eulerAngles.y, Vector3.up) * move;

        if (IsSprinting)
            move *= SprintMultiplier;

        if (_controller.isGrounded)
            _velocity += move;

        if (move != Vector3.zero)
            transform.forward = move;
    }

    // Compute physics
    private void FixedUpdate()
    {
        if (_controller.isGrounded)
            _velocity.y = 0;

        if (_isJumping)
        {
            _isJumping = false;
            _velocity.y += Mathf.Sqrt(JumpHeight * -2.0f * Physics.gravity.y);
        }

        _velocity.y += Physics.gravity.y * Time.deltaTime;

        if (_controller.isGrounded)
        {
            _velocity.x /= 1 + GroundDrag.x * Time.deltaTime;
            _velocity.z /= 1 + GroundDrag.z * Time.deltaTime;
        }

        _controller.Move(_velocity * Time.deltaTime);
    }

    /// <summary>
    /// Set the movement vector (usually the controller input).
    /// </summary>
    /// <param name="value">A Vector2 representing the input vector. Will be normalized.</param>
    public void Move(Vector2 value)
    {
        Move_Internal(value.normalized);
    }

    /// <summary>
    /// Internal method that doesn't normalize the input vector (it should already be normalized).
    /// </summary>
    /// <param name="value">A normalized vector.</param>
    private void Move_Internal(Vector2 value)
    {
        _moveVector = value;
    }

    /// <summary>
    /// Make the character jump.
    /// </summary>
    public void Jump()
    {
        if (_controller.isGrounded)
            _isJumping = true;
    }

    /// <summary>
    /// Make the character run. This is a toggle but can also be use by holding an input (the value should be if the input is pressed or releases).
    /// </summary>
    /// <param name="value">The input state (<c>true</c> for pressed, <c>false</c> for released). Default to <c>true</c>.</param>
    public void Sprint(bool value = true)
    {
        // Check the state of the button when this event was called.
        if (!value)
            // The button was release, so we assume it was a "hold" type (ex: hold Left Shift to sprint).
            IsSprinting = false;
        else
            // We just toggle the value.
            IsSprinting = !IsSprinting;
    }

    #region Player Input Events

    private void OnMove(InputValue value)
    {
        var v = value.Get<Vector2>();
        Move_Internal(v);
    }

    private void OnJump()
    {
        Jump();
    }

    private void OnSprint(InputValue value)
    {
        Sprint(value.isPressed);
    }

    #endregion
}
