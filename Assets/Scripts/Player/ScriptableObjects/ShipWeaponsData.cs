using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ShipWeaponsData : ScriptableObject
{
    [Header("Weapon Data")] 
    public float damage = 25;
    public float fireRate = 0.05f;
    public float coolDown = 1.0f;
}
