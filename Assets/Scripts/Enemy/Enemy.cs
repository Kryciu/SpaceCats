using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Debug = FMOD.Debug;

public class Enemy : MonoBehaviour, IDamagable
{
    public EnemyData EnemyData;

    private float maxHealth;
    private float currentHealh;

    private Rigidbody _rb;

    private float speed;

    private int _currentCheckpointIndex;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHealh = EnemyData.maxHealth;
        transform.position = EnemyData.checkpoints[_currentCheckpointIndex].transform.position;

        speed = EnemyData.Speed;
    }

    // Update is called once per frame
    void Update()
    {
        var step = (speed = EnemyData.Speed) * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position,
            EnemyData.checkpoints[_currentCheckpointIndex].transform.position, step);
        
        if (transform.position == EnemyData.checkpoints[_currentCheckpointIndex].transform.position)
        {
            _currentCheckpointIndex = (_currentCheckpointIndex + 1) % EnemyData.checkpoints.Count;
        }

        void DealDamage(float damage)
        {
            currentHealh -= damage;
            if (currentHealh <= 0)
            {
                Destroy(gameObject);
            }
        }

    }

    public void DealDamage(float damage)
    {
        throw new NotImplementedException();
    }
}