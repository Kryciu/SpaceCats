using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class EnemyData : ScriptableObject
{
    public float Health = 100;
    public float Speed = 10;
    
    public enum difficult
    {
        enemy1, enemy2, enemy3, enemy4, enemy5, enemy6
    }
}
