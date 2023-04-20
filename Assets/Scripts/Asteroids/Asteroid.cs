using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour, IDamagable
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
        IDamagable damagable = other.GetComponentInParent<IDamagable>();
        if (damagable == null) return;
        damagable.DestroyObject();
    }

    public void DestroyObject()
    {
        Destroy(gameObject);
    }

    public void DealDamage(float damage)
    {
        _health -= damage;
        if (_health <= 0)
        {
            DestroyObject();
        }
    }
}
