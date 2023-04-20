using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class WeaponDataSO : ScriptableObject
{
    [Header("Weapon Data")] 
    public float laserDamage = 25;
    public float laserFireRate = 0.05f;
    public float strongerLaserDamage = 50;
    public float strongerLaserFireRate = 0.35f;
}
