using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    private Rigidbody _shipRigidbody;

    [Header("Ship Settings")]
    public float sideMoveSpeed;
    public float forwardMoveSpeed;
    public float tiltAngle;

    private void Start()
    {
        _shipRigidbody = transform.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float moveRight = Input.GetAxis("Horizontal");

        Vector3 movement = new Vector3(moveRight, 0, forwardMoveSpeed);
        _shipRigidbody.velocity = movement * sideMoveSpeed;

        _shipRigidbody.rotation = Quaternion.Euler(Vector3.forward * moveRight * tiltAngle);
    }
}
