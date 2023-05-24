using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class EnemyData : ScriptableObject
{
    public List<GameObject> checkpoints = new List<GameObject>();
    public float maxHealth = 100;
    public float Speed = 80;
    
    public enum difficult
    {
        Easy, Medium, Hard
    }
}
