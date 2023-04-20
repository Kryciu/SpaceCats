using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [Header("Asteroid Settings")]
    public AsteroidData asteroidData;

    private float _health;

    private void Awake()
    {
        _health = asteroidData.health;
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
