using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class Asteroid : MonoBehaviour, IDamagable
{
    [Header("Asteroid Settings")]
    public AsteroidData asteroidData;
    private string eventName = "event:/asteroids";
    EventInstance instance;
    private Rigidbody _asteroidRB;
    private Camera _playerCamera;

    private void Awake()
    {
        _playerCamera = Camera.main;
        _asteroidRB = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _asteroidRB.velocity = new Vector3(0, 0, (asteroidData.speed * -1));
    }

    private void OnTriggerEnter(Collider other)
    {
        IDamagable damagable = other.GetComponentInParent<IDamagable>();
        if (damagable == null) return;
        Destroy(other.gameObject);
    }

    public void DestroyObject()
    {
        instance = RuntimeManager.CreateInstance(eventName);
        instance.set3DAttributes(RuntimeUtils.To3DAttributes(_playerCamera.transform.position));
        instance.setParameterByNameWithLabel("asteroid", "small explosion");
        instance.start();
        Destroy(gameObject);
    }

    public void DealDamage(float damage)
    {
        asteroidData.health -= damage;
        if (asteroidData.health <= 0)
        {
            DestroyObject();
        }
    }
}
