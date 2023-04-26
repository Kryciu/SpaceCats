using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [Header("Asteroid Settings")]
    public AsteroidData asteroidData;

    private Rigidbody _asteroidRB;

    private void Awake()
    {
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

    public void DealDamage(float damage)
    {
        asteroidData.health -= damage;
        if (asteroidData.health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
