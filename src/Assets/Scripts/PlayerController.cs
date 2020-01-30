using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {

    }

    private void OnLook(InputValue value)
    {
        var v = value.Get<Vector2>();
    }

    private void OnInteract()
    {
        Debug.Log("Interact button pressed");
    }

    private void OnBasicAttack()
    {
        Debug.Log("Basic attack button pressed");

    }

    private void OnMelee()
    {
        Debug.Log("Melee button pressed");

    }

    private void OnRange()
    {
        Debug.Log("Range button pressed");

    }

    private void OnAbility()
    {
        Debug.Log("Ability button pressed");

    }
}
