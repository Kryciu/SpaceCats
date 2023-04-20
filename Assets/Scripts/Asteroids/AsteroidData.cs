using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class AsteroidData : ScriptableObject
{
    [Header("Large Asteroid")] 
    public float largeAsteroidHealth = 500;
    
    [Header("Medium Asteroid")]
    public float mediumAsteroidHealth = 250;
    
    [Header("Small Asteroid")]
    public float smallAsteroidHealth = 100;
}
