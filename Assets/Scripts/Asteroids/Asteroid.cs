using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [Header("Asteroid Settings")]
    public AsteroidData asteroidData;
    public AsteroidType asteroidType;
    public enum AsteroidType
    {
        Small,
        Medium,
        Large,
    }

    private float _health;

    private void Awake()
    {
        //Set asteroid health when script is loaded
        switch (asteroidType)
        {
            case AsteroidType.Small:
                _health = asteroidData.smallAsteroidHealth;
                break;
            
            case AsteroidType.Medium:
                _health = asteroidData.mediumAsteroidHealth;
                break;
            
            case AsteroidType.Large:
                _health = asteroidData.largeAsteroidHealth;
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }

    public void TakeDamage(float damage)
    {
        _health -= damage;
        if (_health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
