using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipParameters : MonoBehaviour, IDamagable
{
    [Header("Ship Stats")]
    public ShipStats shipStats;

    private float _health;

    private void Awake()
    {
        _health = shipStats.health;
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
