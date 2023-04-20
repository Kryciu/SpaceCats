using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class WeaponDataSO : ScriptableObject
{
    [Header("Weapon Data")] 
    public float Damage = 25f;
    public float FireRate = 0.05f;
    public float Cooldown = 1.0f;
}
