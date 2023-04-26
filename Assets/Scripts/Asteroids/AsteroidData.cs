using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class AsteroidData : ScriptableObject
{
    [Header("Asteroid Settings")]
    public float health;
    public float speed;
}
