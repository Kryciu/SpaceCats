using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class AsteroidField : MonoBehaviour
{
    [SerializeField] private Transform _SmallasteroidPrefab;
    [SerializeField] private Transform _MediumasteroidPrefab;
    [SerializeField] private Transform _LargeasteroidPrefab;
    public Vector3 Offset;
    [SerializeField] private int _fieldRadius = 100;
    [SerializeField] private int _SmallasteroidCount = 100;
    [SerializeField] private int _MediumasteroidCount = 100;
    [SerializeField] private int _LargeasteroidCount = 100;
    
    //Initialization
    private void Start()
    {
        for (int i = 0; i < _SmallasteroidCount; i++)
        {
            Transform temp = Instantiate(_SmallasteroidPrefab, UnityEngine.Random.insideUnitSphere * _fieldRadius + Offset,
                UnityEngine.Random.rotation);
            temp.localScale = temp.localScale * UnityEngine.Random.Range(2f, 5f);
        }
        for (int i = 0; i < _MediumasteroidCount; i++)
        {
            Transform temp = Instantiate(_MediumasteroidPrefab, UnityEngine.Random.insideUnitSphere * _fieldRadius + Offset,
                UnityEngine.Random.rotation);
            temp.localScale = temp.localScale * UnityEngine.Random.Range(2f, 5f);
        }
        for (int i = 0; i < _LargeasteroidCount; i++)
        {
            Transform temp = Instantiate(_LargeasteroidPrefab, UnityEngine.Random.insideUnitSphere * _fieldRadius + Offset,
                UnityEngine.Random.rotation);
            temp.localScale = temp.localScale * UnityEngine.Random.Range(2f, 5f);
        }
    }
}
