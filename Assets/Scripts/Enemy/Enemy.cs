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
    public float detectionRange = 400f;
    private GameObject Player;

    private int _currentCheckpointIndex;
    private Vector3 originPosition;
    private bool isStop;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        originPosition = transform.position;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHealh = EnemyData.maxHealth;
        speed = EnemyData.Speed;

        Player = GameObject.FindGameObjectWithTag("Player");

        isStop = false;
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, Player.transform.position);
        
        if(isStop)
        {
            var step = EnemyData.Speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position,originPosition + EnemyData.checkpoints
                [_currentCheckpointIndex].transform.position, step);

            if (transform.position == originPosition + EnemyData.checkpoints[_currentCheckpointIndex].transform.position)

            {
                _currentCheckpointIndex = (_currentCheckpointIndex + 1) % EnemyData.checkpoints.Count;
            }
        }
        else
        {
            var step = EnemyData.Speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, step);
            
            if (distanceToPlayer <= detectionRange)
            {
                originPosition = transform.position;
                _rb.velocity = Vector3.zero;
                isStop = true;
                if (isStop = true)
                {
                    EnemyData.Speed = 200;
                }

            }
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealh -= damage;
        if (currentHealh <= 0)
        {
            GetComponent<Coins_Drop>().DieCoins();
            Destroy(gameObject);
        }
    }
}