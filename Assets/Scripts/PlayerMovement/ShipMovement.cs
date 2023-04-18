using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    private Rigidbody _shipRigidbody;
    private Camera _mainCamera;

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
        float moveRight = Input.GetAxis("Horizontal");

        Vector3 sideMovement = new Vector3(moveRight, 0, forwardMoveSpeed);
        _shipRigidbody.velocity = sideMovement * sideMoveSpeed;
        
        _shipRigidbody.rotation = Quaternion.Euler(Vector3.forward * -moveRight * tiltAngle);
    }

    //Update camera location
    private void LateUpdate()
    {
        Vector3 targetPosition = target.position + cameraOffset;
        Vector3 smoothedPosition = Vector3.Lerp(_mainCamera.transform.position, targetPosition, smoothSpeed);
        _mainCamera.transform.position = smoothedPosition;
    }
}
