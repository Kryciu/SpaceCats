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

    public WeaponDataSO weaponData;
    public GameObject laserPrefab;
    public GameObject ship;

    private float _lastShootTime;
    private Weapons _weaponTypes;
    private bool _isShooting;
    private enum Weapons {Laser, StrongerLaser}

    private void Awake()
    {
        _weaponTypes = Weapons.Laser;
    }

    private void Start()
    {
        //Set weapon and damage on start
        UpdateDamageData();
        Debug.Log("Default Weapon Initialized:" + _weaponTypes);
    }

    private void Update()
    {
        //if arrow up is pressed set weapon to laser and update damage
        if (Input.GetButtonDown("Vertical") && Input.GetAxisRaw("Vertical") > 0)
        {
            _weaponTypes = Weapons.Laser;
            UpdateDamageData();
            Debug.Log("Gun:" + _weaponTypes);
            //if arrow down is pressed set weapon to stronger laser and update damage
        } else if (Input.GetButtonDown("Vertical") && Input.GetAxisRaw("Vertical") < 0)
        {
            _weaponTypes = Weapons.StrongerLaser;
            UpdateDamageData();
            Debug.Log("Gun:" + _weaponTypes);
        }

        if (Input.GetKey("space"))
        {
            ShootLaser();
        }

    }

    private void UpdateDamageData()
    {
        switch (_weaponTypes)
        {
            case Weapons.Laser:
                damageAmount = weaponData.laserDamage;
                currentFireRate = weaponData.laserFireRate;
                break;
            
            case Weapons.StrongerLaser:
                damageAmount = weaponData.strongerLaserDamage;
                currentFireRate = weaponData.strongerLaserFireRate;
                break;
        }
    }

    private void ShootLaser()
    {
        if (!(Time.time > _lastShootTime + currentFireRate)) return;
        Instantiate(laserPrefab, ship.transform.position, quaternion.identity);
        laserPrefab.GetComponent<Laser>().damage = damageAmount;
        _lastShootTime = Time.time;
    }
}
