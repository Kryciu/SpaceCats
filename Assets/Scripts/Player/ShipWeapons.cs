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
    public GameObject ProjectileOrigin;

    private float _lastShootTime;
    private float _cooldownCounter;
    
    private bool _canShoot = true;

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
            if (laserPrefab == null) return;
            ShootLaser();
        }
        else
        {
            if (!(_cooldownCounter > 0)) return;
            _cooldownCounter -= 0.1f;
        }
    }

    private void UpdateWeaponData(ShipWeaponsData weaponType)
    {
        if(weaponType == null) return;
        damageAmount = weaponType.damage;
        currentFireRate = weaponType.fireRate;
        currentCooldown = weaponType.coolDown;
    }

    private void ShootLaser()
    {
        if (!_canShoot) return;
        _cooldownCounter += 0.1f;
        if (!(_cooldownCounter >= 200))
        {
            if (!(Time.time > _lastShootTime + currentFireRate)) return;
            if (ProjectileOrigin == null) return;
            Instantiate(laserPrefab, ProjectileOrigin.transform.position, quaternion.identity);
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