using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class AsteroidData : ScriptableObject
{
    [Header("Asteroid Settings")]
    public float health = 100;

    public float speed = 10;
    public size Size;
    public enum  size
    {

        Small,Medium,Large


    };
}
