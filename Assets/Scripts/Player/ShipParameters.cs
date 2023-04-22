using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipParameters : MonoBehaviour, IDamagable
{
    [Header("Ship Stats")]
    public ShipStats shipStats;

    public void DestroyObject()
    {
        Destroy(gameObject);
    }

    public void DealDamage(float damage)
    {
        shipStats.health -= damage;
        if (shipStats.health <= 0)
        {
            DestroyObject();
        }
    }
}
