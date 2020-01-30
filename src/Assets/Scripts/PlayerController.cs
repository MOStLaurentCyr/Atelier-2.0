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
