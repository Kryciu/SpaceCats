using System;
using System.Collections;
using System.Collections.Generic;
using FMOD;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class ShipWeapons : MonoBehaviour
{
    [HideInInspector]
    public float damageAmount;
    [HideInInspector]
    public float currentFireRate;
    [HideInInspector]
    public float currentCooldown;

    [Header("Ship Weapons")]
    public ShipWeaponsData laser;
    public ShipWeaponsData strongerLaser;

    [Header("Laser Settings")]
    public GameObject laserPrefab;
    public GameObject ship;

    private float _lastShootTime;
    private float _cooldownCounter;
    
    private bool _canShoot = true;
    private bool _isShooting;

    private void Start()
    {
        //Set weapon and damage on start
        UpdateWeaponData(laser);
    }

    private void Update()
    {
        //if arrow up is pressed set weapon to laser and update damage
        if (Input.GetButtonDown("Vertical") && Input.GetAxisRaw("Vertical") > 0)
        {
            UpdateWeaponData(laser);
            //if arrow down is pressed set weapon to stronger laser and update damage
        } else if (Input.GetButtonDown("Vertical") && Input.GetAxisRaw("Vertical") < 0)
        {
            UpdateWeaponData(strongerLaser);
        }

        if (Input.GetKey("space"))
        {
            ShootLaser();
        }
        else
        {
            _isShooting = false;
            if (!(_cooldownCounter > 0)) return;
            _cooldownCounter -= 0.1f;
        }
    }

    private void UpdateWeaponData(ShipWeaponsData weaponType)
    {
        damageAmount = weaponType.damage;
        currentFireRate = weaponType.fireRate;
        currentCooldown = weaponType.coolDown;
    }

    private void ShootLaser()
    {
        if (!_canShoot) return;
        _isShooting = true;
        _cooldownCounter += 0.1f;
        if (!(_cooldownCounter >= 200))
        {
            if (!(Time.time > _lastShootTime + currentFireRate)) return;
            Instantiate(laserPrefab, ship.transform.position, quaternion.identity);
            laserPrefab.GetComponent<Laser>().damage = damageAmount;
            _lastShootTime = Time.time;
        }
        else
        {
            StartCoroutine(WeaponCooldown());
        }
    }

    private IEnumerator WeaponCooldown()
    {
        _canShoot = false;
        yield return new WaitForSeconds(currentCooldown);
        _cooldownCounter = 0;
        _canShoot = true;
    }
}