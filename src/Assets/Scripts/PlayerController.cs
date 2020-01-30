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
