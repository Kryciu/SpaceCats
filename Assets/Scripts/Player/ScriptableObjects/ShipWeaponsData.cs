using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ShipWeaponsData : ScriptableObject
{
    [Header("Weapon Data")] 
    public float damage;
    public float fireRate;
    public float coolDown;
}
