using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ShipStats : ScriptableObject
{
    [Header("Ship Stats")]
    public float health = 100;
    public float speed = 100;
}
