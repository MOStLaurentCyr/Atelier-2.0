using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private MovementComponent _movementComponent;

    // Start is called before the first frame update
    private void Start()
    {

        // TODO: Maybe find something better than this
        UpdateComponents();
    }

    public void UpdateComponents()
    {
        _movementComponent = GetComponent<MovementComponent>();
    }

    #region Movement Component Actions

    private void OnMove(InputValue value)
    {
        if (!_movementComponent) return;

        var v = value.Get<Vector2>();
        _movementComponent.Move(v);
    }

    private void OnJump()
    {
        Debug.Log("Jumping");
    }

    private void OnSprint(InputValue value)
    {
        if (!_movementComponent) return;

        // Check the state of the button when this event was called.
        if (!value.isPressed)
            // The button was release, so we assume it was a "hold" type (ex: hold Left Shift to sprint).
            _movementComponent.Sprinting = false;
        else
            // We just toggle the value.
            _movementComponent.Sprinting = !_movementComponent.Sprinting;
    }

    #endregion

    private void OnLook(InputValue value)
    {
        var v = value.Get<Vector2>();
    }

    private void OnInteract()
    {

    }

    private void OnBasicAttack()
    {

    }

    private void OnMelee()
    {

    }

    private void OnRange()
    {

    }

    private void OnAbility()
    {

    }
}
