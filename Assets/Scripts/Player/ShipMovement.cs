using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class ShipMovement : MonoBehaviour
{
    //Components
    private Rigidbody _shipRigidbody;
    private Camera _mainCamera;

    //Movement
    private Vector3 _sideMovement;
    private float _shipRotation;
    private float _moveRight;

    //FMOD
    private string eventName = "event:/spaceship moving";
    EventInstance instance;
    private string eventNameSpaceshipsidemovement = "event:/spaceship avoiding";
    EventInstance spaceshipSideMovement;

    bool istriggered;

    [Header("Ship Settings")] 
    public GameObject ship;
    public float sideMoveSpeed;
    public float tiltAngle;
    public float rotationSmooth;

    [Header("Camera Settings")] 
    public Transform target;
    public Vector3 cameraOffset;
    public float smoothSpeed;

    private void Awake()
    {
        _mainCamera = GetComponentInChildren<Camera>();
        _shipRigidbody = ship.transform.GetComponent<Rigidbody>();
        
    }

    private void Start()
    {
        spaceshipSideMovement = RuntimeManager.CreateInstance(eventNameSpaceshipsidemovement);
        instance = RuntimeManager.CreateInstance(eventName);
        instance.start();

        
    }

    //Ship movement
    private void Update()
    {

        if (ship == null) return;
        _moveRight = Input.GetAxis("Horizontal");

        _sideMovement = new Vector3(_moveRight, 0, 0);
        MovementBoundaries();
        _shipRigidbody.velocity = _sideMovement * sideMoveSpeed;

        _shipRotation = -_moveRight * tiltAngle;
        Quaternion targetRotation = Quaternion.AngleAxis(_shipRotation, Vector3.forward);
        _shipRigidbody.rotation = Quaternion.Slerp(_shipRigidbody.rotation, targetRotation, rotationSmooth * Time.deltaTime);

        instance.set3DAttributes(RuntimeUtils.To3DAttributes(_mainCamera.transform.position));
        spaceshipSideMovement.set3DAttributes(RuntimeUtils.To3DAttributes(_mainCamera.transform.position));

        
    }
        

    

    //Update camera location
    private void LateUpdate()
    {
        if (ship == null) return;
        Vector3 targetPosition = target.position + cameraOffset;
        Vector3 smoothedPosition = Vector3.Lerp(_mainCamera.transform.position, targetPosition, smoothSpeed);
        _mainCamera.transform.position = smoothedPosition;
    }
    private void MovementBoundaries()
    {
        switch (ship.transform.position.x)
        {
            case >= 50: //right
                _sideMovement = new Vector3(0, 0, 0);
                if (_moveRight < 0)
                {
                    _sideMovement = new Vector3(_moveRight, 0, 0);
               

                }
                break;
            case <= -50: //left
                _sideMovement = new Vector3(0, 0, 0);
                if (_moveRight > 0)
                {
                    _sideMovement = new Vector3(_moveRight, 0, 0);
                   
                } 
                break;
           
                
        }
    }
}
