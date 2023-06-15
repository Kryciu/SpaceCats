using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;
using Unity.Mathematics;
using Unity.VisualScripting;
using Random = System.Random;

public class Asteroid : MonoBehaviour, IDamagable
{
    [Header("Asteroid Settings")]
    public AsteroidData asteroidData;
    private string eventName = "event:/asteroids";
    private float _health;
    EventInstance instance;
    private Rigidbody _asteroidRB;
    private Camera _playerCamera;
    [SerializeField] private float _minSpinSpeed = 1f;
    [SerializeField] private float _maxSpinSpeed = 5f;
    private float _spinSpeed;

    private void Awake()
    {
        _playerCamera = Camera.main;
        _asteroidRB = GetComponent<Rigidbody>();

        if (PlayerPrefs.GetInt("SpeedLevel") == 0)
        {
            switch (asteroidData.Size)
            {
                case AsteroidData.size.Small:
                    asteroidData = Resources.Load<AsteroidData>("SmallAsteroid");
                    break;
                case AsteroidData.size.Medium:
                    asteroidData = Resources.Load<AsteroidData>("MediumAsteroid");
                    break;
                case AsteroidData.size.Large:
                    asteroidData = Resources.Load<AsteroidData>("LargeAsteroid");
                    break;
            }
        }
        else
        {
            switch (asteroidData.Size)
            {
                case AsteroidData.size.Small:
                    asteroidData = Resources.Load<AsteroidData>("SmallAsteroidUpgraded");
                    break;
                case AsteroidData.size.Medium:
                    asteroidData = Resources.Load<AsteroidData>("MediumAsteroidUpgraded");
                    break;
                case AsteroidData.size.Large:
                    asteroidData = Resources.Load<AsteroidData>("LargeAsteroidUpgraded");
                    break;
            }
        }
    }

    private void Start()
    {
        _health = asteroidData.health;

        _spinSpeed = UnityEngine.Random.Range(_minSpinSpeed, _maxSpinSpeed);
    }

    private void Update()
    {
        _asteroidRB.velocity = new Vector3(0, 0, (asteroidData.speed * -1));
        transform.Rotate(Vector3.up,_spinSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        IDamagable damagable = other.GetComponentInParent<IDamagable>();
        if (!(other.name == "AteroidSmallPlaceholder(Clone)" || other.name == "AteroidMediumPlaceholder(Clone)" || other.name == "AteroidLargePlaceholder(Clone)"))
        {
            if (damagable == null) return;
            damagable.TakeDamage(100);
        }

    }

    public void DestroyObject()
    {
        instance = RuntimeManager.CreateInstance(eventName);
        instance.set3DAttributes(RuntimeUtils.To3DAttributes(_playerCamera.transform.position));
        switch (asteroidData.Size)
        {
            case AsteroidData.size.Small:
                instance.setParameterByNameWithLabel("asteroid", "small explosion");
                break;
            case AsteroidData.size.Medium:
                instance.setParameterByNameWithLabel("asteroid", "medium explosion");
                break;
            case AsteroidData.size.Large:
                instance.setParameterByNameWithLabel("asteroid", "big explosion");
                break;
        }
        instance.start();
        Destroy(gameObject);
    }

    public void TakeDamage(float damage)
    {
        _health -= damage;
        if (_health <= 0)
        {
            GetComponent<Coins_Drop>()?.DieCoins();
            DestroyObject();
        }
    }
}
