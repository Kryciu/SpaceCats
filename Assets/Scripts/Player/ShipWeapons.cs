using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class ShipWeapons : MonoBehaviour
{
    [HideInInspector]
    public float damageAmount;
    public float currentFireRate;

    public WeaponDataSO laser;
    public WeaponDataSO strongerlaser;

    public GameObject laserPrefab;
    public GameObject ship;

    private float _lastShootTime;
    private bool _isShooting;

    private void Start()
    {
        //Set weapon and damage on start
        UpdateDamageData(laser);
    }

    private void Update()
    {
        //if arrow up is pressed set weapon to laser and update damage
        if (Input.GetButtonDown("Vertical") && Input.GetAxisRaw("Vertical") > 0)
        {
            UpdateDamageData(laser);
            //if arrow down is pressed set weapon to stronger laser and update damage
        } else if (Input.GetButtonDown("Vertical") && Input.GetAxisRaw("Vertical") < 0)
        {
            UpdateDamageData(strongerlaser);
        }

        if (Input.GetKey("space"))
        {
            ShootLaser();
        }

    }

    private void UpdateDamageData(WeaponDataSO WeaponType)
    {
        damageAmount = WeaponType.Damage;
        currentFireRate = WeaponType.FireRate;
    }

    private void ShootLaser()
    {

        if (!(Time.time > _lastShootTime + currentFireRate)) return;
        Instantiate(laserPrefab, ship.transform.position, quaternion.identity);
        laserPrefab.GetComponent<Laser>().damage = damageAmount;
        _lastShootTime = Time.time;
    }
}