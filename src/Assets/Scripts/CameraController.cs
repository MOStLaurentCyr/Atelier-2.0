using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    public GameObject Player;

    public float CameraOffset = 4.0f;
    public float CameraMoveSpeed = 120.0f;
    public float CameraSensitivity = 10.0f;
    public float CameraMaxAngle = 80.0f;
    public float CameraMinAngle = -80.0f;

    private Vector2 _lookVector;
    private Vector2 _rotation;

    private void Start()
    {
        _rotation = transform.localRotation.eulerAngles;

        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        //_rotation.y += _lookVector.x * Time.deltaTime;
        //_rotation.x += _lookVector.y * Time.deltaTime;

        //_rotation.x = Mathf.Clamp(_rotation.x, CameraMinAngle, CameraMaxAngle);

        //transform.rotation = Quaternion.Euler(_rotation.x, _rotation.y, 0.0f);
    }

    private void LateUpdate()
    {
        //_rotation.y += _lookVector.x * Time.deltaTime;
        //_rotation.x += _lookVector.y * Time.deltaTime;

        //_rotation.x = Mathf.Clamp(_rotation.x, CameraMinAngle, CameraMaxAngle);

        //transform.rotation = Quaternion.Euler(_rotation.x, _rotation.y, 0.0f);

        transform.LookAt(Player.transform);
    }

    public void Look(Vector2 value)
    {
        _lookVector = value;
    }

    private void OnLook(InputValue value)
    {
        var v = value.Get<Vector2>();

        Look(v);
    }
}
