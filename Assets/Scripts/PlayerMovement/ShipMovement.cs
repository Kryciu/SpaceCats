using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    //Components
    private Rigidbody _shipRigidbody;
    private Camera _mainCamera;
    
    //Movement
    private Vector3 _sideMovement;
    private float _shipRotation;
    private float _moveRight;

    [Header("Ship Settings")] 
    public GameObject ship;
    public float sideMoveSpeed;
    public float forwardMoveSpeed;
    public float tiltAngle;

    [Header("Camera Settings")] 
    public Transform target;
    public Vector3 cameraOffset;
    public float smoothSpeed;


    private void Awake()
    {
        _mainCamera = GetComponentInChildren<Camera>();
        _shipRigidbody = ship.transform.GetComponent<Rigidbody>();
    }

    //Ship movement
    private void Update()
    {
        _moveRight = Input.GetAxis("Horizontal");

        _sideMovement = new Vector3(_moveRight, 0, forwardMoveSpeed);
        MovementBoundaries();
        _shipRigidbody.velocity = _sideMovement * sideMoveSpeed;

        _shipRotation = -_moveRight * tiltAngle;
        _shipRigidbody.rotation = Quaternion.Euler(Vector3.forward * _shipRotation);
    }

    //Update camera location
    private void LateUpdate()
    {
        Vector3 targetPosition = target.position + cameraOffset;
        Vector3 smoothedPosition = Vector3.Lerp(_mainCamera.transform.position, targetPosition, smoothSpeed);
        _mainCamera.transform.position = smoothedPosition;
    }
    private void MovementBoundaries()
    {
        switch (ship.transform.position.x)
        {
            case >= 50:
                _sideMovement = new Vector3(0, 0, forwardMoveSpeed);
                if (_moveRight < 0)
                {
                    _sideMovement = new Vector3(_moveRight, 0, forwardMoveSpeed);
                }
                break;
            case <= -50:
                _sideMovement = new Vector3(0, 0, forwardMoveSpeed);
                if (_moveRight > 0)
                {
                    _sideMovement = new Vector3(_moveRight, 0, forwardMoveSpeed);
                }
                break;
        }
    }
}
