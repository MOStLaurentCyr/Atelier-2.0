using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    public GameObject Target;
    public GameObject CameraBoom;

    public float CameraDistance = 4.0f;
    public float CameraDistanceSmoothness = 100.0f;
    public float CameraMaxAngle = 80.0f;
    public float CameraMinAngle = -80.0f;
    public LayerMask CameraCollisionMask;

    private Vector2 _lookVector;
    private Vector3 _rotation;
    private Vector3 _cameraPosition;

    private void Start()
    {
        // Automatically find the camera boom, camera collision and the player
        var parentT = transform.parent;

        if (!CameraBoom && parentT)
            CameraBoom = parentT.gameObject;

        if (!Target && parentT)
        {
            var parentParentT = parentT.parent;
            if (parentParentT)
                Target = parentParentT.gameObject;
        }


        _rotation = CameraBoom.transform.rotation.eulerAngles;

        Cursor.lockState = CursorLockMode.Locked;
    }

    private void LateUpdate()
    {
        _rotation.y += _lookVector.x * Time.deltaTime;
        _rotation.x += _lookVector.y * Time.deltaTime;
        _rotation.x = Mathf.Clamp(_rotation.x, CameraMinAngle, CameraMaxAngle);

        CameraBoom.transform.rotation = Quaternion.Euler(_rotation.x, _rotation.y, 0.0f);

        OccludeCamera();
        transform.localPosition = Vector3.Lerp(transform.localPosition, _cameraPosition, Time.deltaTime * CameraDistanceSmoothness);
    }

    public void Look(Vector2 value)
    {
        _lookVector = value;
    }

    private void OccludeCamera()
    {
        _cameraPosition =
            Physics.Linecast(Target.transform.position, transform.position, out var wallHit, CameraCollisionMask)
                ? new Vector3(0, 0, -wallHit.distance)
                : new Vector3(0, 0, -CameraDistance);
    }

    #region Player Input Events

    private void OnLook(InputValue value)
    {
        var v = value.Get<Vector2>();

        Look(v);
    }

    #endregion
}
