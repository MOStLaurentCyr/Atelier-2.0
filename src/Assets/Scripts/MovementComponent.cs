using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementComponent : MonoBehaviour
{
    public bool Sprinting = false;
    public float WalkSpeed = 10.0f;
    public float SprintMultiplier = 2f;
    public float JumpForce = 4.0f;

    private Rigidbody _rb;
    private Vector2 _moveVector;

    // Start is called before the first frame update
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();

        _moveVector = new Vector2();
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Vector3 displacement = new Vector3(_moveVector.x, 0, _moveVector.y) * WalkSpeed * Time.fixedDeltaTime;

        if (Sprinting)
            displacement *= SprintMultiplier;

        _rb.MovePosition(transform.position + displacement);

        // If the player is too slow or stopped, cancel the sprint (for toggle sprint type).
        if (Sprinting && _rb.velocity.magnitude <= 0.1)
            Sprinting = false;
    }

    public void Move(Vector2 value)
    {
        _moveVector = value;
    }
}
