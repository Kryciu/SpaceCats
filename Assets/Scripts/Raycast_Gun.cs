using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]

public class Raycast_Gun : MonoBehaviour
{
    public Camera playerCamera;
    public Transform laserOrigin;
    public float gunRange = 50f;
    public float laserDuration = 0.05f;
    public float fireRate = 0.2f;
    
    LineRenderer LaserLine; 
    float fireTimer;

    private void Awake()
    {
        LaserLine = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        fireTimer += Time.deltaTime;
        if (Input.GetButtonDown("Jump") && fireTimer > fireRate)
        {
            fireTimer = 0f;
            LaserLine.SetPosition(0, laserOrigin.position);
            Vector3 rayOrigin = playerCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;
            if (Physics.Raycast(rayOrigin, playerCamera.transform.forward, out hit, gunRange))
            {
                LaserLine.SetPosition(1, hit.point);
                Destroy(hit.transform.gameObject);
            }
            else
            {
                LaserLine.SetPosition(1, rayOrigin + (playerCamera.transform.forward * gunRange));
            }

            StartCoroutine(ShootLasr());
        }
    }

    IEnumerator ShootLasr()
    {
        LaserLine.enabled = true;
        yield return new WaitForSeconds(laserDuration);
        LaserLine.enabled = false;
    }
}
