using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementComponent : MonoBehaviour
{
    public bool IsInAir { get; private set; }
    public bool IsSprinting { get; private set; }


    public float WalkSpeed = 150.0f;
    public float SprintMultiplier = 2f;
    public float JumpHeight = 1.0f;

    [Tooltip("The camera is use to know the direction the player is looking at and to apply movement relative to that direction.")]
    public Camera PlayerCamera;

    private Rigidbody _rigidbody;
    private CapsuleCollider _collider;
    private Vector2 _moveVector;

    // Start is called before the first frame update
    private void Start()
    {
        IsInAir = false;
        IsSprinting = false;

        _rigidbody = GetComponent<Rigidbody>();
        _collider = GetComponent<CapsuleCollider>();

        _moveVector = new Vector2();
    }

    private void Update()
    {
        Debug.Log(_rigidbody.velocity.magnitude);
    }
    
    private void FixedUpdate()
    {
        #region Air Detection

        // We need to check against all layer except the 8th (the Player layer).
        var layerMask = 1 << 8;
        layerMask = ~layerMask;
        var radius = _collider.radius * 0.75f;

        IsInAir = !Physics.CheckCapsule(_collider.bounds.center,
            new Vector3(_collider.bounds.center.x, _collider.bounds.min.y + radius - 0.1f, _collider.bounds.center.z),
            radius, layerMask);

        #endregion

        #region Movement

        if (IsInAir) return;

        var movement = new Vector3(_moveVector.x, 0, _moveVector.y) * WalkSpeed * Time.fixedDeltaTime;
        movement = Quaternion.AngleAxis(PlayerCamera.transform.rotation.eulerAngles.y, Vector3.up) * movement;

        if (IsSprinting)
            movement *= SprintMultiplier;

        // Do not override the gravity force
        var yV = _rigidbody.velocity.y;
        movement.y = yV;

        _rigidbody.velocity = movement;

        #endregion
    }

    /// <summary>
    /// Set the movement vector (usually the controller input).
    /// </summary>
    /// <param name="value">A Vector2 representing the input vector. Will be normalized.</param>
    public void Move(Vector2 value)
    {
        Internal_Move(value.normalized);
    }

    /// <summary>
    /// Internal method that doesn't normalize the input vector (it should already be normalized).
    /// </summary>
    /// <param name="value">A normalized vector.</param>
    private void Internal_Move(Vector2 value)
    {
        _moveVector = value;
    }

    #region Input Events

    private void OnMove(InputValue value)
    {
        var v = value.Get<Vector2>();

        // Since the input is already normalized, we can directly call the internal move method.
        Internal_Move(v);
    }

    private void OnJump()
    {
        if (IsInAir) return;

        _rigidbody.AddForce(Vector3.up * Mathf.Sqrt(JumpHeight * -2.0f * Physics.gravity.y), ForceMode.VelocityChange);
    }

    private void OnSprint(InputValue value)
    {
        // Check the state of the button when this event was called.
        if (!value.isPressed)
            // The button was release, so we assume it was a "hold" type (ex: hold Left Shift to sprint).
            IsSprinting = false;
        else
            // We just toggle the value.
            IsSprinting = !IsSprinting;
    }

    #endregion
}
